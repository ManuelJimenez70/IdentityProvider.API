
using IdentityProvaider.API.AplicationServices;
using IdentityProvaider.API.Queries;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Infraestructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBIdentityProvaider"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordRepository, SecurityPasswordsRepository>();
builder.Services.AddScoped<UserQueries>();
builder.Services.AddScoped<UserServices>();

builder.Services.AddScoped<ILogUserRepository, LogUserRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();


builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<RoleQueries>();
builder.Services.AddScoped<RoleServices>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidateAudience = false,
            ValidateIssuer = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
