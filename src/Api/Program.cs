using System.Reflection;
using Api.Mediator;
using Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Services.Validators.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine("Adding DB");
builder.Services.AddDbContext<PeopleContext>(opt =>
{
    opt.UseInMemoryDatabase("PeopleDB");
});

Console.WriteLine("Adding MediatR");
builder.Services.AddMediatRConf();

Console.WriteLine("Adding AutoMapper");
builder.Services.AddAutoMapper(Assembly.Load("Services"));


Console.WriteLine("Adding DI");
builder.Services.AddScoped<IPeopleContext, PeopleContext>();
builder.Services.AddScoped<ICommonValidators, CommonValidators>();

builder.Services.AddValidatorsFromAssembly(typeof(CommonValidators).Assembly);

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
