using Humanizer.Localisation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Contact
    {
        public int ContactID { get; set; } // PK

        [Required(ErrorMessage = "Le champ Nom est obligatoire.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prénom est obligatoire.")]
        public string Prenom { get; set; }

        public string? Addresse { get; set; }

        public string? Ville { get; set; }

        public string? Province { get; set; }

        public string? CodePostal { get; set; }

        [Required(ErrorMessage = "Le champ Téléphone est obligatoire.")]
        [Phone(ErrorMessage = "Le champ Téléphone doit être un numéro de téléphone valide.")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Le champ Courriel est obligatoire.")]
        [EmailAddress(ErrorMessage = "Le champ Courriel doit être une adresse e-mail valide.")]
        public string Courriel { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreation { get; set; }

        [Display(Name = "Categorie")]
        public int? CategorieID { get; set; }

        [StringLength(450)]
        public string? UserID { get; set; } //Relation a ASPNET_USERS (Id)

        //========================= Navigation Properties =================================
        public Categorie? Categorie { get; set; }//A Contact can only belong at most to one Categorie 
    }
}
