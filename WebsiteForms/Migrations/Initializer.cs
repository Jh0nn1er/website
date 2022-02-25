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
                Id = 1,
                Name = "Paz y salvo",
            },
            new RequestType()
            {
                Id = 2,
                Name = "Levantamientos de prenda",
            },
            new RequestType()
            {
                Id = 3,
                Name = "Certificaciones",
            },
            new RequestType()
            {
                Id = 4,
                Name = "Reestructuraciones",
            },
            new RequestType()
            {
                Id = 5,
                Name = "Cambio de fecha",
            },
            new RequestType()
            {
                Id = 6,
                Name = "Siniestros",
            },
            new RequestType()
            {
                Id = 7,
                Name = "Cambio de vehiculo",
            },
            new RequestType()
            {
                Id = 8,
                Name = "Cambios al vehiculo",
            },
            new RequestType()
            {
                Id = 9,
                Name = "Solicitud documentos de desembolsos",
            },
            new RequestType()
            {
                Id = 10,
                Name = "Liquidacion total",
            },
            new RequestType()
            {
                Id = 11,
                Name = "Subragaciones",
            },
            new RequestType()
            {
                Id = 12,
                Name = "Tramites de seguros",
            },
            new RequestType()
            {
                Id = 13,
                Name = "Peticiones, quejas y reclamos",
            },
        };
        private static readonly List<User> _users = new()
        {
            new User()
            {
                Id = 1,
                Username = "Finanzauto",
                Password = Hashing.HashString("Admin")
            }
        };

        public static IEnumerable<RequestType> GetRequestTypes() => _requestTypes;
        public static IEnumerable<User> GetUsers() => _users;
    }
}
