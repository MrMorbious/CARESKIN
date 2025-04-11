using SWP391_CareSkin_BE.DTOS;
using SWP391_CareSkin_BE.Models;

namespace SWP391_CareSkin_BE.Repositories.Interfaces
{
    public interface IStaffRepository
    {
        Task<List<Staff>> GetAllStaffsAsync();
        Task<Staff?> GetStaffByIdAsync(int staffId);
        Task<Staff?> GetStaffByUsernameOrEmailAsync(string username, string email);
        Task AddStaffAsync(Staff staff);
        Task UpdateStaffAsync(Staff staff);
        Task<Staff?> LoginStaff(LoginDTO request);
    }
}
