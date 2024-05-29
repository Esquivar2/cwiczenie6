namespace APBD_Zadanie_6.DTOs.Request
{
    public class PrescriptionRequestDTO
    {

        public PatientDTO Patient { get; set; }
        public List<MedicamentDTO> Medicaments { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdDoctor { get; set; }
    }
}
