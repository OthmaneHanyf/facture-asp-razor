using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using facture.Data;
using facture.Dtos;
using facture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace facture.Pages.clients
{
    public class createModel : PageModel
    {
        private readonly FactureDbContext _db;
        
        [BindProperty]
        public ClientDto client {get; set;}
        
        public createModel(FactureDbContext db)
        {
            _db = db;
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid) {
                await _db.AddAsync((Client) client);
                await _db.SaveChangesAsync();

                return RedirectToPage("index");
            } else {
                return Page();
            }
        }
    }
}
