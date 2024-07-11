
using AutoMapper;
using BookShop.Infrastructure;
using BookShop.Infrastructure.Repository;
using BookShop.Persistence.IRepositories;
using BookShop.Persistence.Mappers;
using BookShop.Services.Contract;
using BookShop.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthorization();
            builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapIdentityApi<IdentityUser>();
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
