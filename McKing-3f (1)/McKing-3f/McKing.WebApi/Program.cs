using McKing.Model;
using McKing.Repository.Implementation;
using McKing.Repository.Interface;
using McKing.Service.Implementation;
using McKing.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

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


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();