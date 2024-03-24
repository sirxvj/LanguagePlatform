using System.Text.Json;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Infrastructure.MockDb;
using LangPlatform;
using Newtonsoft.Json.Linq;


var builder = WebApplication.CreateBuilder(args);

ConfigureServices.Configure(builder.Services);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
MockManager manager = new MockManager(new MockJsonRepository<User>(), new MockJsonRepository<AnswerItem>(), new MockJsonRepository<Article>(),new MockJsonRepository<Category>(),new MockJsonRepository<Language>(),new MockJsonRepository<Lesson>(),new MockJsonRepository<MediaLesson>(),new MockJsonRepository<MediaQuestion>(),new MockJsonRepository<MediaTopic>(),new MockJsonRepository<QuestionItem>(),new MockJsonRepository<Review>(),new MockJsonRepository<Section>(),new MockJsonRepository<Topic>(),new MockJsonRepository<Test>(),app.Services.GetService<IAccountService>()!,app.Services.GetService<ITestService>()!);
// await manager.Generate();

var res = await manager.GetTest();
Console.WriteLine(res.ToString());
app.Run();

