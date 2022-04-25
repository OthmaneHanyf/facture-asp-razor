using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using facture.Data;
using facture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace facture.Pages.clients
{
    public class updateModel : PageModel
    {

        private readonly FactureDbContext _db;

        [BindProperty]
        public Client client {get; set;}

        public updateModel(FactureDbContext db)
        {
            _db = db;
        }

        public async void OnGet(int id)
        {
            client = await _db.Clients.FindAsync(id);
        }

        public async Task<ActionResult> OnPost(int id)
        {
            if (ModelState.IsValid) {
                Client clnt = await _db.Clients.FindAsync(id);

                _db.Clients.Remove(clnt);
                
                await _db.AddAsync(client);

                await _db.SaveChangesAsync();

                return RedirectToPage("index");
            } else {
                return Page();
            }
        }
    }
}
