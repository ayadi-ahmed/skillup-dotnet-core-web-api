using System;
using Microsoft.EntityFrameworkCore;
using SkillUp.Models;

namespace SkillUp.Services.ServicesImpl
{
	public class TrainingCenterServiceImpl:ITrainingCenterService
	{
        private readonly ApplicationDbContext _db;
        private readonly IManagerService managerService;
        private readonly ITrainingService trainingService;

        public TrainingCenterServiceImpl(ApplicationDbContext _db, IManagerService managerService, ITrainingService trainingService)
        {
            this._db = _db;
            this.trainingService = trainingService;
            this.managerService = managerService;
        }

        public async Task<TrainingCenter> CreateTrainingCenter(TrainingCenter trainingCenter)
        {
            _db.trainingCenters.Add(trainingCenter);
            await _db.SaveChangesAsync();
            return trainingCenter;
        }

        public async Task<TrainingCenter> DeleteTrainingCenter(int id)
        {
            var trainingCenterInDB = await _db.trainingCenters.FindAsync(id);
            _db.trainingCenters.Remove(trainingCenterInDB);
            await _db.SaveChangesAsync();
            return trainingCenterInDB;
        }

        public async Task<TrainingCenter> EditTrainingCenter(int id, TrainingCenter trainingCenter)
        {
            var trainingCenterInDB = await _db.trainingCenters.FindAsync(id);

            trainingCenterInDB.nom = trainingCenter.nom;
            trainingCenterInDB.addresse = trainingCenter.addresse;
            trainingCenterInDB.dateCreation = trainingCenter.dateCreation;
            trainingCenterInDB.matriculeFiscale = trainingCenter.matriculeFiscale;
            trainingCenterInDB.email = trainingCenter.email;
            trainingCenterInDB.description = trainingCenter.description;
            trainingCenterInDB.rib = trainingCenter.rib;
            trainingCenterInDB.logo = trainingCenter.logo;
            trainingCenterInDB.etatDemandeInscription = trainingCenter.etatDemandeInscription;
            trainingCenterInDB.training = trainingCenter.training;
            trainingCenterInDB.manager = trainingCenter.manager;
            await _db.SaveChangesAsync();
            return trainingCenterInDB;
        }

        public async Task<IEnumerable<TrainingCenter>> GetAllTrainingCenters()
        {
            IEnumerable<TrainingCenter> trainingCenters = await _db.trainingCenters.ToListAsync();
            return trainingCenters;
        }

        public async Task<TrainingCenter> GetTrainingCenterById(int id)
        {
            var trainingCenterInDB = await _db.trainingCenters.FindAsync(id);
            await _db.SaveChangesAsync();
            return trainingCenterInDB;
        }

        public async Task<TrainingCenter> affectCenterToManager(int mid, int cid)
        {
            TrainingCenter center = await _db.trainingCenters.FindAsync(cid);
            Manager manager = await _db.managers.FindAsync(mid);
            center.manager = manager;
            await EditTrainingCenter(cid, center);
            manager.trainingCenters.Append(center);
            await managerService.EditManager(mid, manager);
            await _db.SaveChangesAsync();
            return center;
        }
        public async Task<TrainingCenter> affectFormationToCenter(int cid, int fid)
        {
            TrainingCenter center = await _db.trainingCenters.FindAsync(cid);
            Training training = await _db.trainings.FindAsync(fid);
            center.training.Append(training);
            await EditTrainingCenter(cid, center);
            training.trainingCenter = center;
            trainingService.EditTraining(fid, training);
            await _db.SaveChangesAsync();
            return center;

        }
    }
}

