using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalTrackingSystem.Entities
{

    [Table("MedicineTracker")]
   // [Keyless]
    public class MedicineTracker
    {
        public int id { get; set; }

        public string MedicineName { get; set; }

        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public  DateTime ExpiryDate { get; set; }

        public string Note { get; set; }


    }
}
