using Backend;
using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		policy.WithOrigins("http://localhost:5173")
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});
builder.Services.AddSingleton<DatabaseHandler>();
builder.Services.AddSingleton<BuildingService>();
builder.Services.AddSingleton<FloorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors();
app.Run();
