using AccessControlServer;
using AccessControlServer.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IEventsService, EventsService>();
builder.Services.AddSingleton<IEventsRepository, EventsRepository>();
InitialiseDatabase(builder);

var app = builder.Build();
new DatabaseSetup(app.Configuration);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void InitialiseDatabase(WebApplicationBuilder appBuilder)
{
    appBuilder.Services.AddSingleton<Func<IDbConnection>>(serviceProvider =>
    {
        var configuration = serviceProvider.GetService<IConfiguration>();
        return () =>
        {
            string endpoint = configuration?.GetConnectionString("AccessControlConnection") ??
                throw new InvalidOperationException("DB Connection was not configured in the appsettings");

            return new SqlConnection(endpoint);
        };
    });

    appBuilder.Services.AddSingleton<Func<IDbDataParameter>>(() => new SqlParameter());
}
