using System.Collections.Generic;
using facture.Models;

namespace facture.Data
{
    public class FactureDummyDb
    {
        public List<Facture> factures;
        public FactureDummyDb()
        {
            Facture f1 = new Facture {
                factureNumber = 1,
                designation = "Designation N1",
                prix = 199.98,
                quantite = 30,
                tva = 20,
                reference = "Reference N1",
            };
            Facture f2 = new Facture {
                factureNumber = 2,
                designation = "Designation N2",
                prix = 199.98,
                quantite = 30,
                tva = 20,
                reference = "Reference N2",
            };

            factures = new List<Facture> {
                f1,
                f2,
            };
        }

    }
}