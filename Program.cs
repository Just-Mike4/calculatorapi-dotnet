using CalculatorApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Register strategy pattern services
builder.Services.AddScoped<IOperationStrategy, AddOperation>();
builder.Services.AddScoped<IOperationStrategy, SubtractOperation>();
builder.Services.AddScoped<IOperationStrategy, MultiplyOperation>();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
