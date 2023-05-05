using System;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Models;
using SkillUp.Services;

namespace SkillUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private IManagerService managerService;
		public ManagerController(IManagerService managerService)
		{
            this.managerService = managerService;
		}
        [HttpGet]
        public async Task<IActionResult> GetAllManagers()
        {
            var managers = await managerService.GetAllManagers();
            return Ok(managers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManagerById(int id)
        {
            var managerInDb = await managerService.GetManagerById(id);
            return Ok(managerInDb);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewManager(Manager manager)
        {
            var newManager = await managerService.CreateManager(manager);
            return Ok(newManager);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateManager(int id, Manager manager)
        {
            if (!ModelState.IsValid) return BadRequest();
            var newManager = await managerService.EditManager(id, manager);
            return Ok(newManager);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            var deletedManager = await managerService.DeleteManager(id);
            return Ok(deletedManager);
        }
    }
}

