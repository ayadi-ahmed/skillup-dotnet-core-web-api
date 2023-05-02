using System;
using Microsoft.EntityFrameworkCore;
using SkillUp.Models;

namespace SkillUp.Services.ServicesImpl
{
	public class TrainingServiceImpl : ITrainingService
	{
        private readonly ApplicationDbContext _db;
        private readonly  ITrainingCenterService trainingCenterService;

        public TrainingServiceImpl(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Training> CreateTraining(Training training)
        {
            _db.trainings.Add(training);
            await _db.SaveChangesAsync();
            return training;
        }
        public async Task<Training> DeleteTraining(int id)
        {
            var trainingInDB = await _db.trainings.FindAsync(id);
            _db.trainings.Remove(trainingInDB);
            await _db.SaveChangesAsync();
            return trainingInDB;
        }
        public async Task<Training> EditTraining(int id, Training training)
        {
            var trainingInDB = await _db.trainings.FindAsync(id);
            trainingInDB.Name = training.Name;
            await _db.SaveChangesAsync();
            return trainingInDB;
        }
        public async Task<IEnumerable<Training>> GetAllTrainings()
        {
            var training = await _db.trainings.ToListAsync();
            return training;
        }
        public async Task<Training> getTrainigById(int id)
        {
            Training training = await _db.trainings.FindAsync(id);
            return training;
        }
        public async Task<Training> addFormationToCenter(int fid,int cid)
        {
            Training training = await getTrainigById(fid);
            TrainingCenter trainingCenter = await trainingCenterService.getTrainingCenterById(cid);
            training.trainingcenter = trainingCenter;
            trainingCenter.trainings.Add(training);
            await _db.SaveChangesAsync();
            return training;

        }
    }
}
	

