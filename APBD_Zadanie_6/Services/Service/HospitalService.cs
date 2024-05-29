using APBD_Zadanie_6.DTOs.Request;
using APBD_Zadanie_6.Repositories.Interfaces;
using APBD_Zadanie_6.Services.Interfaces;

namespace APBD_Zadanie_6.Services.Service
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _repository;
        public HospitalService(IHospitalRepository repository) { _repository = repository; }

        public async Task<string> AddPrescriptionAsync(PrescriptionRequestDTO request)
        {
            if (request.Medicaments.Count > 10)
            {
                return "Recepta może obejmować maksymalnie 10 leków!";
            }

            if (request.DueDate < request.Date)
            {
                return "DueDate jest mniejsza niż Date!";
            }

            var result = await _repository.AddPrescriptionAsync(request);
            return result;
        }
    }
}
