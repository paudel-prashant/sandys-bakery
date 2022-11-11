using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandysBakery.DataAccess.Adaptors
{
    public interface IDataAdaptor
    {
        DataTable FetchData(string query, SqlParameter[] param, bool Isproc);
        int ExecuteQuery(string query, SqlParameter[] param, bool Isproc);
        int ExecuteQuery(string query, SqlParameter[] param, bool Isproc, ref int primaryKey);
        string GetDbConnection { get; }
    }
}
