using System.ComponentModel.DataAnnotations;
using facture.Models;

namespace facture.Dtos
{
    public class FactureDto
    {
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

        public double montantHt {get;set;}
        
        public double montantTva {get;set;}

        public double montantTtc {get;set;}

        [Required]
        public int clientId {get; set;}

        [Required]
        public string raisonSociale {get;set;}

        [Required]
        public int idFiscal {get;set;}

        [Required]
        public long idCommunEntreprise {get;set;}

    }
}