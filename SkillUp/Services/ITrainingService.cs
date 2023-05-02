using System;
using SkillUp.Models;

namespace SkillUp.Services
{
    public interface ITrainingService
    {
        Task<IEnumerable<Training>> GetAllTrainings();
        Task<Training> CreateTraining(Training training);
        Task<Training> EditTraining(int id, Training training);
        Task<Training> DeleteTraining(int id);

    }
}

