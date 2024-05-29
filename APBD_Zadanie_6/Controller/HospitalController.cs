using APBD_Zadanie_6.DTOs.Request;
using APBD_Zadanie_6.Repositories.Interfaces;
using APBD_Zadanie_6.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Zadanie_6.Controller
{
    [ApiController]
    [Route("api/hospital")]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _service;
        
        public HospitalController(IHospitalService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescription([FromBody] PrescriptionRequestDTO request)
        {
            var test = await _service.AddPrescriptionAsync(request);
            return Ok(test);
        }
    }
}
