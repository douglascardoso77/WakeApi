using AutoMapper;
using CrossCutting.ConfigureInjection;
using CrossCutting.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureService.ConfigureDependenceInjection(builder.Services);
ConfigureRepository.ConfigureDependenceInjection(builder.Services);

var config = new AutoMapper.MapperConfiguration(c => 
{
    c.AddProfile(new DtoToModelProfile());
    c.AddProfile(new EntityToDtoProfile());
    c.AddProfile(new ModelToEntityProfile());
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if(app.Environment.IsEnvironment("Test"))
{
    Environment.SetEnvironmentVariable("DB_CONNECTION", "Server=localhost, 1433;Database=WakeApp_Integration;User Id=sa;Password=Database!2024;");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
