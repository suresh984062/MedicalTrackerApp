using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalTrackingSystem.Entities;
using MedicalTrackingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MedicalTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineTrakerController : Controller
    {
        private readonly IRepository _RepositoryProvider;

        public MedicineTrakerController(IRepository RepositoryProvider)
        {
            _RepositoryProvider = RepositoryProvider;
        }

        [HttpGet]
        public async Task<ActionResult> GetMedicineinfo()
        {
            var result = await _RepositoryProvider.GetMedicineinfo();
            return Ok(result);
            //return StatusCode(StatusCodes.Status500InternalServerError,
            //         "Error retrieving data from the database");
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetMedicineDetails(string name)
        {
            var result = await _RepositoryProvider.GetMedicineDetails(name);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddRecord")]
        public async Task<ActionResult> AddRecord([FromBody] MedicineTracker Medicineinfo)
        {
            await _RepositoryProvider.AddMedicineRecord(Medicineinfo);
            return Created(string.Empty, Medicineinfo);
        }


        [HttpPut,Route("UpdateRecord/{name}")]
        
        public async Task<ActionResult> UpdateRecord(string name, [FromBody] MedicineTracker Medicineinfo)
        {
            
            await _RepositoryProvider.UpdateMedicineRecord(name,Medicineinfo);
            return Ok();
        }

        //[HttpDelete]
        [HttpDelete, Route("DeleteRecord/{name}")]
        // [Route("DeleteRecord")]
        public async Task<ActionResult> DeleteRecord(string name)
        {
            await _RepositoryProvider.DeleteMedicinetRecord(name);
            return Ok();
        }


    }

}
