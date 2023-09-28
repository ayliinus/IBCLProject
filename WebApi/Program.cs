using Business.AccountBusiness;
using Business.AssetBusiness;
using Business.PortfolioBusiness;
using Business.PositionBusiness;
using Context;
using Microsoft.EntityFrameworkCore;
using Repository.AccountRepository;
using Repository.AssetRepository;
using Repository.PortfolioRepository;
using Repository.PositionRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAccountRepositoryService, AccountRepositoryService>();
builder.Services.AddScoped<IAssetRepositoryService, AssetRepositoryService>();
builder.Services.AddScoped<IPortfolioRepositoryService, PortfolioRepositoryService>();
builder.Services.AddScoped<IPositionRepositoryService, PositionRepositoryService>();
builder.Services.AddScoped<IAccountBusinessService, AccountBusinessService>();
builder.Services.AddScoped<IAssetBusinessService, AssetBusinessService>();
builder.Services.AddScoped<IPortfolioBusinessService, PortfolioBusinessService>();
builder.Services.AddScoped<IPositionBusinessService, PositionBusinessService>();

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
