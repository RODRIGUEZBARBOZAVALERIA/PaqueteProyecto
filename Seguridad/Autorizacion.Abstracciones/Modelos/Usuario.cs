namespace Autorizacion.Abstracciones.Modelos
{
    public class Usuario
    {
        public Guid? IdPersona { get; set; }
        public string? Corrreo { get; set; }
        public string? Hash { get; set; }
    }
}
