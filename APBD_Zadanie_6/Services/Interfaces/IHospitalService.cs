using APBD_Zadanie_6.DTOs;
using APBD_Zadanie_6.DTOs.Request;

namespace APBD_Zadanie_6.Services.Interfaces
{
    public interface IHospitalService
    {

        Task<string> AddPrescriptionAsync(PrescriptionRequestDTO request);
    }
}
