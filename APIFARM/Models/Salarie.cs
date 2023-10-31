
using APIFARM.Data;
namespace APIFARM.Models
{
    public class Salarie
    {
        public int Id { get; set; } // Identifiant unique pour chaque salarié
        public string Nom { get; set; } // Nom du salarié
        public string Prenom { get; set; } // Prénom du salarié
        public string TelephoneFixe { get; set; } // Numéro de téléphone fixe du salarié
        public string TelephonePortable { get; set; } // Numéro de téléphone portable du salarié
        public string Email { get; set; } // Adresse e-mail du salarié
        public string Service { get; set; } // Service auquel appartient le salarié (ex: comptabilité, production, etc.)
        public string Site { get; set; } // Site de travail du salarié (ex: Paris, Nantes, etc.)
    }
}
