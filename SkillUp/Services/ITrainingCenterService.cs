using System;
using SkillUp.Models;

namespace SkillUp.Services
{
	public interface ITrainingCenterService
	{
        Task<IEnumerable<TrainingCenter>> GetAllTrainingCenters();
        Task<TrainingCenter> GetTrainingCenterById(int id);
        Task<TrainingCenter> CreateTrainingCenter(TrainingCenter trainingCenter);
        Task<TrainingCenter> EditTrainingCenter(int id, TrainingCenter trainingCenter);
        Task<TrainingCenter> DeleteTrainingCenter(int id);
        Task<TrainingCenter> affectCenterToManager(int mid, int cid);
        Task<TrainingCenter> affectFormationToCenter(int cid, int fid);
    }
}

