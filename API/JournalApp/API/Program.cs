using API.Controllers.Journal.V1.Repository;
using API.Controllers.Journal.V1.Services;
using API.Data;
using API.Data.Identity;
using API.Helpers;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddDbContext<JournalContext>(
    x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddDbContext<AppIdentityDbContext>(x =>
{
    x.UseSqlite(builder.Configuration.GetConnectionString("IdentityConnection"));
});
builder.Services.AddIdentityServices();


builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<IJournalRepository, JournalRepository>();
builder.Services.AddScoped<IJournalService, JournalService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(
    options => options.WithOrigins("*").AllowAnyMethod()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
