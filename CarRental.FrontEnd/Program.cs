using CarRental.Core.Contracts;
using CarRental.Core.Repositories;
using CarRental.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//file system
builder.Services.AddTransient<IClientRepository, ClientsDbRepository>(_ => new ClientsDbRepository("clients.csv"));
builder.Services.AddTransient<ICarsRepository, CarsDbRepository>(_ => new CarsDbRepository("clients.csv"));
//repo
builder.Services.AddTransient<ICarsRepository, CarsDbRepository>(_ => new CarsDbRepository("Server=localhost;Database=car_rental_db;Trusted_Connection=True;"));
builder.Services.AddTransient<IClientRepository, ClientsDbRepository>(_ => new ClientsDbRepository("Server=localhost;Database=car_rental_db;Trusted_Connection=True;"));
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>(_ => new EmployeeRepository("Server=localhost;Database=car_rental_db;Trusted_Connection=True;"));
builder.Services.AddTransient<IRentOrderRepository, OrdersDbRepository>(_ => new OrdersDbRepository("Server=localhost;Database=car_rental_db;Trusted_Connection=True;"));
//services
builder.Services.AddTransient<ICarsService, CarsService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IRentOrderService, RentOrderService>();
builder.Services.AddTransient<ICarRentService, CarRentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
