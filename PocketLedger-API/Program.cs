using PocketLedger;
using PocketLedger.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Pocket_database>();

var Pocket_web_app = builder.Build();

Pocket_web_app.UseSwagger();
Pocket_web_app.UseSwaggerUI();

Pocket_web_app.UseRouting();
Pocket_web_app.MapControllers();

Pocket_web_app.Run();
