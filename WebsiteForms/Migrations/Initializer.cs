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
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 2,
                Name = "Levantamientos de prenda",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 3,
                Name = "Certificaciones",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 4,
                Name = "Reestructuraciones",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 5,
                Name = "Cambio de fecha",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 6,
                Name = "Siniestros",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 7,
                Name = "Cambio de vehiculo",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 8,
                Name = "Cambios al vehiculo",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 9,
                Name = "Solicitud documentos de desembolsos",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 10,
                Name = "Liquidacion total",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 11,
                Name = "Subrogaciones",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 12,
                Name = "Tramites de seguros",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 13,
                Name = "Peticiones, quejas y reclamos",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 14,
                Name = "Contactanos",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 15,
                Name = "Trabaje con nosotros",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 16,
                Name = "Reliquidación",
                CreatedAt = DateTime.Now
            },
            new RequestType()
            {
                Id = 17,
                Name = "Habeas data",
                CreatedAt = DateTime.Now
            },
        };
        private static readonly List<User> _users = new()
        {
            new User()
            {
                Id = 1,
                Username = "Finanzauto",
                Password = Hashing.HashString("F1n-Tr4m1t3s*11"),
                CreatedAt = DateTime.Now
            },
            new User()
            {
                Id = 2,
                Username = "Finanzauto",
                Password = Hashing.HashString("-FZWeb.2022"),
                CreatedAt = DateTime.Now
            },
        };

        public static IEnumerable<RequestType> GetRequestTypes() => _requestTypes;
        public static IEnumerable<User> GetUsers() => _users;
    }
}
