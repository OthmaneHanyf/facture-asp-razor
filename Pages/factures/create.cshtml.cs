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
        private readonly FactureDbContext _db;

        public createModel(FactureDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public FactureDto facture {get; set;}

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid) {
                Client client = _db.Clients.FirstOrDefault(c => c.id == facture.clientId &&
                                                                c.idCommunEntreprise == facture.idCommunEntreprise &&
                                                                c.raisonSociale == facture.raisonSociale &&
                                                                c.idFiscal == facture.idFiscal);
                if (client != null) {
                    Facture newFacture = new Facture(){
                        factureNumber = 0,
                        designation = facture.designation,
                        prix = facture.prix,
                        quantite = facture.quantite,
                        tva = facture.tva,
                        reference = facture.reference,
                        clientId = facture.clientId,
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
