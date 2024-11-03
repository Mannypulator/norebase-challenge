using NoreBaseApiChallenge;
using NoreBaseApiChallenge.Domain.shared;
using NoreBaseApiChallenge.Extension;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureRepositoryContext(builder.Configuration);
builder.Host.UseSerilog(Logger.Configure);

builder.Services.ConfigureLikeServices();
builder.Services.ConfigureLikeRepository();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging(options =>
    options.EnrichDiagnosticContext = LogEnricher.EnrichFromRequest);
app.UseHttpsRedirection();
app.ConfigureExceptionHandler();
app.UseAuthorization();
app.MapControllers();

app.Run();
