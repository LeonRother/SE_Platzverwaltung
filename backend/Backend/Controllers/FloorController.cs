using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FloorController : ControllerBase
	{
		private readonly FloorService _floorService;
		public FloorController(FloorService floorService)
		{
			_floorService = floorService;
		}

		[HttpGet]
		public IActionResult GetAllFloors()
		{
			var floors = _floorService.GetAllFloors();
			return Ok(floors);
		}

		[HttpGet("{id:int}")]
		public IActionResult GetFloor(int id)
		{
			var floors = _floorService.GetFloors(id);
			return Ok(floors);
		}
	}
}
