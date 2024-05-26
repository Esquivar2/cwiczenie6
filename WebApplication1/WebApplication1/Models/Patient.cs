namespace WebApplication1.Models
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BrirthDate { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
