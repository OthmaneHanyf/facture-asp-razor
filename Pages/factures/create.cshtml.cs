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
    public class createModel : PageModel
    {
        private readonly FactureDummyDb _db;

        public createModel(FactureDummyDb db)
        {
            _db = db;
        }

        [BindProperty]
        public FactureDto facture {get; set;}

        public ActionResult OnPost()
        {
            if (ModelState.IsValid) {
                Facture newFacture = new Facture(){
                    factureNumber = _db.factures.Count() + 1,
                    designation = facture.designation,
                    prix = facture.prix,
                    quantite = facture.quantite,
                    tva = facture.tva,
                    reference = facture.reference,
                };

                _db.factures.Add(newFacture);

                return RedirectToPage("index");
            } else {
                return Page();
            }
        }
    }
}
