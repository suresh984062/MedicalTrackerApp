using MedicalTrackingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalTrackingSystem.Services
{
    public interface IRepository
    {

        Task<List<MedicineTracker>> GetMedicineinfo();
        Task<List<MedicineTracker>> GetMedicineDetails(string Drugname);
        Task AddMedicineRecord(MedicineTracker Medicineinfo);
        Task UpdateMedicineRecord(string name, MedicineTracker Medicineinfo);
        Task DeleteMedicinetRecord(string name);

    }
}
