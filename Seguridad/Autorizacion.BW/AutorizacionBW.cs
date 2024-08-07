using Autorizacion.Abstracciones.BW;
using Autorizacion.Abstracciones.DA;
using Autorizacion.Abstracciones.Entidades;

namespace Autorizacion.BW
{
    public class AutorizacionBW : IAutorizacionBW
    {
        private ISeguridadDA _seguridadDA;

        public AutorizacionBW(ISeguridadDA seguridadDA)
        {
            _seguridadDA = seguridadDA;
        }

        public async Task<IEnumerable<Rol>> ObtenerPerfilesxUsuario(Autorizacion.Abstracciones.Modelos.Usuario usuario)
        {
            return await _seguridadDA.ObtenerPerfilesxUsuario(usuario);
        }

        public async Task<Autorizacion.Abstracciones.Modelos.Usuario> ObtenerUsuario(Autorizacion.Abstracciones.Modelos.Usuario usuario)
        {
            return await _seguridadDA.ObtenerUsuario(usuario);
        }
    }
}
