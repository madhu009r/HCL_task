using StudentService.Data;
using StudentService.DTO;
using StudentService.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentService.Service
{
    public class StudentServiceManager : IStudentService
    {
        private readonly StudentDbContext _context;

        public StudentServiceManager(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<StudentDto>> GetAll(PaginationParams pagination)
        {
            var query = _context.Students
                .Where(s => s.IsActive)
                .AsQueryable();

            var totalCount = await query.CountAsync();

            var students = await query
                .OrderBy(s => s.Id)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    FullName = s.FirstName + " " + s.LastName,
                    Email = s.Email,
                    DepartmentId = s.DepartmentId
                })
                .ToListAsync();

            return new PagedResponse<StudentDto>
            {
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize,
                TotalCount = totalCount,
                Data = students
            };
        }

        public async Task<StudentDto?> GetById(int id)
        {
            var student = await _context.Students
                .Where(s => s.Id == id && s.IsActive)
                .FirstOrDefaultAsync();

            if (student == null)
                return null;

            return new StudentDto
            {
                Id = student.Id,
                FullName = student.FirstName + " " + student.LastName,
                Email = student.Email,
                DepartmentId = student.DepartmentId
            };
        }

        public async Task<StudentDto> Create(CreateStudent dto)
        {
            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                DepartmentId = dto.DepartmentId
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return new StudentDto
            {
                Id = student.Id,
                FullName = student.FirstName + " " + student.LastName,
                Email = student.Email,
                DepartmentId = student.DepartmentId
            };
        }

        public async Task<StudentDto?> Update(int id, UpdateStudent dto)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null || !student.IsActive)
                return null;

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Email = dto.Email;
            student.DateOfBirth = dto.DateOfBirth;
            student.DepartmentId = dto.DepartmentId;
            student.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new StudentDto
            {
                Id = student.Id,
                FullName = student.FirstName + " " + student.LastName,
                Email = student.Email,
                DepartmentId = student.DepartmentId
            };
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            student.IsActive = false; // Soft delete
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
