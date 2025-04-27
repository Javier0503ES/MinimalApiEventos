using ApiEventosCdmx.AppConfig;

var builder = WebApplication.CreateBuilder(args);




var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// servicios
builder.AddServices();
// cors congifuration
builder.AddSecurityCors(configuration);



var app = builder.Build();
// configuration  cors
app.UseCors("_MyAlowSpecificOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// rutas enpoint
app.AddRoutes();

app.UseHttpsRedirection();

app.Run();

