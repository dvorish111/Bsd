using BL_AppService.IServeces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors();
builder.Services.AddAppServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
/*var configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json")
         .AddUserSecrets<Program>()
      .Build();
app.UseHttpsRedirection();*/

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    // options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});



app.MapControllers();

app.Run();


