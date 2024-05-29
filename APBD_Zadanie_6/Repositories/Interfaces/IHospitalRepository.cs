using APBD_Zadanie_6.DTOs;
using APBD_Zadanie_6.DTOs.Request;

namespace APBD_Zadanie_6.Repositories.Interfaces
{
    public interface IHospitalRepository
    {
        public Task<string> AddPrescriptionAsync(PrescriptionRequestDTO request);
        public Task<bool> PatientExistsAsync(int idPatient);
        public Task AddPatientAsync(PatientDTO patient);
        public Task<bool> MedicamentExistsAsync(int idMedicament);
    }
}
