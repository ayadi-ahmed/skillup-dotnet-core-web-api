using System;
using SkillUp.Models;

namespace SkillUp.Services
{
	public interface IAchatService
	{
        Task<IEnumerable<Achat>> GetAllAchats();
        Task<Achat> GetAchatById(int id);
        Task<Achat> CreateAchat(Achat achat);
        Task<Achat> EditAchat(int id, Achat achat);
        Task<Achat> DeleteAchat(int id);
    }
}

