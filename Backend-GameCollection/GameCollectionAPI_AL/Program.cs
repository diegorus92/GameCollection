

using GameCollectionAPI_BL.Services;
using GameCollectionAPI_DAL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionSettings")["ConnectionString"]);
});
builder.Services.AddScoped<DbContext,DatabaseContext>();

builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IDevelopmentCompanyService,DevelopmentCompanyService>();
builder.Services.AddScoped<IGameService,GameService>();
builder.Services.AddScoped<IGameImageService,GameImageService>();


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

app.UseHttpsRedirection();
app.UseCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
