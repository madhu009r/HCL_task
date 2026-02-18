namespace StudentService.DTO
{
    public class UpdateStudent
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
    }
}
