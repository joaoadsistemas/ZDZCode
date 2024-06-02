using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ZDZCode.API.Entities;

namespace ZDZCode.API.Context
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
        {
            // DOCKER APLICAR MIGRATIONS
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ///////
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Rent> Rents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var hotel1 = Guid.NewGuid();
            var hotel2 = Guid.NewGuid();
            var hotel3 = Guid.NewGuid();
            var hotel4 = Guid.NewGuid();


            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = hotel1,
                    Name = "Sunset Paradise Resort",
                    Description =
                        "Desfrute de um oásis tropical no Sunset Paradise Resort. Com vistas deslumbrantes para o mar e praias de areia branca, este resort oferece a escapada perfeita para relaxamento e diversão.",
                    ImgsUrl = new List<string>
                    {
                        "https://images.pexels.com/photos/189296/pexels-photo-189296.jpeg?auto=compress&cs=tinysrgb&w=600",
                        "https://images.pexels.com/photos/258154/pexels-photo-258154.jpeg?auto=compress&cs=tinysrgb&w=600"
                    },

                },
                new Hotel
                {
                    Id = hotel2,
                    Name = "Mystic Mountain Lodge",
                    Description =
                        "Entre na mística e explore a beleza natural do Mystic Mountain Lodge. Situado entre as majestosas montanhas, este lodge oferece uma experiência única em harmonia com a natureza.",
                    ImgsUrl = new List<string>
                    {
                        "https://images.pexels.com/photos/338504/pexels-photo-338504.jpeg?auto=compress&cs=tinysrgb&w=600",
                        "https://images.pexels.com/photos/2034335/pexels-photo-2034335.jpeg?auto=compress&cs=tinysrgb&w=600"
                    },

                },
                new Hotel
                {
                    Id = hotel3,
                    Name = "Eternal Garden Retreat",
                    Description =
                        "Perca-se nos jardins eternos do Eternal Garden Retreat. Com sua atmosfera serena e paisagens exuberantes, este retiro é um refúgio para a alma em busca de paz e tranquilidade.",
                    ImgsUrl = new List<string>
                    {
                        "https://images.pexels.com/photos/1134176/pexels-photo-1134176.jpeg?auto=compress&cs=tinysrgb&w=600",
                        "https://images.pexels.com/photos/2096983/pexels-photo-2096983.jpeg?auto=compress&cs=tinysrgb&w=600"
                    },

                },
                new Hotel
                {
                    Id = hotel4,
                    Name = "Golden Sands Resort",
                    Description =
                        "Descubra o luxo e o conforto no Golden Sands Resort. Com praias douradas e instalações de primeira classe, este resort oferece uma experiência inesquecível para os viajantes exigentes.",
                    ImgsUrl = new List<string>
                    {
                        "https://images.pexels.com/photos/594077/pexels-photo-594077.jpeg?auto=compress&cs=tinysrgb&w=600",
                        "https://images.pexels.com/photos/1838554/pexels-photo-1838554.jpeg?auto=compress&cs=tinysrgb&w=600"
                    },

                });

                var person1 = Guid.NewGuid();
            var person2 = Guid.NewGuid();
            var person3 = Guid.NewGuid();
            var person4 = Guid.NewGuid();
            var person5 = Guid.NewGuid();
            var person6 = Guid.NewGuid();
            var person7 = Guid.NewGuid();
            var person8 = Guid.NewGuid();
            var person9 = Guid.NewGuid();
            var person10 = Guid.NewGuid();

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = person1,
                    Name = "João",
                    LastName = "Silva",
                    Phone = "123456789",
                    CPF = "123.456.789-00",
                    Email = "joao@example.com",
                },
                new Person
                {
                    Id = person2,
                    Name = "Maria",
                    LastName = "Santos",
                    Phone = "987654321",
                    CPF = "987.654.321-00",
                    Email = "maria@example.com",
                },
                new Person
                {
                    Id = person3,
                    Name = "Carlos",
                    LastName = "Souza",
                    Phone = "111222333",
                    CPF = "111.222.333-00",
                    Email = "carlos@example.com",
                },
                new Person
                {
                    Id = person4,
                    Name = "Ana",
                    LastName = "Oliveira",
                    Phone = "444555666",
                    CPF = "444.555.666-00",
                    Email = "ana@example.com",
                },
                new Person
                {
                    Id = person5,
                    Name = "Pedro",
                    LastName = "Rodrigues",
                    Phone = "777888999",
                    CPF = "777.888.999-00",
                    Email = "pedro@example.com",
                },
                new Person
                {
                    Id = person6,
                    Name = "Laura",
                    LastName = "Costa",
                    Phone = "222333444",
                    CPF = "222.333.444-00",
                    Email = "laura@example.com",
                },
                new Person
                {
                    Id = person7,
                    Name = "Fernando",
                    LastName = "Martins",
                    Phone = "555666777",
                    CPF = "555.666.777-00",
                    Email = "fernando@example.com",
                },
                new Person
                {
                    Id = person8,
                    Name = "Mariana",
                    LastName = "Pereira",
                    Phone = "888999000",
                    CPF = "888.999.000-00",
                    Email = "mariana@example.com",
                },
                new Person
                {
                    Id = person9,
                    Name = "Gabriel",
                    LastName = "Almeida",
                    Phone = "999000111",
                    CPF = "999.000.111-00",
                    Email = "gabriel@example.com",
                },
                new Person
                {
                    Id = person10,
                    Name = "Juliana",
                    LastName = "Lima",
                    Phone = "123123123",
                    CPF = "123.123.123-00",
                    Email = "juliana@example.com",
                });


                var rent1 = Guid.NewGuid();
            var rent2 = Guid.NewGuid();
            var rent3 = Guid.NewGuid();
            var rent4 = Guid.NewGuid();
            var rent5 = Guid.NewGuid();
            var rent6 = Guid.NewGuid();
            var rent7 = Guid.NewGuid();
            var rent8 = Guid.NewGuid();
            var rent9 = Guid.NewGuid();
            var rent10 = Guid.NewGuid();

            modelBuilder.Entity<Rent>().HasData(
                new Rent
                {
                    HotelId = hotel1,
                    PersonId = person1,
                    EntryDate = DateTimeOffset.UtcNow,
                    DepartureDate = DateTimeOffset.UtcNow.AddDays(5),
                },
                new Rent
                {
                    HotelId = hotel2,
                    PersonId = person2,
                    EntryDate = DateTimeOffset.UtcNow.AddDays(3),
                    DepartureDate = DateTimeOffset.UtcNow.AddDays(8),
                },
                new Rent
                {
                    HotelId = hotel3,
                    PersonId = person3,
                    EntryDate = DateTimeOffset.UtcNow.AddDays(2),
                    DepartureDate = DateTimeOffset.UtcNow.AddDays(6),
                },
                new Rent
                {
                    HotelId = hotel4,
                    PersonId = person4,
                    EntryDate = DateTimeOffset.UtcNow.AddDays(1),
                    DepartureDate = DateTimeOffset.UtcNow.AddDays(7),
                },
                new Rent
                {
                    HotelId = hotel1,
                    PersonId = person5,
                    EntryDate = DateTimeOffset.UtcNow.AddDays(4),
                    DepartureDate = DateTimeOffset.UtcNow.AddDays(9),
                },
                new Rent
                {
                    HotelId = hotel2,
                    PersonId = person6,
                    EntryDate = DateTimeOffset.UtcNow.AddDays(6),
                    DepartureDate = DateTimeOffset.UtcNow.AddDays(11),
                },
                new Rent
                {
                    HotelId = hotel3,
                    PersonId = person7,
                    EntryDate = DateTimeOffset.UtcNow.AddDays(7),
                    DepartureDate = DateTimeOffset.UtcNow.AddDays(12),
                },
                new Rent
                {
                    HotelId = hotel4,
                    PersonId = person8,
                    EntryDate = DateTimeOffset.UtcNow.AddDays(8),
                    DepartureDate = DateTimeOffset.UtcNow.AddDays(13),
                },
                new Rent
                {
                    HotelId = hotel1,
                    PersonId = person9,
                    EntryDate = DateTimeOffset.UtcNow.AddDays(5),
                    DepartureDate = DateTimeOffset.UtcNow.AddDays(10),
                },
                new Rent
                {
                    HotelId = hotel2,
                    PersonId = person10,
                    EntryDate = DateTimeOffset.UtcNow.AddDays(9),
                    DepartureDate = DateTimeOffset.UtcNow.AddDays(14),
                }


            );



            modelBuilder.Entity<Rent>().HasKey(r => new { r.HotelId, r.PersonId });

            modelBuilder.Entity<Rent>().HasOne(r => r.Hotel)
                .WithMany(h => h.Rents)
                .HasForeignKey(r => r.HotelId);


            modelBuilder.Entity<Rent>().HasOne(r => r.Person)
                .WithOne(p => p.Rent);

        }
    }
}
