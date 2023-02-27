using CustomerAPI.Models;
using DiscountCalculation.Library.Data;
using DiscountCalculation.Library.Interfaces;
using DiscountCalculation.Library.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DbContext>();
builder.Services.AddTransient<IDiscountService, DiscountService>();
// Add services to the container.
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

app.MapPost("/caculateDiscount", ([FromBody]Customer customer, [FromServices] IDiscountService discountService) =>
{
    var discountValue = discountService.Calculate(customer.Name, customer.IsClubMember, customer.PaymentMethod);

    var result = new DiscountResult { DiscountValue = discountValue };

    return discountValue != 0 ? Results.Ok(result) : Results.BadRequest();

})
.WithName("caculateDiscount")
.WithOpenApi();

app.Run();
