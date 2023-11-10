using Receitas.Repository.Categories;
using Receitas.Repository.Difficulties;
using Receitas.Repository.Ingredients;
using Receitas.Repository.Measures;
using Receitas.Repository.RecipeIngredients;
using Receitas.Repository.Recipes;
using Receitas.Repository.Users;
using Receitas.Service.Categories;
using Receitas.Service.Difficulties;
using Receitas.Service.Ingredients;
using Receitas.Service.Measures;
using Receitas.Service.RecipeIngredients;
using Receitas.Service.Recipes;
using Receitas.Service.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDifficultyRepository, DifficultyRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IMeasureRepository, MeasureRepository>();
builder.Services.AddScoped<IRecipeIngredientsRepository, RecipeIngredientsRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IDifficultyService, DifficultyService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IMeasureService, MeasureService>();
builder.Services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IUserService, UserService>();

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
