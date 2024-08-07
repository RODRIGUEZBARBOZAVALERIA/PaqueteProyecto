using Autorizacion.Abstracciones.DA;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Autorizacion.DA.Repositorios
{
    public class RepositorioDapper : IRepositorioDapper
    {
        private readonly IConfiguration _configuration;

        private SqlConnection _connection;

        public RepositorioDapper(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("BDProyecto"));
        }

        public SqlConnection ObtenerRepositorioDapper()
        {
            return _connection;
        }
    }
}
