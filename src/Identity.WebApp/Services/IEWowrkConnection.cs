using SqlKata;
using SqlKata.Compilers;
using System.Data.SqlClient;

namespace Identity.WebApp.Services
{
    public interface IEWorkConnection
    {
        SqlConnection Connection { get; }
        SqlServerCompiler Compiler { get; }

        Query Query(string table);
    }
}