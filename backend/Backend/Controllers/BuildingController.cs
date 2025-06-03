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
		private readonly DeskService _deskService;
		private readonly BookingService _bookingService;
        public BuildingController(BuildingService buildingService, FloorService floorService, DeskService deskService, BookingService bookingService)
		{
			_buildingService = buildingService;
			_floorService = floorService;
			_deskService = deskService;
			_bookingService = bookingService;
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

		[HttpGet("/floors/{floorId:int}/desks")]
		public IActionResult GetDesksByFloor(int floorId)
		{
			var desks = _deskService.GetDesks(floorId);
			return Ok(desks);
		}

		[HttpPost("book-desk")]
		public IActionResult BookDesk([FromBody] Bookings booking)
		{
			try
			{
				_bookingService.CreateBooking(booking);
				return Ok();
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("UNIQUE"))
					return Conflict("Desk already booked.");
				return StatusCode(500, ex.Message);
			}
		}
	}
}
