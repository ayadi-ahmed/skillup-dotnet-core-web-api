using System;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Models;
using SkillUp.Services;

namespace SkillUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchatController : ControllerBase
    {
        private IAchatService achatService;
		public AchatController(IAchatService achatService)
		{
            this.achatService = achatService;
		}
        [HttpGet]
        public async Task<IActionResult> GetAllAchats()
        {
            var achats = await achatService.GetAllAchats();
            return Ok(achats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAchatById(int id)
        {
            var achatInDb = await achatService.GetAchatById(id);
            return Ok(achatInDb);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewAchat(Achat achat)
        {
            var newAchat = await achatService.CreateAchat(achat);
            return Ok(newAchat);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateAchat(int id, Achat achat)
        {
            if (!ModelState.IsValid) return BadRequest();
            var newAchat = await achatService.EditAchat(id, achat);
            return Ok(newAchat);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchat(int id)
        {
            var cat = await achatService.DeleteAchat(id);
            return Ok(cat);
        }

        [HttpPost("{idAchat}/candidat/{idCandidat}")]
        public async Task<IActionResult> AffectAchatToCandidat(int idAchat, int idCandidat)
        {
            Achat achat = await achatService.AffectAchatToCandidat(idAchat, idCandidat);
            return Ok(achat);
        }
    }
}

