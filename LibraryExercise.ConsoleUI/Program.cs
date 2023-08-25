
using LibraryExercise.Application.Services;
using LibraryExercise.ConsoleUI.Services;
using LibraryExercise.Domain.Interfaces;
using LibraryExercise.Infrastructure;
using LibraryExercise.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddDbContext<LibraryDbContext>(options => options.UseInMemoryDatabase("LibraryDB"))
    .AddScoped<IBookRepository, BookRepository>()
    .AddScoped<BookService>()
    .AddScoped<MenuService>()
    .BuildServiceProvider();

var context = serviceProvider.GetRequiredService<LibraryDbContext>();
context.SeedData();

using var scope = serviceProvider.CreateScope();
var menuService = scope.ServiceProvider.GetRequiredService<MenuService>();

menuService.ShowMenu();