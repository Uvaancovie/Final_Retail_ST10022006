using Final_Retail.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the services
builder.Services.AddSingleton<ProductService>(sp =>
    new ProductService(builder.Configuration["Azure:TableStorage"], "Products"));

builder.Services.AddSingleton<CustomerProfileService>(sp =>
    new CustomerProfileService(builder.Configuration["Azure:TableStorage"], "CustomerProfiles"));

builder.Services.AddSingleton<OrderService>(sp =>
    new OrderService(builder.Configuration["Azure:QueueStorage"], "OrdersQueue"));


builder.Services.AddSingleton<FileUploadService>(sp =>
    new FileUploadService(builder.Configuration["Azure:FileShare"], "uploads"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
