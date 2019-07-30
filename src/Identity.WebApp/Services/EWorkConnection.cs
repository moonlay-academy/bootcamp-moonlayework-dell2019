using Microsoft.Extensions.Configuration;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data.SqlClient;

namespace Identity.WebApp.Services
{
    public class EWorkConnection : IEWorkConnection
    {
        private readonly QueryFactory _db;

        public EWorkConnection(IConfiguration config)
        {
            Connection = new SqlConnection(config.GetConnectionString("EWorkPlace"));
            Compiler = new SqlServerCompiler();
            _db = new QueryFactory(Connection, Compiler);
        }

        public SqlConnection Connection { get; }

        public SqlServerCompiler Compiler { get; }

        public Query Query(string table)
        {
            return _db.Query(table);
        }

        protected Query Query(Query query)
        {
            return _db.FromQuery(query);
        }
    }
}