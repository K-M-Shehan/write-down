var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<Supabase.Client>(sp => {
  var config = sp.GetRequiredService<IConfiguration>();
  var url = config["Supabase:Url"];
  var key = config["Supabase:Key"];

  if(string.IsNullOrEmpty(url) | string.IsNullOrEmpty(key))
    throw new Exception("Supabase credentials not set!");

  var client = new Supabase.Client(url, key);
  client.InitializeAsync().Wait();

  return client;
});

builder.Services.AddCors(options => {
  options.AddPolicy("AllowFrontend",
    policy => {
      policy.WithOrigins("http://localhost:5173", "https://nice-coast-0d3a09500.1.azurestaticapps.net")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
