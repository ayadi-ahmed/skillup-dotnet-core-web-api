using System;
using Microsoft.EntityFrameworkCore;
using SkillUp.Models;

namespace SkillUp.Services.ServicesImpl
{
	public class AchatServiceImpl : IAchatService
	{
        private readonly ApplicationDbContext _db;

        public AchatServiceImpl(ApplicationDbContext _db)
		{
            this._db = _db;
		}

        public async Task<Achat> CreateAchat(Achat achat)
        {
            _db.achats.Add(achat);
            await _db.SaveChangesAsync();
            return achat;
        }

        public async Task<Achat> DeleteAchat(int id)
        {
            var achatInDB = await _db.achats.FindAsync(id);
            _db.achats.Remove(achatInDB);
            await _db.SaveChangesAsync();
            return achatInDB;
        }

        public async Task<Achat> EditAchat(int id, Achat achat)
        {
            var achatInDB = await _db.achats.FindAsync(id);
            achatInDB.Name = achat.Name;
            await _db.SaveChangesAsync();
            return achatInDB;
        }

        public async Task<Achat> GetAchatById(int id)
        {
            var achatInDB = await _db.achats.FindAsync(id);
            await _db.SaveChangesAsync();
            return achatInDB;
        }

        public async Task<IEnumerable<Achat>> GetAllAchats()
        {
            IEnumerable<Achat> achats = await _db.achats.ToListAsync();
            return achats;
        }

        public async Task<Achat> AffectAchatToCandidat(int idC, int idA)
        {
            Candidat candiatDB = await _db.candidats.FindAsync(idC);
            Achat achatDB = await _db.achats.FindAsync(idA);
            achatDB.Candidat = candiatDB;
            await _db.SaveChangesAsync();
            return achatDB;
        }
    }
}

