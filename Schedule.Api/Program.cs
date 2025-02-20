using Schedule.Api.Endpoints;
using Schedule.Infrastructure.IoC.Di;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        b => b
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed((hosts) => true));
});

builder.Services
    .RegisterDataBase(builder.Configuration)
    .RegisterRepositories()
    .RegisterServices();
    //.RegisterLibraries();

var app = builder.Build();
app.UseCors("CORSPolicy");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIS IATEC-SCHEDULE V.1.0");
    c.RoutePrefix = "swagger";
    c.EnableFilter();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//add EndPoints

app.MapUserEndpoints();
app.MapScheduleEndpoints();
app.MapPersonEndpoints();
app.Run();
