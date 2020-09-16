namespace AppDDDProject.Domain.Services
{
    public interface IEmailService
    {
        void Enviar(string to, string email, string subject, string body);
    }
}