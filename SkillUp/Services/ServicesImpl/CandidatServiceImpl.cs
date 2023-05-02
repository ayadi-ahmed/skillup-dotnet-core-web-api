using Microsoft.EntityFrameworkCore;
using SkillUp.Models;

namespace SkillUp.Services.ServicesImpl
{
    public class CandidatServiceImpl : ICandidatService
    {
        private readonly ApplicationDbContext _db;
        
        public CandidatServiceImpl(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }
            
        public async Task<Candidat> addCandidat(Candidat candidat)
        {
            _db.candidats.Add(candidat);
            await _db.SaveChangesAsync();
            return candidat;
        }

        public async Task<Candidat> DeleteCandidat(int candidatId)
        {
            var candidatInDb = await _db.candidats.FindAsync(candidatId);
            _db.candidats.Remove(candidatInDb);
            await _db.SaveChangesAsync();
            return candidatInDb;
        }

        public async Task<Candidat> editCandidat(int candidatId, Candidat candidat)
        {
            var candidatInDB = await _db.candidats.FindAsync(candidatId);
            candidatInDB.nom= candidat.nom;
            candidatInDB.prenom = candidat.prenom;
            candidatInDB.dateNaissance = candidat.dateNaissance;
            candidatInDB.tel = candidat.tel;
            candidatInDB.address = candidat.address;
            candidatInDB.fonction = candidat.fonction;
            await _db.SaveChangesAsync();
            return candidatInDB;
        }

        public async Task<IEnumerable<Candidat>> getAllCandidat()
        {
            var candidats = await _db.candidats.ToListAsync();
            return candidats;
        }
        public async Task<Candidat> getCandidatById(int id)
        {
            var c= await _db.candidats.FindAsync(id);
            return c;
        }
       
    }
}
