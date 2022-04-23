using System.Collections.Generic;
using facture.Data;
using facture.Dtos;
using facture.Models;

namespace facture.Repositories
{
    public class FactureRepository {

        public int factureNumber {get;set;}
        
        public string designation {get;set;}
        
        public string reference {get;set;}
        
        public int quantite {get;set;}
        
        public double prix {get;set;}
        
        public int tva {get;set;}

        public double montantHt {get;set;}
        
        public double montantTva {get;set;}

        public double montantTtc {get;set;}

        private readonly FactureDummyDb _db;

        public FactureRepository(FactureDummyDb db)
        {
            _db = db;
        }

        public List<FactureDto> ToList() {
            List<FactureDto> factureList = new List<FactureDto>();

            foreach (var facture in _db.factures)
            {
                FactureDto tmpFacture = new FactureDto {
                    designation = facture.designation,
                    prix = facture.prix,
                    quantite = facture.quantite,
                    tva = facture.tva,
                    reference = facture.reference,
                    montantHt = facture.prix * facture.quantite,
                    montantTva = facture.prix * facture.quantite * facture.tva,
                    montantTtc = facture.prix * facture.quantite * (facture.tva + 1),
                };

                factureList.Add(tmpFacture);
            }
            return factureList;
        }

    }
}