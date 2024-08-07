using Autorizacion.Abstracciones.BW;
using Autorizacion.Abstracciones.Entidades;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Autorizacion.Middleware
{
    public class ClaimsPerfiles
    {
        private readonly RequestDelegate _next;

        private readonly IConfiguration _configuration;

        private IAutorizacionBW _autorizacionBW;

        public ClaimsPerfiles(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext, IAutorizacionBW autorizacionBW)
        {
            _autorizacionBW = autorizacionBW;

            ClaimsIdentity appIdentity = await verificarAutorizacion(httpContext);

            httpContext.User.AddIdentity(appIdentity);

            await _next(httpContext);
        }

        private async Task<ClaimsIdentity> verificarAutorizacion(HttpContext httpContext)
        {
            var claims = new List<Claim>();

            if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
            {
                await ObtenerUsuario(httpContext, claims);
                await ObtenerPerfiles(httpContext, claims);
            }

            var appIdentity = new ClaimsIdentity(claims);

            return appIdentity;
        }

        private async Task ObtenerPerfiles(HttpContext httpContext, List<Claim> claims)
        {
            var perfiles = await obtenerInformacionPerfiles(httpContext);

            if (perfiles != null && perfiles.Any())
            {
                foreach (var perfil in perfiles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, perfil.Id.ToString()));
                }
            }
        }

        private async Task<IEnumerable<Rol>> obtenerInformacionPerfiles(HttpContext httpContext)
        {
            return await _autorizacionBW.ObtenerPerfilesxUsuario(new Autorizacion.Abstracciones.Modelos.Usuario
            {
                Corrreo = httpContext.User.Claims.
                Where(c => c.Type == "usuario").FirstOrDefault().Value
            });
        }

        private async Task ObtenerUsuario(HttpContext httpContext, List<Claim> claims)
        {
            var usuario = await obtenerInformacionUsuario(httpContext);

            if (usuario is not null && !string.IsNullOrEmpty(usuario.IdPersona.ToString()) && !string.IsNullOrEmpty(usuario.Corrreo.ToString()))
            {
                claims.Add(new Claim(ClaimTypes.Email, usuario.Corrreo));
                claims.Add(new Claim("IdPersona", usuario.IdPersona.ToString()));
            }
        }

        private async Task<Autorizacion.Abstracciones.Modelos.Usuario> obtenerInformacionUsuario(HttpContext httpContext)
        {
            return await _autorizacionBW.ObtenerUsuario(new Autorizacion.Abstracciones.Modelos.Usuario
            {
                Corrreo = httpContext.User.Claims.Where(c => c.Type == "usuario").FirstOrDefault().Value
            });
        }
    }
    public static class ClaimsUsuarioMiddlewareExtensions
    {
        public static IApplicationBuilder AutorizacionClaims(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClaimsPerfiles>();
        }
    }
}