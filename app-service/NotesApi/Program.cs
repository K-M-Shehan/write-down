var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options => {
  options.AddPolicy("AllowFrontend",
    policy => {
      policy.WithOrigins("http://localhost:5173", "https://nice-coast-0d3a09500.azurestaticapps.net")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
