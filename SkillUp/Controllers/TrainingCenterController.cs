using System;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Models;
using SkillUp.Services;

namespace SkillUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCenterController : ControllerBase
    {
        private ITrainingCenterService trainingCenterService;
		public TrainingCenterController(ITrainingCenterService trainingCenterService)
		{
            this.trainingCenterService = trainingCenterService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainingCenters()
        {
            var trainingCenters = await trainingCenterService.GetAllTrainingCenters();
            return Ok(trainingCenters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingCenterById(int id)
        {
            var trainingCenterInDb = await trainingCenterService.GetTrainingCenterById(id);
            return Ok(trainingCenterInDb);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewTrainingCenter(TrainingCenter trainingCenter)
        {
            var trainingCenterNew = await trainingCenterService.CreateTrainingCenter(trainingCenter);
            return Ok(trainingCenterNew);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateTrainingCenter(int id, TrainingCenter trainingCenter)
        {
            if (!ModelState.IsValid) return BadRequest();
            var trainingCenterUpdated = await trainingCenterService.EditTrainingCenter(id, trainingCenter);
            return Ok(trainingCenterUpdated);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingCenter(int id)
        {
            var trainingCenter = await trainingCenterService.DeleteTrainingCenter(id);
            return Ok(trainingCenter);
        }
    }
}

