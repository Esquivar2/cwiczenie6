using APBD_Zadanie_6.DTOs;
using APBD_Zadanie_6.DTOs.Request;
using APBD_Zadanie_6.Models;
using APBD_Zadanie_6.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace APBD_Zadanie_6.Repositories.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly Context _context;

        public HospitalRepository(Context context) { _context = context; }


        public async Task<bool> PatientExistsAsync(int idPatient)
        {
            return await _context.Patients.AnyAsync(p => p.IdPatient == idPatient);
        }

        public async Task AddPatientAsync(PatientDTO patientDto)
        {
            var patient = new Patient
            {
                IdPatient = patientDto.IdPatient,
                FirstName = patientDto.FirstName,
                LastName = patientDto.LastName,
                BirthDate = patientDto.BirthDate,
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> MedicamentExistsAsync(int idMedicament)
        {
            return await _context.Medicaments.AnyAsync(m => m.IdMedicament == idMedicament);
        }



        public async Task<string> AddPrescriptionAsync(PrescriptionRequestDTO request)
        {
            if (!await PatientExistsAsync(request.Patient.IdPatient))
            {
                await AddPatientAsync(request.Patient);
            }

            foreach (var medicament in request.Medicaments)
            {
                if (!await MedicamentExistsAsync(medicament.Id))
                {
                    return "Lek nie istnieje!";
                }
            }

            var prescription = new Prescription
            {
                IdDoctor = request.IdDoctor,
                Date = request.Date,
                DueDate = request.DueDate,
                IdPatient = request.Patient.IdPatient,
                PrescriptionMedicaments = request.Medicaments.Select(m => new PrescriptionMedicament
                {
                    IdMedicament = m.Id,
                    Dose = m.Dose,
                    Details = m.Description
                }).ToList()
            };

            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();

            return "success";
        }
    }
}

