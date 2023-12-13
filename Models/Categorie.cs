using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Categorie
    {
        public int CategorieID { get; set; } // PK

        [Required(ErrorMessage = "Le champ Nom est obligatoire.")]
        public string Nom { get; set; }

        //========================= Navigation Properties =================================
        public ICollection<Contact>? Contacts { get; set; }
    }
}
