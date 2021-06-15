using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drug_Store.Models
{
    class AdressPharmacy
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string NumberBuilding { get; set; }

        public int PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}
