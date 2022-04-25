using System.ComponentModel.DataAnnotations;

namespace facture.Models
{
    public class Client
    {
        [Key]
        public int id {set; get;}
        [Required(ErrorMessage = "Cette Champ est obligatoire")]
        public string raisonSociale {set; get;}
        public string typeSociete {set; get;}
        [Required(ErrorMessage = "Cette Champ est obligatoire")]
        public int idFiscal {set; get;}
        [Required(ErrorMessage = "Cette Champ est obligatoire")]
        public int registreCommerce {set; get;}
        public int patente {set; get;}
        [Required(ErrorMessage = "Cette Champ est obligatoire")]
        public int idCommunEntreprise {set; get;}
        public string nomRespo {set; get;}
        public string nom {set; get;}
        public string prenom {set; get;}
        public string email {set; get;}
        public string tel {set; get;}
        public string adresse {set; get;}
        public string fax {set; get;}
        public string portable {set; get;}
        public string ville {set; get;}
        public string pays {set; get;}
    }
}