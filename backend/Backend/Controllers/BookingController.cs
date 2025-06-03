using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BookingController : ControllerBase
	{
		private readonly BookingService _bookingService;
		public BookingController(BookingService bookingService)
		{
			_bookingService = bookingService;
		}

		
	}

}
