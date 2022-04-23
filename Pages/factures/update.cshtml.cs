using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using facture.Data;
using facture.Dtos;
using facture.Models;

namespace facture.Pages.factures
{


    public class updateModel : PageModel
    {
        private readonly FactureDummyDb _db;

        public updateModel(FactureDummyDb db)
        {
            _db = db;
        }

        [BindProperty]
        public FactureDto facture {get; set;}

        public ActionResult OnGet(int id)
        {
            var f = _db.factures.Find(f => f.factureNumber == id);
            if (f == null) {
                return RedirectToPage("Error");
            } else {
                facture = new FactureDto{
                    factureNumber = f.factureNumber,
                    designation = f.designation,
                    prix = f.prix,
                    quantite = f.quantite,
                    tva = f.tva,
                    reference = f.reference,
                };
                return Page();
            }
        }

        public ActionResult OnPost(int id)
        {
            Console.WriteLine(id);
            if (ModelState.IsValid) {

                Facture fac = _db.factures.Find(f => f.factureNumber == id);
                
                _db.factures.Remove(fac);

                _db.factures.Add(new Facture(){
                    factureNumber = facture.factureNumber,
                    designation = facture.designation,
                    prix = facture.prix,
                    quantite = facture.quantite,
                    tva = facture.tva,
                    reference = facture.reference,
                });

                return RedirectToPage("index");
            } else {
                return Page();
            }
        }
    }
}
