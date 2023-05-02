using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.Models;
using SkillUp.Services;

namespace SkillUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatController : ControllerBase
        
    { 
        private readonly ICandidatService _candidatService;

        public CandidatController(ICandidatService candidatService)
        {
            _candidatService = candidatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidat()
        {
            var cat = await _candidatService.getAllCandidat();
            return Ok(cat);
        }
       

        [HttpPost]
        public async Task<IActionResult> AddNewCandidat(Candidat candidat)
        {
            var cat = await _candidatService.addCandidat(candidat);
            return Ok(cat);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCandidat(int id, Candidat candidat)
        {
            if (!ModelState.IsValid) return BadRequest();
            var cat = await _candidatService.editCandidat(id, candidat);
            return Ok(cat);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCandidat(int id)
        {
            var trainingcenter = await _candidatService.getCandidatById(id);
            if (trainingcenter==null)
                return BadRequest();
            var cat = await _candidatService.DeleteCandidat(id);
            return Ok(cat);
        }
    }
}
