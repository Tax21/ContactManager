using ContactManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public static void Initialize(ApplicationDbContext context)
        {
            // Seed des catégories
            if (!context.Categories.Any())
            {
                var categories = new List<Categorie>
        {
            new Categorie { Nom = "Famille" },
            new Categorie { Nom = "Ami" },
            new Categorie { Nom = "Travail" },
            new Categorie { Nom = "Autre" }
        };

                context.Categories.AddRange(categories);
                context.SaveChanges();

                // Vérifier si la table Contacts est vide
                if (!context.Contacts.Any())
                {
                    // Récupérer la première catégorie après l'ajout
                    var firstCategory = categories.First();

                    // Seed des contacts
                    context.Contacts.AddRange(
                        new Contact
                        {
                            Nom = "Dupont",
                            Prenom = "John",
                            Telephone = "123-456-7890",
                            Courriel = "john.dupont@example.com",
                            DateCreation = DateTime.Today,
                            CategorieID = firstCategory.CategorieID // Utiliser la première catégorie (Famille)
                        },
                        new Contact
                        {
                            Nom = "Martin",
                            Prenom = "Mystere",
                            Telephone = "987-612-3210",
                            Courriel = "sophie.mystere@example.com",
                            DateCreation = DateTime.Today,
                            CategorieID = firstCategory.CategorieID // Utiliser la première catégorie (Famille)
                        });
                    // Ajoutez d'autres contacts selon vos besoins
                    context.SaveChanges();
                }
            }
        }
    }
}
