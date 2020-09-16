using AppDDDProject.Domain.Services;

namespace AppDDDProject.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Enviar(string to, string email, string subject, string body)
        {
            // Envia email
        }
    }
}