using Microsoft.EntityFrameworkCore;
using Net6_EF_Repository.Repositories;
using Net6_EF_Repository.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register dependency injection Branches
builder.Services.AddTransient<IBranchesRepository, BranchesRepository>();
builder.Services.AddTransient<IBranchesService, BranchesService>();

builder.Services.AddDbContext<BranchMgmtContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

//register dependency injection Applications
builder.Services.AddTransient<IApplicationsRepository, ApplicationsRepository>();
builder.Services.AddTransient<IApplicationsService, ApplicationsService>();


var app = builder.Build();

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
