using Microsoft.EntityFrameworkCore;
using MyApiProject.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// DbContext servisini ekle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// HTTPS yönlendirmeyi kullan (isteðe baðlý ama genellikle önerilir)
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
