using System.ComponentModel.DataAnnotations;

namespace facture.Models
{
    public class Facture
    {
        [Key]
        public int factureNumber {get;set;}
        
        [Required]
        public string designation {get;set;}

        [Required]
        
        public string reference {get;set;}
        [Required]
        
        public int quantite {get;set;}
        
        [Required]
        public double prix {get;set;}
        
        [Required]
        public int tva {get;set;}

        [Required]
        public int clientId {set; get;}
        public Client client;

        [Required]
        public string raisonSociale {get;set;}
        
    }
}