using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

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
	public IActionResult GetAllBuildings()
	{
		var buildings = _buildingService.GetAllBuildings();
		return Ok(buildings);
	}

	[HttpGet("{buildingId:int}/floors")]
	public IActionResult GetFloorsForBuilding(int buildingId)
	{
		var floors = _floorService.GetFloors(buildingId);
		return Ok(floors);
	}
}