using Autorizacion.Abstracciones.DA;
using Autorizacion.Abstracciones.Entidades;
using System.Data.SqlClient;
using Dapper;

namespace Autorizacion.DA
{
    public class SeguridadDA : ISeguridadDA
    {
        IRepositorioDapper _repositorioDapper;

        private SqlConnection _sqlConnection;

        public SeguridadDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<IEnumerable<Rol>> ObtenerPerfilesxUsuario(Autorizacion.Abstracciones.Modelos.Usuario usuario)
        {
            string query = @"Obtener_PerfilesxUsuario";

            var consulta = await _sqlConnection.QueryAsync<Rol>(query, new
            {
                Correo = usuario.Corrreo
            });

            return consulta;
        }

        public async Task<Autorizacion.Abstracciones.Modelos.Usuario> ObtenerUsuario(Autorizacion.Abstracciones.Modelos.Usuario usuario)
        {
            string query = @"Obtener_Usuario";

            var consulta = await _sqlConnection.QueryAsync<Autorizacion.Abstracciones.Modelos.Usuario>(query, new
            {
                Correo = usuario.Corrreo
            });

            return consulta.FirstOrDefault();
        }
    }
}