namespace VezeetaAPI.DTOs.Patient
{
    public class PatientRegisterDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string Location { get; set; }
        public string Password { get; set; }
    }
}
