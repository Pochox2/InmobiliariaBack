using Inmo.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Inmo.App.Interfaces;
using Inmo.App.Servicios;
using Inmo.Infra.Repositorios;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite(connectionString));

builder.Services.AddScoped<InterfazPropRepo, PropiedadRepo>();
builder.Services.AddScoped<InterfazPropServ, PropiedadServ>();

builder.Services.AddScoped<InterfazCitaRepo, CitaRepo>();
builder.Services.AddScoped<InterfazCitaServ, CitaServ>();

builder.Services.AddScoped<InterfazClienteRepo, ClienteRepo>();
builder.Services.AddScoped<InterfazClienteServ, ClienteServ>();

builder.Services.AddScoped<InterfazContratoClienteRepo, ContratoClienteRepo>();
builder.Services.AddScoped<InterfazContratoClienteServ, ContratoClienteServ>();

builder.Services.AddScoped<InterfazContratoRepo, ContratoRepo>();
builder.Services.AddScoped<InterfazContratoServ, ContratoServ>();

builder.Services.AddScoped<InterfazFacturaRepo, FacturaRepo>();
builder.Services.AddScoped<InterfazFacturaServ, FacturaServ>();

builder.Services.AddScoped<InterfazImgRepo, PropiedadImagenRepo>();
builder.Services.AddScoped<InterfazImgServ, ImagenServ>();

builder.Services.AddScoped<InterfazPagoRepo, PagoRepo>();
builder.Services.AddScoped<InterfazPagoServ, PagoServ>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Database.Migrate();

    DbSeeder.Seed(context);
}

app.UseSwagger();
app.UseSwaggerUI();


//app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
