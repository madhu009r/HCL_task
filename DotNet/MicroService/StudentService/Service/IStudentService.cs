using StudentService.DTO;

namespace StudentService.Service
{
    public interface IStudentService
    {
        
        Task<StudentDto?> GetById(int id);
        Task<StudentDto> Create(CreateStudent dto);

        Task<StudentDto> Update(int id, UpdateStudent dto);

        Task<PagedResponse<StudentDto>> GetAll(PaginationParams pagination);

        Task<bool> Delete(int id);
    }
}
