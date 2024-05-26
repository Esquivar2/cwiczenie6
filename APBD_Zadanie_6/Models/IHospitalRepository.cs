namespace APBD_Zadanie_6.Models
{
    public interface IHospitalRepository
    {
        public Task<string> AddPrescriptionAsync(PrescriptionRequestDTO request);
       
    }
}
