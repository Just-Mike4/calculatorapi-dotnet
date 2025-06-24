using CalculatorApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<ICalculatorService, CalculatorService>();

// Add Swagger and Controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
