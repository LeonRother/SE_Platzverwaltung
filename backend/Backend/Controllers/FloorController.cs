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
	}
}
