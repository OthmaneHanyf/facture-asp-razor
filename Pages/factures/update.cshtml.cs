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
        private readonly FactureDbContext _db;

        public updateModel(FactureDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public FactureDto facture {get; set;}

        public async Task<ActionResult> OnGet(int id)
        {
            var f = await _db.Factures.FindAsync(id);
            if (f == null) {
                return RedirectToPage("Error");
            } else {
                facture = new FactureDto {
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

        public async Task<ActionResult> OnPost(int id)
        {

            if (ModelState.IsValid) {

                Facture fac = await _db.Factures.FindAsync(id);
                
                _db.Factures.Remove(fac);

                await _db.Factures.AddAsync(new Facture(){
                    factureNumber = facture.factureNumber,
                    designation = facture.designation,
                    prix = facture.prix,
                    quantite = facture.quantite,
                    tva = facture.tva,
                    reference = facture.reference,
                });

                await _db.SaveChangesAsync();

                return RedirectToPage("index");
            } else {
                return Page();
            }
        }
    }
}
