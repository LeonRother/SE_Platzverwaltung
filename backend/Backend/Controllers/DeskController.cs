using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	[ApiController]
	[Route("[controller]")]

	public class DeskController : ControllerBase
	{
		private readonly DeskService _deskService;

		public DeskController(DeskService deskService)
		{
			_deskService = deskService;
		}

	}
}