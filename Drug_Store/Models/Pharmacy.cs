using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drug_Store.Models
{
    class Pharmacy
    {
        public int Id { get; set; }
        public string NamePharmacy { get; set; }

        public AdressPharmacy Adress { get; set; }
    }
}
