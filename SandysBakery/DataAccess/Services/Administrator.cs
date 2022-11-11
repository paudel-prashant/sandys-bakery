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
    public class Administrator : IAdministrator
    {
        IDataAdaptor dataAdaptor;
        MessageReturnType messageReturnType = null;

        public Administrator()
        {
            dataAdaptor = new DataAdaptor();
            messageReturnType = new MessageReturnType();
        }
        public MessageReturnType AddCategory(ProductCategories productCategories)
        {
            try
            {
                string query = "INSERT INTO dbo.ProductCategories(CategoryName,CategoryStatus)VALUES(@CategoryName, 1) ";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                 new SqlParameter("@CategoryName",productCategories.CategoryName)
                };
                dataAdaptor.ExecuteQuery(query, sqlParameters, false);
                messageReturnType.IsSuccess = true;
                messageReturnType.ReturnMessage = "Category has successfully been added.";
            }
            catch (Exception ex)
            {
                messageReturnType.IsSuccess = false;
                messageReturnType.ReturnMessage = "Category has not been added.";
            }
            return messageReturnType;
        }

        public MessageReturnType EditCategory(ProductCategories productCategories)
        {
            try
            {
                string query = "UPDATE dbo.ProductCategories SET CategoryName=@CategoryName WHERE ProductCategoriesId=@ProductCategoriesId";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@ProductCategoriesId",productCategories.ProductCategoriesId),
                    new SqlParameter("@CategoryName",productCategories.CategoryName)
                };
                dataAdaptor.ExecuteQuery(query, sqlParameters, false);
                messageReturnType.IsSuccess = true;
                messageReturnType.ReturnMessage = "Category has successfully been updated.";
            }
            catch (Exception ex)
            {
                messageReturnType.IsSuccess = false;
                messageReturnType.ReturnMessage = "Category has not been saved.";
            }
            return messageReturnType;
        }

        public ProductCategories GetProductCategoryById(int categoryId)
        {
            MessageReturnType messageReturnType = new MessageReturnType();
            string query = "SELECT * FROM dbo.ProductCategories AS pc WHERE pc.ProductCategoriesId=@ProductCategoriesId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ProductCategoriesId", categoryId),
            };
            DataTable dataTable = dataAdaptor.FetchData(query, sqlParameters, false);
            ProductCategories productCategories = new Helper().DataTableToListof<ProductCategories>(dataTable).FirstOrDefault();
            return productCategories;
        }

        public DataTable ProductCategoriesList()
        {
            string query = "SELECT ProductCategoriesId,CategoryName FROM dbo.ProductCategories WHERE CategoryStatus=1";
            DataTable dataTable = dataAdaptor.FetchData(query, null, false);
            return dataTable;

        }
        public MessageReturnType AddProduct(ProductItems productItems)
        {
            try
            {
                string query = "INSERT INTO dbo.ProductItems(ProductCategoriesId,ItemName,SellingPrice,ImagePath,FileName,Description)VALUES(@ProductCategoriesId,@ItemName,@SellingPrice,@ImagePath,@FileName,@Description) ";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                     new SqlParameter("@ProductCategoriesId",productItems.ProductCategoriesId),
                     new SqlParameter("@ItemName",productItems.ItemName),
                     new SqlParameter("@SellingPrice",productItems.SellingPrice),
                     new SqlParameter("@ImagePath",productItems.ImagePath),
                     new SqlParameter("@FileName",productItems.FileName),
                     new SqlParameter("@Description",productItems.Description)
                };
                dataAdaptor.ExecuteQuery(query, sqlParameters, false);
                messageReturnType.IsSuccess = true;
                messageReturnType.ReturnMessage = "Product has successfully been added.";
            }
            catch (Exception ex)
            {
                messageReturnType.IsSuccess = false;
                messageReturnType.ReturnMessage = "Product has not been saved.";
            }
            return messageReturnType;
        }
        public MessageReturnType EditProduct(ProductItems productItems)
        {
            try
            {
                string query = "UPDATE dbo.ProductItems SET ProductCategoriesId=@ProductCategoriesId,ItemName=@ItemName,SellingPrice=@SellingPrice,ImagePath=@ImagePath,FileName=@FileName,Description=@Description WHERE ProductItemsId=@ProductItemsId";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@ProductItemsId",productItems.ProductItemsId),
                    new SqlParameter("@ProductCategoriesId",productItems.ProductCategoriesId),
                    new SqlParameter("@ItemName",productItems.ItemName),
                    new SqlParameter("@SellingPrice",productItems.SellingPrice),
                    new SqlParameter("@FileName",productItems.FileName),
                    new SqlParameter("@ImagePath",productItems.ImagePath),
                    new SqlParameter("@Description",productItems.Description)
                };
                dataAdaptor.ExecuteQuery(query, sqlParameters, false);
                messageReturnType.IsSuccess = true;
                messageReturnType.ReturnMessage = "Product has successfully been updated.";
            }
            catch (Exception ex)
            {
                messageReturnType.IsSuccess = false;
                messageReturnType.ReturnMessage = "Product has not been saved.";
            }
            return messageReturnType;
        }
        public ProductItems GetProductById(int productId)
        {
            string query = "SELECT * FROM dbo.ProductItems AS p WHERE p.ProductItemsId=@ProductItemsId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ProductItemsId",productId),
            };
            DataTable dataTable = dataAdaptor.FetchData(query, sqlParameters, false);
            ProductItems productItems = new Helper().DataTableToListof<ProductItems>(dataTable).FirstOrDefault();
            return productItems;
        }
        public DataTable ProductList()
        {
            string query = "SELECT * FROM dbo.ProductItems AS pi JOIN dbo.ProductCategories AS pc ON pc.ProductCategoriesId = pi.ProductCategoriesId";
            DataTable dataTable = dataAdaptor.FetchData(query, null, false);
            return dataTable;
        }
        public List<ProductItems> ProductItemsPerCategoryById(int categoryById)
        {
            string sql = "SELECT pi.ProductItemsId, pi.ItemName,pi.SellingPrice,pi.ImagePath,pi.Description FROM dbo.ProductItems AS pi where 1=1";
            if (categoryById != 0)
            {
                sql += "and pi.ProductCategoriesId=" + categoryById;
            }
            DataTable dataTable = dataAdaptor.FetchData(sql, null, false);
            var product = new Helper().DataTableToListof<ProductItems>(dataTable);
            return product;
        }
        public ProductItems ProductItemById(int ProductItemsId)
        {
            string sql = "SELECT pi.ProductItemsId, pi.ItemName,pi.SellingPrice,pi.ImagePath,pi.Description FROM dbo.ProductItems AS pi where ProductItemsId=@ProductItemsId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ProductItemsId",ProductItemsId),
            };
            DataTable dataTable = dataAdaptor.FetchData(sql, sqlParameters, false);
            var product = new Helper().DataTableToListof<ProductItems>(dataTable).FirstOrDefault();
            return product;
        }
        public MessageReturnType AddItemsToCart(CartItems cartItems)
        {
            try
            {
                string query = "INSERT INTO dbo.CartItems(ProductItemsId,Quantity,UserId,AddDate)VALUES(@ProductItemsId,@Quantity,@UserId,@AddDate)";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@ProductItemsId",cartItems.ProductItemsId),
                    new SqlParameter("@Quantity",cartItems.Quantity),
                    new SqlParameter("@UserId",cartItems.UserId),
                    new SqlParameter("@AddDate",DateTime.Now),
                };
                dataAdaptor.ExecuteQuery(query, sqlParameters, false);
                messageReturnType.IsSuccess = true;
                messageReturnType.ReturnMessage = "Item successfully added to cart.";
            }
            catch (Exception ex)
            {
                messageReturnType.IsSuccess = false;
                messageReturnType.ReturnMessage = "Item addition to cart failed.";
            }
            return messageReturnType;
        }
        public MessageReturnType RemoveItemsFromCart(int cartId)
        {
            try
            {
                string query = "DELETE FROM dbo.CartItems WHERE CartId=@CartId";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@CartId",cartId),
                };
                dataAdaptor.ExecuteQuery(query, sqlParameters, false);
                messageReturnType.IsSuccess = true;
                messageReturnType.ReturnMessage = "Removed item from cart successfully.";
            }
            catch (Exception ex)
            {
                messageReturnType.IsSuccess = false;
                messageReturnType.ReturnMessage = "Item not removed from cart.";
            }
            return messageReturnType;
        }
        public DataTable DisplayItemsInCart(int userId)
        {
            string sql = "SELECT ci.CartId, pi.ItemName,pi.SellingPrice,ci.Quantity,ci.AddDate FROM dbo.CartItems AS ci JOIN dbo.ProductItems AS pi ON pi.ProductItemsId = ci.ProductItemsId WHERE ci.UserId=@UserId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserId",userId),
            };
            DataTable dataTable = dataAdaptor.FetchData(sql, sqlParameters, false);
            return dataTable;
        }
        public DataTable CommonStatus(int groupNumber)
        {
            string sql = "SELECT * FROM dbo.CommonStatus AS cs WHERE cs.GroupNumber=@GroupNumber";
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@GroupNumber", groupNumber),
           };
            DataTable dataTable = dataAdaptor.FetchData(sql, sqlParameters, false);
            return dataTable;
        }
        public MessageReturnType AddPaymentOptions(PaymentGateway paymentGateway)
        {
            try
            {
                string query = @"INSERT INTO dbo.PaymentGateway(CardNumber,UserId,ExpiryDate,CardName,PostalCode,SecurityCode,CardTypeId)
                               VALUES(@CardNumber,@UserId,@ExpiryDate,@CardName,@PostalCode,@SecurityCode,@CardTypeId)";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@CardNumber",paymentGateway.CardNumber),
                    new SqlParameter("@UserId",paymentGateway.UserId),
                    new SqlParameter("@ExpiryDate",paymentGateway.ExpiryDate),
                    new SqlParameter("@CardName",paymentGateway.CardName),
                    new SqlParameter("@PostalCode",paymentGateway.PostalCode),
                    new SqlParameter("@SecurityCode",paymentGateway.SecurityCode),
                    new SqlParameter("@CardTypeId",paymentGateway.CardTypeId),
                };
                dataAdaptor.ExecuteQuery(query, sqlParameters, false);
                messageReturnType.IsSuccess = true;
                messageReturnType.ReturnMessage = "Payment option successfully added.";
            }
            catch (Exception ex)
            {
                messageReturnType.IsSuccess = false;
                messageReturnType.ReturnMessage = "Payment option could not be added.";
            }
            return messageReturnType;
        }
        public MessageReturnType EditPaymentOptions(PaymentGateway paymentGateway)
        {
            try
            {
                string query = "UPDATE dbo.PaymentGateway SET CardNumber=@CardNumber,ExpiryDate=@ExpiryDate,CardName=@CardName,SecurityCode=@SecurityCode,CardTypeId=@CardTypeId,PostalCode=@PostalCode WHERE PaymentGatewayId=@PaymentGatewayId";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@CardNumber",paymentGateway.CardNumber),
                    new SqlParameter("@PaymentGatewayId",paymentGateway.PaymentGatewayId),
                    new SqlParameter("@ExpiryDate",paymentGateway.ExpiryDate),
                    new SqlParameter("@CardName",paymentGateway.CardName),
                    new SqlParameter("@SecurityCode",paymentGateway.SecurityCode),
                    new SqlParameter("@CardTypeId",paymentGateway.CardTypeId),
                    new SqlParameter("@PostalCode",paymentGateway.PostalCode)
                };
                dataAdaptor.ExecuteQuery(query, sqlParameters, false);
                messageReturnType.IsSuccess = true;
                messageReturnType.ReturnMessage = "Payment option successfully edited.";
            }
            catch (Exception ex)
            {
                messageReturnType.IsSuccess = false;
                messageReturnType.ReturnMessage = "Payment option could not be edited.";
            }
            return messageReturnType;
        }
        public DataTable PaymentDetailsByUserId(int userId)
        {
            string sql = @"SELECT pg.*,cs.StatusName FROM dbo.PaymentGateway AS 
                         pg JOIN dbo.CommonStatus AS cs ON pg.CardTypeId=cs.CommonStatusId WHERE pg.UserId=@UserId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserId",userId),
            };
            DataTable dataTable = dataAdaptor.FetchData(sql, sqlParameters, false);
            return dataTable;
        }
        public PaymentGateway GetPaymentGatewayById(int paymentGatewayId)
        {
            string sql = "SELECT * FROM dbo.PaymentGateway AS pg WHERE pg.PaymentGatewayId=@PaymentGatewayId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@PaymentGatewayId",paymentGatewayId),
            };
            DataTable dataTable = dataAdaptor.FetchData(sql, sqlParameters, false);
            var payment = new Helper().DataTableToListof<PaymentGateway>(dataTable).FirstOrDefault();
            return payment;
        }
        public MessageReturnType Order(Order order)
        {
            int StatusId = 0;
            if (order.PaymentType.ToLower() == "cash on delivery")
            {
                StatusId = 6;
            }
            else
            {
                StatusId = 3;
            }
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                     new SqlParameter("@PaymentTypeId",order.PaymentTypeId),
                     new SqlParameter("@StatusId",StatusId),
                     new SqlParameter("@PaymentGatewayId",order.PaymentGatewayId),
                     new SqlParameter("@UserId",order.UserId)
                };
                dataAdaptor.ExecuteQuery("dbo.SpCartToOrder", sqlParameters, true);
                messageReturnType.IsSuccess = true;
                messageReturnType.ReturnMessage = "Order has been placed successfully.";
            }
            catch (Exception ex)
            {
                messageReturnType.IsSuccess = false;
                messageReturnType.ReturnMessage = ex.Message;
            }
            return messageReturnType;
        }

        public DataTable DisplayOrderedItems(int userId, string roleName, string requestFrom, DateTime? dateTime = null)
        {
            string query = @"SELECT o.TotalOrderQuantity,o.OrderDate,o.Price,cs.StatusName,cs2.StatusName as ActiveStatus,pg.CardNumber,pi.ItemName,o.OrderId,o.UserId,CONCAT(ur.FirstName,' ',ur.LastName) AS FullName,o.CartDate
                         FROM dbo.[Order] AS o
                         JOIN dbo.CommonStatus AS cs
                         ON cs.CommonStatusId = o.PaymentTypeId
		                 JOIN dbo.CommonStatus AS cs2 ON o.OrderStatusId=cs2.CommonStatusId
		                 JOIN dbo.ProductItems AS pi ON pi.ProductItemsId = o.ProductItemsId 
						 JOIN dbo.UsersLogin AS ul ON ul.UserId = o.UserId
						 JOIN dbo.UsersRegistration AS ur ON ur.RegistrationId = ul.RegistrationId
		                 LEFT JOIN dbo.PaymentGateway AS pg ON pg.PaymentGatewayId = o.PaymentGatewayId where OrderStatusId<>7";
            if (requestFrom == "Dashboard")
            {
                query += "and CAST(o.OrderDate AS DATE)=CAST(GETDATE() AS DATE)";
            }
            else
            {
                if (roleName == "User" || requestFrom == "Admin")
                {
                    query += "and o.UserId=" + userId;
                }
            }
            if (dateTime != null)
            {
                query += "and o.CartDate='" + dateTime + "'";
            }
            DataTable dataTable = dataAdaptor.FetchData(query, null, false);
            return dataTable;
        }
        public MessageReturnType UpdateOrderStatus(int orderId, int orderStatusId)
        {
            try
            {
                string query = "UPDATE dbo.[Order] SET OrderStatusId=@OrderStatusId WHERE OrderId=@OrderId";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@OrderStatusId",orderStatusId),
                    new SqlParameter("@OrderId",orderId),
                };
                dataAdaptor.ExecuteQuery(query, sqlParameters, false);
                messageReturnType.IsSuccess = true;
                messageReturnType.ReturnMessage = "Order status successfully updated.";
            }
            catch (Exception ex)
            {
                messageReturnType.IsSuccess = false;
                messageReturnType.ReturnMessage = "Order status could not be updated.";
            }
            return messageReturnType;
        }
        public MessageReturnType UpdateOrderStatus(DateTime addedDate, int userId, int orderStatusId)
        {
            try
            {
                string query = "UPDATE dbo.[Order] SET OrderStatusId=@OrderStatusId WHERE UserId=@UserId and CartDate=@CartDate";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                     new SqlParameter("@OrderStatusId",orderStatusId),
                     new SqlParameter("@UserId",userId),
                     new SqlParameter("@CartDate",addedDate),
                };
                dataAdaptor.ExecuteQuery(query, sqlParameters, false);
                messageReturnType.IsSuccess = true;
                messageReturnType.ReturnMessage = "Order status successfully updated.";
            }
            catch (Exception ex)
            {
                messageReturnType.IsSuccess = false;
                messageReturnType.ReturnMessage = "Order status could not be updated.";
            }
            return messageReturnType;
        }
        public MessageReturnType AddFeedback(Feedback feedBack)
        {
            try
            {
                string query = @"INSERT INTO dbo.Feedback
                                (
                                    Comment,
                                    FullName,
                                    Email
                                )
                                VALUES
                                (  
                                    @Comment,
                                    @FullName, 
                                    @Email  
                                    ); ";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@Comment",feedBack.Comment),
                    new SqlParameter("@FullName",feedBack.FullName),
                    new SqlParameter("@Email",feedBack.Email)
                };
                dataAdaptor.ExecuteQuery(query, sqlParameters, false);
                messageReturnType.IsSuccess = true;
                messageReturnType.ReturnMessage = "Feedback has been provided successfully.";
            }
            catch (Exception ex)
            {
                messageReturnType.IsSuccess = false;
                messageReturnType.ReturnMessage = "Feedback could not be provided.";
            }
            return messageReturnType;
        }
        public DataTable FeedBackList()
        {
            string sql = @"SELECT f.FeedbackId,      
                           f.Comment,
                           ISNULL(f.FullName, CONCAT(ur.FirstName, ' ', ur.LastName)) AS FullName,
                           ISNULL(f.Email, ur.EmailId) AS Email
                           FROM dbo.Feedback AS f
                           LEFT JOIN dbo.UsersLogin AS ul
                           ON ul.UserId = f.UserId
                           LEFT JOIN dbo.UsersRegistration AS ur
                           ON ur.RegistrationId = ul.RegistrationId; ";
            DataTable dataTable = dataAdaptor.FetchData(sql, null, false);
            return dataTable;
        }
    }
}