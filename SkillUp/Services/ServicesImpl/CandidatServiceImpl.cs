using System;
using Microsoft.EntityFrameworkCore;
using SkillUp.Models;

namespace SkillUp.Services.ServicesImpl
{
	public class CandidatServiceImpl : ICandidatService
	{
        private readonly ApplicationDbContext _context;

        public CandidatServiceImpl(ApplicationDbContext _context)
		{
            this._context = _context;
		}

        

        public async Task<Candidat> CreateCandidat(Candidat candidat)
        {
            _context.candidats.Add(candidat);
            await _context.SaveChangesAsync();
            return candidat;
        }

        public async Task<Candidat> DeleteCandidat(int id)
        {
            Candidat candiatDB = await _context.candidats.FindAsync(id);
            _context.candidats.Remove(candiatDB);
            await _context.SaveChangesAsync();
            return candiatDB;
        }

        public async Task<Candidat> EditCandidat(int id, Candidat candidat)
        {
            Candidat candiatDB = await _context.candidats.FindAsync(id);
            candiatDB.Name = candidat.Name;
            await _context.SaveChangesAsync();
            return candiatDB;

        }

        public async Task<IEnumerable<Candidat>> GetAllCandidats()
        {
            var candidats = await _context.candidats.ToListAsync();
            return candidats;
        }

        public async Task<Candidat> GetCandidatById(int id)
        {
            Candidat candiatDB = await _context.candidats.FindAsync(id);
            await _context.SaveChangesAsync();
            return candiatDB;
        }

        public async Task<Candidat> AffectAchatToCandidat(int idC, int idA)
        {
            Candidat candiatDB = await _context.candidats.FindAsync(idC);
            Achat achatDB = await _context.achats.FindAsync(idA);
            candiatDB.achats = candiatDB.achats.Append(achatDB);
            achatDB.Candidat = candiatDB;
            await _context.SaveChangesAsync();
            return candiatDB;
        }
    }
}

