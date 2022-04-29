using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using facture.Dtos;
using facture.Data;
using System.Text;
using facture.Models;

namespace facture.Pages.factures
{
    public class indexModel : PageModel
    {
        private readonly FactureDbContext _db;

        public indexModel(FactureDbContext db)
        {
            _db = db;
        }

        public IList<FactureDto> factureList {get; set;}

        public void OnGet()
        {
            factureList = new List<FactureDto>();

            foreach (var facture in _db.Factures.AsEnumerable())
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
                    clientId = facture.clientId,
                };

                factureList.Add(tmpFacture);
            }

        }

        public IActionResult OnPostExportCSV() {
            var builder = new StringBuilder();
            builder.AppendLine("Facture N,Client RS,Designation,Reference,Prix,Quantite,TVA,Montant HT,Montant TVA,Montant TTC");
            foreach (var f in _db.Factures.ToList<Facture>()){
                builder.AppendLine($"{f.factureNumber},{f.raisonSociale},{f.designation},{f.reference},{f.prix},{f.quantite},{f.tva},{f.prix * f.quantite},{f.prix * f.quantite * f.tva / 100},{f.prix * f.quantite * ((double)f.tva / 100 + 1)}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "facture.csv");
        }

        public async Task<ActionResult> OnPostDelete(int id) {
            var facture = await _db.Factures.FindAsync(id);
            _db.Factures.Remove(facture);
            await _db.SaveChangesAsync();
            
            return RedirectToPage("index");
        }
    }
}
