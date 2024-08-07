using Autorizacion.Abstracciones.Entidades;

namespace Autorizacion.Abstracciones.DA
{
    public interface ISeguridadDA
    {
        Task<Autorizacion.Abstracciones.Modelos.Usuario> ObtenerUsuario(Autorizacion.Abstracciones.Modelos.Usuario usuario);
        Task<IEnumerable<Rol>> ObtenerPerfilesxUsuario(Autorizacion.Abstracciones.Modelos.Usuario usuario);
    }
}