using System;
using SkillUp.Models;

namespace SkillUp.Services
{
	public interface IManagerService
	{
        Task<IEnumerable<Manager>> GetAllManagers();
        Task<Manager> GetManagerById(int id);
        Task<Manager> CreateManager(Manager manager);
        Task<Manager> EditManager(int id, Manager manager);
        Task<Manager> DeleteManager(int id);
    }
}

