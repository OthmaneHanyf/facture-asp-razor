using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using facture.Data;
using facture.Dtos;
using facture.Models;
using Microsoft.EntityFrameworkCore;

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

        [BindProperty]
        public IList<Client> clientList {get;set;}

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
                    raisonSociale = f.raisonSociale,
                };
                clientList = await _db.Clients.ToListAsync<Client>();
                return Page();
            }
        }

        public async Task<ActionResult> OnPost(int id, int clientId)
        {

            if (ModelState.IsValid) {

                Facture fac = await _db.Factures.FindAsync(id);

                Client newClient = await _db.Clients.FirstOrDefaultAsync(c => c.raisonSociale == fac.raisonSociale);
                
                _db.Factures.Remove(fac);

                await _db.Factures.AddAsync(new Facture(){
                    factureNumber = facture.factureNumber,
                    designation = facture.designation,
                    prix = facture.prix,
                    quantite = facture.quantite,
                    tva = facture.tva,
                    reference = facture.reference,
                    raisonSociale = newClient.raisonSociale,
                    clientId = newClient.id,
                });

                await _db.SaveChangesAsync();

                return RedirectToPage("index");
            } else {
                return Page();
            }
        }
    }
}
