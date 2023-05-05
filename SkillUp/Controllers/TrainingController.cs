using System;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Models;
using SkillUp.Services;

namespace SkillUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private ITrainingService trainingService;
        public TrainingController(ITrainingService trainingService)
        {
            this.trainingService = trainingService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var cat = await trainingService.GetAllTrainings();
            return Ok(cat);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewCategory(Training training)
        {
            var cat = await trainingService.CreateTraining(training);
            return Ok(cat);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Training training)
        {
            if (!ModelState.IsValid) return BadRequest();
            var cat = await trainingService.EditTraining(id, training);
            return Ok(cat);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var cat = await trainingService.DeleteTraining(id);
            return Ok(cat);
        }
    }
}

