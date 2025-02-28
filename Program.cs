var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession();
/* builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Set timeout to 20 minutes
    options.Cookie.HttpOnly = true; // Makes cookie accessible only via HTTP
    options.Cookie.IsEssential = true; // Ensures session persists even if tracking is disabled
}); */
builder.Services.AddScoped<MyIncomeExpenseApp.Filters.CheckSessionAttribute>();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<MyIncomeExpenseApp.Data.DatabaseHelper>();

var app = builder.Build();
app.UseSession();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{ 
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
