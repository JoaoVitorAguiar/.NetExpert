using DevFreela.Application.Commands.Project.CreateProject;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistense;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserServices, UserService>();
builder.Services.AddScoped<ISkillsService, SkillService>();

// Busca todas as classes neesse assembly que o mediator especifica para o padr�o CQRS,
// Ou seja, busca todas as classes que implementam o IRquest<> e assicia ao IRequestHandler<>
builder.Services.AddMediatR(typeof(CreateProjectCommand));


builder.Services.AddDbContext<DevFreelaDbContext>(
    options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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

app.UseAuthorization();

app.MapControllers();

app.Run();
