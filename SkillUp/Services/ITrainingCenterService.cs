using SkillUp.Models;

namespace SkillUp.Services
{
    public interface ITrainingCenterService
    {
        Task<IEnumerable<TrainingCenter>> getAllTrainingCenter();
        Task<TrainingCenter> getTrainingCenterById(int Tcenter);
        Task<TrainingCenter> addTrainingCenter(TrainingCenter trainingCenter);
        Task<TrainingCenter> editTrainingCenter(int cenetid, TrainingCenter trainingCenter);
        Task<TrainingCenter> DeleteTrainingCenter(int Tcenter);
    }
}
