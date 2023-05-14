using System;
using Microsoft.EntityFrameworkCore;
using SkillUp.Models;

namespace SkillUp.Services.ServicesImpl
{
	public class ManagerServiceImpl: IManagerService
	{
        private readonly ApplicationDbContext _db;

        public ManagerServiceImpl(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public async Task<Manager> CreateManager(Manager manager)
        {
            _db.managers.Add(manager);
            await _db.SaveChangesAsync();
            return manager;
        }

        public async Task<Manager> DeleteManager(int id)
        {
            var managerInDB = await _db.managers.FindAsync(id);
            _db.managers.Remove(managerInDB);
            await _db.SaveChangesAsync();
            return managerInDB;
        }

        public async Task<Manager> EditManager(int id, Manager manager)
        {
            var managerInDB = await _db.managers.FindAsync(id);
            managerInDB.nom = manager.nom;
            managerInDB.prenom = manager.prenom;
            managerInDB.mdp = manager.mdp;
            managerInDB.tel = manager.tel;
            managerInDB.dateNaissance = manager.dateNaissance;
            managerInDB.email = manager.email;

            managerInDB.trainingCenters= manager.trainingCenters;
            await _db.SaveChangesAsync();
            return managerInDB;
        }

        public async Task<IEnumerable<Manager>> GetAllManagers()
        {
            IEnumerable<Manager> managers = await _db.managers.ToListAsync();
            return managers;
        }

        public async Task<Manager> GetManagerById(int id)
        {
            var managerInDB = await _db.managers.FindAsync(id);
            await _db.SaveChangesAsync();
            return managerInDB;
        }
    }
}

