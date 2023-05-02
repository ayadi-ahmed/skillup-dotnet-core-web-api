using Microsoft.EntityFrameworkCore;
using SkillUp.Models;

namespace SkillUp.Services.ServicesImpl
{
    public class TrainingCenterImpl : ITrainingCenterService
    {
        private readonly ApplicationDbContext _db;
        public TrainingCenterImpl(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }
        public async Task<TrainingCenter> addTrainingCenter(TrainingCenter trainingCenter)
        {
            _db.trainingCenters.Add(trainingCenter);
            await _db.SaveChangesAsync();
            return trainingCenter;
        }

        public async Task<TrainingCenter> DeleteTrainingCenter(int Tcenter)
        {
            var trainingcenterInDB = await _db.trainingCenters.FindAsync(Tcenter);
            _db.trainingCenters.Remove(trainingcenterInDB);
            await _db.SaveChangesAsync();
            return trainingcenterInDB;
        }

        public async Task<TrainingCenter> editTrainingCenter(int cenetid, TrainingCenter trainingCenter)
        {
            var trainingcenterInDB = await _db.trainingCenters.FindAsync(cenetid);
            trainingcenterInDB.Name = trainingCenter.Name;
            await _db.SaveChangesAsync();
            return trainingcenterInDB;
        }

        public async Task<IEnumerable<TrainingCenter>> getAllTrainingCenter()
        {
            var trainingcenters = await _db.trainingCenters.ToListAsync();
            return trainingcenters;
        }

        public async Task<TrainingCenter> getTrainingCenterById(int Tcenter)
        {
            var trainingcenter = await _db.trainingCenters.FindAsync(Tcenter);
            return trainingcenter;
        }
    }
}
