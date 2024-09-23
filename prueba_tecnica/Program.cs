using Microsoft.EntityFrameworkCore;
using prueba_tecnica.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar el contexto de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Cambiar a AddControllersWithViews para permitir vistas y controladores
builder.Services.AddControllersWithViews();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Sirve archivos estáticos como CSS, imágenes, etc.
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // Ruta para controladores con vistas

app.MapControllerRoute(
    name: "palindromo",
    pattern: "{controller=Palindromo}/{action=Index}/{id?}"); // Ruta para el controlador Palindromo

app.Run();
