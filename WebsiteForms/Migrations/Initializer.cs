using WebsiteForms.Database.Entities;
using WebsiteForms.Helpers;

namespace WebsiteForms.Migrations
{
    public static class Initializer
    {
        private static readonly List<RequestType> _requestTypes = new()
        {
            new RequestType()
            {
                Name = "Paz y salvo",
            },
            new RequestType()
            {
                Name = "Levantamientos de prenda",
            },
            new RequestType()
            {
                Name = "Certificaciones",
            },
            new RequestType()
            {
                Name = "Reestructuraciones",
            },
            new RequestType()
            {
                Name = "Cambio de fecha",
            },
            new RequestType()
            {
                Name = "Siniestros",
            },
            new RequestType()
            {
                Name = "Cambio de vehiculo",
            },
            new RequestType()
            {
                Name = "Cambios al vehiculo",
            },
            new RequestType()
            {
                Name = "Solicitud documentos de desembolsos",
            },
            new RequestType()
            {
                Name = "Liquidacion total",
            },
            new RequestType()
            {
                Name = "Subragaciones",
            },
            new RequestType()
            {
                Name = "Tramites de seguros",
            },
            new RequestType()
            {
                Name = "Peticiones, quejas y reclamos",
            },
        };
        private static readonly List<User> _users = new()
        {
            new User()
            {
                Username = "Finanzauto",
                Password = Hashing.HashString("Admin"),
            }
        };

        public static IEnumerable<RequestType> GetRequestTypes() => _requestTypes;
        public static IEnumerable<User> GetUsers() => _users;
    }
}
