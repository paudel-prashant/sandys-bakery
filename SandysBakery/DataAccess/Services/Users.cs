using SandysBakery.BusinessLogic;
using SandysBakery.DataAccess.Adaptors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SandysBakery.DataAccess.Services
{
    public class Users : IUsers
    {
        IDataAdaptor dataAdaptor;
        MessageReturnType messageReturnType = null;

        public Users()
        {
            dataAdaptor = new DataAdaptor();
            messageReturnType = new MessageReturnType();
        }

        public List<Roles> GetRole()
        {
            string query = "SELECT * FROM dbo.Roles AS r";
            DataTable dataTable = dataAdaptor.FetchData(query, null, false);
            var role = new Helper().DataTableToListof<Roles>(dataTable).ToList();
            return role;
        }

        public UsersLogin UserLogin(UsersLogin usersLogin)
        {
            string query = "SELECT ul.UserId,ul.UserName,r.RoleName FROM dbo.UsersLogin AS ul JOIN dbo.Roles AS r ON r.RoleId = ul.RoleId WHERE ul.UserName=@UserName and ul.UserPassword=@Password AND ul.isActive=1";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserName",usersLogin.UserName),
                new SqlParameter("@Password",usersLogin.UserPassword),
            };
            DataTable dataTable = dataAdaptor.FetchData(query, sqlParameters, false);
            UsersLogin usersLoginModel = new UsersLogin();
            usersLoginModel = new Helper().DataTableToListof<UsersLogin>(dataTable).FirstOrDefault();
            return usersLoginModel;
        }

        public MessageReturnType UserRegistration(UsersRegistration usersRegistration)
        {
            SqlTransaction sqlTransaction = null;
            DataTable dataTable = ValidateExistingUser(usersRegistration.EmailId);
            if (dataTable.Rows.Count > 0)
            {
                messageReturnType.ReturnMessage = "Email already exists.";
                messageReturnType.IsSuccess = false;
                return messageReturnType;
            }
            using (SqlConnection sqlConnection = new SqlConnection(dataAdaptor.GetDbConnection))
            {
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction();
                try
                {
                    var role = GetRole().Where(x => x.RoleName == "User").FirstOrDefault();
                    string queryUsersRegistration = "INSERT INTO dbo.UsersRegistration(FirstName,MiddleName,LastName,EmailId,PhoneNumber,ShippingAddress,RegistrationDate) VALUES(@FirstName,@MiddleName,@LastName,@EmailId,@PhoneNumber,@ShippingAddress,@RegistrationDate) SELECT SCOPE_IDENTITY()";
                    SqlParameter[] sqlParametersRegistration = new SqlParameter[]
                    {
                         new SqlParameter("@FirstName",usersRegistration.FirstName),
                         new SqlParameter("@MiddleName",usersRegistration.MiddleName),
                         new SqlParameter("@LastName",usersRegistration.LastName),
                         new SqlParameter("@EmailId",usersRegistration.EmailId),
                         new SqlParameter("@PhoneNumber",usersRegistration.PhoneNumber),
                         new SqlParameter("@ShippingAddress",usersRegistration.ShippingAddress),
                         new SqlParameter("@RegistrationDate",DateTime.Now)
                    };

                    SqlCommand sqlCommand = new SqlCommand(queryUsersRegistration, sqlConnection, sqlTransaction);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddRange(sqlParametersRegistration);

                    int registrationId = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    string queryUsersLogin = "INSERT INTO dbo.UsersLogin(UserName, UserPassword, LoginDate, RoleId, isActive, RegistrationId)VALUES(@UserName,@UserPassword,@LoginDate,@RoleId,@isActive,@RegistrationId)";
                    SqlParameter[] sqlParametersLogin = new SqlParameter[]
                    {
                        new SqlParameter("@UserName",usersRegistration.EmailId),
                        new SqlParameter("@UserPassword",new Helper().Encrypt(usersRegistration.UserLogin.UserPassword)),
                        new SqlParameter("@LoginDate",DateTime.Now),
                        new SqlParameter("@RoleId",role.RoleId),
                        new SqlParameter("@isActive",true),
                        new SqlParameter("@RegistrationId",registrationId)
                    };

                    sqlCommand = new SqlCommand(queryUsersLogin, sqlConnection, sqlTransaction);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddRange(sqlParametersLogin);
                    sqlCommand.ExecuteNonQuery();

                    messageReturnType.IsSuccess = true;
                    messageReturnType.ReturnMessage = "Data successfully saved.";
                    sqlTransaction.Commit();

                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    messageReturnType.IsSuccess = false;
                    messageReturnType.ReturnMessage = ex.Message;

                }
                return messageReturnType;
            }

        }

        public DataTable ValidateExistingUser(string userName)
        {
            MessageReturnType messageReturnType = new MessageReturnType();
            string query = "SELECT * FROM dbo.UsersLogin AS ul WHERE ul.UserName=@UserName";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserName",userName),
            };
            DataTable dataTable = dataAdaptor.FetchData(query, sqlParameters, false);
            return dataTable;
        }

        public UsersRegistration GetUserDetailsById(int registrationId)
        {
            MessageReturnType messageReturnType = new MessageReturnType();
            string query = "SELECT * FROM dbo.UsersRegistration WHERE RegistrationId=@registrationId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@registrationId", registrationId),
            };
            DataTable dataTable = dataAdaptor.FetchData(query, sqlParameters, false);
            UsersRegistration usersRegistration = new Helper().DataTableToListof<UsersRegistration>(dataTable).FirstOrDefault();
            return usersRegistration;
        }

        public MessageReturnType EditUsers(UsersRegistration usersRegistration)
        {
            SqlTransaction sqlTransaction = null;
            using (SqlConnection sqlConnection = new SqlConnection(dataAdaptor.GetDbConnection))
            {
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction();
                try
                {
                    string queryUsersRegistration = "UPDATE dbo.UsersRegistration SET FirstName=@FirstName,MiddleName=@MiddleName,LastName=@LastName,PhoneNumber=@PhoneNumber,ShippingAddress=@ShippingAddress WHERE RegistrationId=@RegistrationId";
                    SqlParameter[] sqlParametersRegistration = new SqlParameter[]
                    {
                        new SqlParameter("@RegistrationId",usersRegistration.RegistrationId),
                        new SqlParameter("@FirstName",usersRegistration.FirstName),
                        new SqlParameter("@MiddleName",usersRegistration.MiddleName),
                        new SqlParameter("@LastName",usersRegistration.LastName),
                        new SqlParameter("@PhoneNumber",usersRegistration.PhoneNumber),
                        new SqlParameter("@ShippingAddress",usersRegistration.ShippingAddress),
                    };

                    SqlCommand sqlCommand = new SqlCommand(queryUsersRegistration, sqlConnection, sqlTransaction);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddRange(sqlParametersRegistration);

                    //string queryUsersLogin = "UPDATE dbo.UsersLogin SET UserName=@UserName WHERE RegistrationId=@RegistrationId";
                    //SqlParameter[] sqlParametersLogin = new SqlParameter[]
                    //{
                        //new SqlParameter("@UserName",usersRegistration.EmailId)
                    //};

                    //sqlCommand = new SqlCommand(queryUsersLogin, sqlConnection, sqlTransaction);
                    //sqlCommand.CommandType = CommandType.Text;
                    //sqlCommand.Parameters.AddRange(sqlParametersLogin);
                    sqlCommand.ExecuteNonQuery();

                    messageReturnType.IsSuccess = true;
                    messageReturnType.ReturnMessage = "User details have successfully been updated.";
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    messageReturnType.IsSuccess = false;
                    messageReturnType.ReturnMessage = "User details have not been saved.";
                }
            }
            return messageReturnType;
        }

        public DataTable UsersList(int userId)
        {
            string query = "SELECT * from dbo.UsersRegistration AS ur JOIN dbo.UsersLogin AS ul ON ur.RegistrationId=ul.RegistrationId WHERE UserId=@userId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@userId",userId),
            };
            DataTable dataTable = dataAdaptor.FetchData(query, sqlParameters, false);
           
            return dataTable;
        }
    }
}