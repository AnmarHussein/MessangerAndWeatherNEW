using Core.Domain;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace infra.Domain
{
    public class DBContext : IDBContext
    {
        private DbConnection _dbconction;
        private IConfiguration _configration;
        public DBContext(IConfiguration configration)
        {
            _configration = configration;
        }

        public DbConnection dbConnection
        {
            get
            {
                if (_dbconction == null)
                {
                    _dbconction = new OracleConnection(_configration["ConnectionStrings:DBConnectionString"]);

                    _dbconction.Open();
                }
                else if (_dbconction.State != System.Data.ConnectionState.Open)
                {
                    _dbconction.Open();
                }
                return _dbconction;
            }
        }
    }
}
