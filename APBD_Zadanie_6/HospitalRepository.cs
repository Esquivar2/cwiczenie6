using APBD_Zadanie_6.Models;

namespace APBD_Zadanie_6
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly Context _context;

        public HospitalRepository(Context context) { 
            _context = context;
        }

        public async Task<string> AddPrescriptionAsync(PrescreiptionRequestDTo request)
        {
            _context.Prescriptions.Add(request);
            await _context.SaveChangesAsync();
            return "success";
        }
    }
}
