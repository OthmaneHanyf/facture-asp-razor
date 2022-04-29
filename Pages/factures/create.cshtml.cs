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
    public class createModel : PageModel
    {
        private readonly FactureDbContext _db;

        public createModel(FactureDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public FactureDto facture {get; set;}
        [BindProperty]
        public IList<Client> clientList {get;set;}

        public async Task OnGet()
        {   
            this.clientList = await _db.Clients.ToListAsync<Client>();
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid) {
                Client client = _db.Clients.FirstOrDefault(c => c.raisonSociale == facture.raisonSociale);
                if (client != null) {
                    Facture newFacture = new Facture(){
                        factureNumber = 0,
                        designation = facture.designation,
                        prix = facture.prix,
                        quantite = facture.quantite,
                        tva = facture.tva,
                        reference = facture.reference,
                        clientId = client.id,
                        raisonSociale = facture.raisonSociale
                    };

                    await _db.Factures.AddAsync(newFacture);
                    await _db.SaveChangesAsync();

                    return RedirectToPage("index");
                } else {
                    return Page();
                }
            } else {
                return Page();
            }
        }
    }
}
