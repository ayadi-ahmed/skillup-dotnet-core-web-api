using System;
using SkillUp.Models;

namespace SkillUp.Services
{
	public interface ICandidatService
	{
		Task<IEnumerable<Candidat>> GetAllCandidats();
		Task<Candidat> GetCandidatById(int id);
		Task<Candidat> CreateCandidat(Candidat candidat);
		Task<Candidat> EditCandidat(int id, Candidat candidat);
		Task<Candidat> DeleteCandidat(int id);
		Task<Candidat> AffectAchatToCandidat(int idC, int idA);

    }
}

