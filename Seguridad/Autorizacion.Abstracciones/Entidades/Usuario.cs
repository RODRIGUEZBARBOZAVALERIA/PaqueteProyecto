namespace Autorizacion.Abstracciones.Entidades
{
    public class Usuario
    {
        public Guid IdPersona { get; set; }
        public string? Hash { get; set; }
    }
}
