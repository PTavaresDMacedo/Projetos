using McKing.Model;
using McKing.Repository.Implementation;
using McKing.Repository.Interface;
using McKing.Service.Implementation;
using McKing.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Adding Repositories
builder.Services.AddScoped<IRepository<Category, int>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Difficulty, int>, DifficultyRepository>();
builder.Services.AddScoped<IRepository<Ingredient, int>, IngredientRepository>();
builder.Services.AddScoped<IIngredientLineRepository, IngredientLineRepository>();
builder.Services.AddScoped<IRepository<Measure, int>, MeasureRepository>();
builder.Services.AddScoped<IRepository<Recipe, int>, RecipeRepository>();
builder.Services.AddScoped<IRepository<User, int>, UserRepository>();

//Adding Services
builder.Services.AddScoped<IService<Category, int>, CategoryService>();
builder.Services.AddScoped<IService<Difficulty, int>, DifficultyService>();
builder.Services.AddScoped<IService<Ingredient, int>, IngredientService>();
builder.Services.AddScoped<IIngredientLineService, IngredientLineService>();
builder.Services.AddScoped<IService<Measure, int>, MeasureService>();
builder.Services.AddScoped<IService<Recipe, int>, RecipeService>();
builder.Services.AddScoped<IService<User, int>, UserService>();


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
