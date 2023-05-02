using SkillUp.Models;

namespace SkillUp.Services
{
    public interface ICandidatService
    {
        Task<IEnumerable<Candidat>> getAllCandidat();
        Task<Candidat> getCandidatById(int id);
        Task<Candidat> addCandidat(Candidat candidat);
        Task<Candidat> editCandidat(int candidatId,Candidat candidat);
        Task<Candidat> DeleteCandidat(int candidatId);
    }
}
