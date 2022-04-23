using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using facture.Dtos;
using facture.Data;

namespace facture.Pages.factures
{
    public class indexModel : PageModel
    {
        private readonly FactureDummyDb _db;

        public indexModel(FactureDummyDb db)
        {
            _db = db;
        }

        public IList<FactureDto> factureList {get; set;}

        public void OnGet()
        {
            factureList = new List<FactureDto>();

            foreach (var facture in _db.factures)
            {
                FactureDto tmpFacture = new FactureDto {
                    factureNumber = facture.factureNumber,
                    designation = facture.designation,
                    prix = facture.prix,
                    quantite = facture.quantite,
                    tva = facture.tva,
                    reference = facture.reference,
                    montantHt = facture.prix * facture.quantite,
                    montantTva = facture.prix * facture.quantite * facture.tva / 100,
                    montantTtc = facture.prix * facture.quantite * ((double)facture.tva / 100 + 1),
                };

                factureList.Add(tmpFacture);
            }

        }

        public ActionResult OnPostDelete(int id) {
            var facture = _db.factures.Find(f => (int)f.factureNumber == id);
            _db.factures.Remove(facture);
            
            return RedirectToPage("index");
        }
    }
}
