using MedicalTrackingSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalTrackingSystem.Services
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;
       // private readonly DbSet<MedicineTracker> _MedicineTracker;

        public Repository(ApplicationDbContext context)
        {
            _context = context;           
        }     
        public async Task AddMedicineRecord(MedicineTracker Medicineinfo)
        {
            _context.medicineTrackers.Add(Medicineinfo);
            _context.SaveChanges();
        }

        public async Task DeleteMedicinetRecord(string name)
        {
            var entity = _context.medicineTrackers.FirstOrDefault(t => t.MedicineName == name);
            _context.medicineTrackers.Remove(entity);
            _context.SaveChanges();
        }

        public async  Task<List<MedicineTracker>> GetMedicineDetails(string Drugname)
        {
            var result = _context.medicineTrackers.Where(t => t.MedicineName == Drugname).ToList();
            return result;


        }

        public async Task<List<MedicineTracker>> GetMedicineinfo()
        {
            try
            {
                return _context.medicineTrackers.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task  UpdateMedicineRecord(string name,MedicineTracker Medicineinfo)
        {
            var result = _context.medicineTrackers.FirstOrDefault(t => t.MedicineName == name);
            if (result != null)
            {
                result.Brand = Medicineinfo.Brand;
                result.Price = Medicineinfo.Price;
                result.Quantity = Medicineinfo.Quantity;

                _context.SaveChanges();
            }
            _context.SaveChanges();
        }
    }
}
