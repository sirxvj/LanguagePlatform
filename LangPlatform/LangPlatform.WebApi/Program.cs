using Application.Middleware;
using LangPlatform;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging(o => { });
builder.Services.Configurator(builder);


var app = builder.Build();
app.UseHttpLogging();
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
 //MockManager manager = new MockManager(app.Services.GetService<IRepository<User>>()!, app.Services.GetService<IRepository<AnswerItem>>()!, app.Services.GetService<IRepository<Article>>()!,app.Services.GetService<IRepository<Category>>()!,app.Services.GetService<IRepository<Language>>()!,app.Services.GetService<IRepository<Lesson>>()!,app.Services.GetService<IRepository<Media>>()!,app.Services.GetService<IRepository<QuestionItem>>()!,app.Services.GetService<IRepository<Review>>()!,app.Services.GetService<IRepository<Section>>()!,app.Services.GetService<IRepository<Topic>>()!,app.Services.GetService<IRepository<Test>>()!,app.Services.GetService<IAccountService>()!,app.Services.GetService<ITestService>()!,app.Services.GetService<IArticleService>()!);
 //await manager.Generate();
//
// var res = await manager.GetTest();
// Console.WriteLine(JsonSerializer.Serialize(res));
//
//MockClientExecutor client = new MockClientExecutor(app.Services.GetService<IAccountService>()!,
    // app.Services.GetService<IArticleService>()!,
    // app.Services.GetService<ILessonService>()!,
    // app.Services.GetService<ITestService>()!,
    // app.Services.GetService<ILanguageService>()!,
    // app.Services.GetService<ICategoryService>()!);
//await client.StartUp();

app.Run();

