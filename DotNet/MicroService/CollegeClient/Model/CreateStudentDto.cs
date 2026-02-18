namespace CollegeClient.Model
{
    public class CreateStudentDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
    }
}
