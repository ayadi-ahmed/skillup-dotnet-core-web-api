using System;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Models;
using SkillUp.Services;

namespace SkillUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Candidatcontroller : ControllerBase
	{
        private ICandidatService candidatService;

        public Candidatcontroller(ICandidatService candidatService)
		{
            this.candidatService = candidatService;
		}

        [HttpGet]
        public async Task<IActionResult> GetAllCandidats()
        {
            var candidat = await candidatService.GetAllCandidats();
            return Ok(candidat);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidatById(int id)
        {
            var candidatInDb = await candidatService.GetCandidatById(id);
            return Ok(candidatInDb);
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidat(Candidat candidat)
        {
            var candidatNew = await candidatService.CreateCandidat(candidat);
            return Ok(candidatNew);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Candidat candidat)
        {
            if (!ModelState.IsValid) return BadRequest();
            var candidatUpdated = await candidatService.EditCandidat(id, candidat);
            return Ok(candidatUpdated);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var candidat = await candidatService.DeleteCandidat(id);
            return Ok(candidat);
        }

        [HttpPost("{idCandidat}/achat/{idAchat}")]
        public async Task<IActionResult> AffectAchatToCandidat(int idCandidat, int idAchat) {
            Candidat  candidat = await candidatService.AffectAchatToCandidat(idCandidat, idAchat);
            return Ok(candidat);
        }
    }
}

