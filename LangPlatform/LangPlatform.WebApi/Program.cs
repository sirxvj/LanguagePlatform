using System.Text.Json;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.MockDb;
using LangPlatform;
using LangPlatform.Controllers;
using LangPlatform.Controllers.MockClient;
using Newtonsoft.Json.Linq;


var builder = WebApplication.CreateBuilder(args);

ConfigureServices.Configure(builder.Services,builder);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
MockManager manager = new MockManager(app.Services.GetService<IRepository<User>>()!, app.Services.GetService<IRepository<AnswerItem>>()!, app.Services.GetService<IRepository<Article>>()!,app.Services.GetService<IRepository<Category>>()!,app.Services.GetService<IRepository<Language>>()!,app.Services.GetService<IRepository<Lesson>>()!,app.Services.GetService<IRepository<MediaLesson>>()!,app.Services.GetService<IRepository<MediaQuestion>>()!,app.Services.GetService<IRepository<MediaTopic>>()!,app.Services.GetService<IRepository<QuestionItem>>()!,app.Services.GetService<IRepository<Review>>()!,app.Services.GetService<IRepository<Section>>()!,app.Services.GetService<IRepository<Topic>>()!,app.Services.GetService<IRepository<Test>>()!,app.Services.GetService<IAccountService>()!,app.Services.GetService<ITestService>()!,app.Services.GetService<IArticleService>()!);
 await manager.Generate();

var res = await manager.GetTest();
Console.WriteLine(JsonSerializer.Serialize(res));

MockClientExecutor client = new MockClientExecutor(app.Services.GetService<IAccountService>()!,
    app.Services.GetService<IArticleService>()!,
    app.Services.GetService<ILessonService>()!,
    app.Services.GetService<ITestService>()!,
    app.Services.GetService<ILanguageService>()!,
    app.Services.GetService<ICategoryService>()!);
await client.StartUp();

app.Run();

