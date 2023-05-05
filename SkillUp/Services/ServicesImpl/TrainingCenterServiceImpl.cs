using System;
using Microsoft.EntityFrameworkCore;
using SkillUp.Models;

namespace SkillUp.Services.ServicesImpl
{
	public class TrainingCenterServiceImpl:ITrainingCenterService
	{
        private readonly ApplicationDbContext _db;

        public TrainingCenterServiceImpl(ApplicationDbContext _db)
        {
            this._db = _db;
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
            trainingCenterInDB.Name = trainingCenter.Name;
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
    }
}

