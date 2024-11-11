using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BuildingController : ControllerBase
	{
		private readonly BuildingService _buildingService;
        public BuildingController(BuildingService buildingService)
        {
			_buildingService = buildingService;
        }

        [HttpGet]
		public IActionResult Index()
		{
			List<Building> buildings = _buildingService.GetAllBuildings();

			return Ok(buildings);
		}
    }
}
