using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using facture.Data;
using facture.Dtos;
using facture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace facture.Pages.clients
{
    public class indexModel : PageModel
    {
        private readonly FactureDbContext _db;
        public IList<Client> clientList;
        
        public indexModel(FactureDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            clientList =  new List<Client>();

            foreach (var client in _db.Clients.ToList())
            {
                Client tmpClient = client;

                clientList.Add(tmpClient);
            }
        }

        public async Task<ActionResult> OnPostDelete(int id) 
        {
            Client client = await _db.Clients.FindAsync(id);
            _db.Clients.Remove(client);

            await _db.SaveChangesAsync();

            return RedirectToPage("index");
        }
    }
}
