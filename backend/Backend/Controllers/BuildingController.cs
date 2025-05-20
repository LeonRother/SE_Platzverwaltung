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
		private readonly FloorService _floorService;
        public BuildingController(BuildingService buildingService, FloorService floorService)
		{
			_buildingService = buildingService;
			_floorService = floorService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			List<Building> buildings = _buildingService.GetAllBuildings();

			return Ok(buildings);
		}

		[HttpGet("{id:int}/floors")]
		public IActionResult GetFloors(int id)
		{
			var floors = _floorService.GetFloors(id);
			return Ok(floors);
		}
	}
}
