using GoTrip.Aplicaciones.Mapper;
using GoTrip.Aplicaciones.Services.Implementacion;
using GoTrip.Aplicaciones.Services.Interfaces;
using GoTrip.Datos.Context;
using GoTrip.Datos.Repository;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Reemplaza con la URL de tu frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); // Si usas autenticación basada en cookies o tokens
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("mysql");

var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

builder.Services.AddDbContext<GoTripContext>(dbConection => dbConection.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IPuntoTuristicoService, PuntoTuristicoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IUbicacionService, UbicacionService>();
builder.Services.AddScoped<IComentarioService, ComentarioService>();
builder.Services.AddScoped<IPlanViajeService, PlanViajeService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPuntoTuristicoRepository, PuntoTuristicoRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAutenticacionService, AutenticacionService>();
builder.Services.AddScoped<IPlanViajeRepository, PlanViajeRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IReporteRepository, ReporteRepository>();
builder.Services.AddScoped<IReporteService, ReporteService>();

builder.Services.AddAutoMapper(typeof(PuntoTuristicoProfile));
builder.Services.AddAutoMapper(typeof(CategoriaProfile));
builder.Services.AddAutoMapper(typeof(ComentarioProfile));
builder.Services.AddAutoMapper(typeof(PlanViajeProfile));
builder.Services.AddAutoMapper(typeof(UsuarioProfile));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Middleware de CORS (debe ir antes de UseAuthorization)
app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
