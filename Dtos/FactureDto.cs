using System.ComponentModel.DataAnnotations;
namespace facture.Dtos
{
    public class FactureDto {
        public int factureNumber {get;set;}

        [Required]
        public string designation {get;set;}
        
        public string reference {get;set;}
        
        public int quantite {get;set;}
        
        public double prix {get;set;}
        
        public int tva {get;set;}

        public double montantHt {get;set;}
        
        public double montantTva {get;set;}

        public double montantTtc {get;set;}
    }
}