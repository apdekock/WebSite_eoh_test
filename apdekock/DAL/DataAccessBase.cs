using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DAL.DataBase.DataAccess;

namespace DAL
{
    public class DataAccessBase
    {
        private readonly ConnectionUtil _connectionUtil = new ConnectionUtil();

        protected readonly DatabaseEntitiesConnection _dbEntities;
        protected DataAccessBase()
        {
            _dbEntities = new DatabaseEntitiesConnection(GetConnectionDefaultString());
        }
        protected DataAccessBase(string connectionString)
        {
            _dbEntities = new DatabaseEntitiesConnection(connectionString);
        }

        protected string GetConnectionDefaultString()
        {
            return _connectionUtil.GetConnectionString(2);
        }
    }
}
