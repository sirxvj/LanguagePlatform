using System.Collections;
using System.Formats.Asn1;
using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace LangPlatform.Controllers.MockClient;

public record SearchLessonFilter
{
    public string? Language { get; set; }
    public string? Category { get; set; }
    public int Approved { get; set; }
    public string? LessonType { get; set; }
}
public class MockClientExecutor
{
    private readonly IAccountService _accountService;
    private readonly IArticleService _articleService;
    private readonly ILessonService _lessonService;
    private readonly ITestService _testService;
    private readonly ILanguageService _languageService;
    private readonly ICategoryService _categoryService;
    private TokenResponseDto? CurrentUser { get; set; }
    
    public MockClientExecutor(IAccountService accountService, IArticleService articleService, ILessonService lessonService, ITestService testService, ILanguageService languageService, ICategoryService categoryService)
    {
        _accountService = accountService;
        _articleService = articleService;
        _lessonService = lessonService;
        _testService = testService;
        _languageService = languageService;
        _categoryService = categoryService;
    }

    public async Task StartUp()
    {
        string? ans = String.Empty;
        while (ans!="1"&&ans!="2")
        {
            Console.WriteLine("1.Login\n2.Register");
            ans = Console.ReadLine();
        }
        // if(ans=="1") await Login();
        // else await Register();
        // ClearConsole();
        // await Menus();
    }

    // private async Task Menus()
    // {
    //     string? filters = String.Empty;
    //     ClearConsole();
    //     while ( filters != "1" && filters != "2" && filters!="3")
    //     {
    //         Console.WriteLine("1.Study\n2.Teach\n3.Logout");
    //         filters = Console.ReadLine();
    //     }
    //     if(filters == "1") await Study();
    //     else if(filters=="2") await Teach();
    //     else
    //     {
    //         Console.Clear();
    //         CurrentUser = null;
    //         await StartUp();
    //     }
    // }
    //
    // private async Task Login()
    // {
    //     Console.WriteLine("Username:");
    //     var login = Console.ReadLine();
    //     
    //     Console.WriteLine("Password:");
    //     var password = Console.ReadLine();
    //     
    //     if (login.IsNullOrEmpty() || password.IsNullOrEmpty())
    //     {
    //         await Login();
    //         return;
    //     }
    //     CurrentUser = await _accountService.Login(new LoginDto(login!,password!));
    //     if (CurrentUser is null)
    //     {
    //         Console.WriteLine("Wrong");
    //         await Login();
    //     }
    // }
    //
    // private async Task Register()
    // {
    //     Console.WriteLine("Username:");
    //     var login = Console.ReadLine();
    //     Console.WriteLine("Email:");
    //     var email = Console.ReadLine();
    //     
    //     Console.WriteLine("Password:");
    //     var password = Console.ReadLine();
    //     
    //     if (login.IsNullOrEmpty() || password.IsNullOrEmpty())
    //     {
    //         await Register();
    //         return;
    //     }
    //     CurrentUser = await _accountService.Register(new RegistrationDto(login!,email!,password!));
    //     if (CurrentUser is null)
    //     {
    //         Console.WriteLine("Wrong");
    //         await Register();
    //     }
    // }
    //
    // private async Task Teach()
    // {
    //     ClearConsole();
    //     Console.WriteLine($"1.Create Lesson\n2.Show Unapproved(admin only)\n3.Back");
    //     var ans = Console.ReadLine();
    //     int index = 0;
    //     while (!Int32.TryParse(ans,out index) || index >3)
    //     {
    //         Console.WriteLine("Wrong");
    //         ans = Console.ReadLine();
    //     }
    //
    //     if (index == 1)
    //     {
    //         Console.WriteLine("Choose lesson type:\n1.Test\n2.Article\n3.Translate(soon)");
    //         ans = Console.ReadLine();
    //         index = 0;
    //         while (!Int32.TryParse(ans,out index) || index >3)
    //         {
    //             Console.WriteLine("Wrong");
    //             ans = Console.ReadLine();
    //         }
    //
    //         if (index == 1) await CreateTest();
    //         else if (index == 2) await CreateArticle();
    //     }
    //     else if (index == 2)
    //     {
    //         throw new NotImplementedException();
    //     }
    //     else
    //     {
    //         await Menus();
    //     }
    // }
    //
    // private async Task CreateTest()
    // {
    //     ClearConsole();
    //     var language = await ChooseLanguage();
    //     var category = await ChooseCategory();
    //     
    //     Console.WriteLine("Test title:");
    //     var title = Console.ReadLine();
    //     Console.WriteLine("Test description:");
    //     var description = Console.ReadLine();
    //
    //     List<CreateQuestionDto> questions = new List<CreateQuestionDto>();
    //     var ans = string.Empty;
    //     while (ans != "2")
    //     {
    //         Console.WriteLine("1.Add Question\n2.Done");
    //         ans = Console.ReadLine();
    //         if (ans == "1")
    //         {
    //             List<CreateAnswerDto> answers = new List<CreateAnswerDto>();
    //             Console.WriteLine("Question title:");
    //             var questionTitle = Console.ReadLine();
    //             Console.WriteLine("Question description:");
    //             var questionDescription = Console.ReadLine();
    //             ans = String.Empty;
    //             while (ans!="2")
    //             {
    //                 Console.WriteLine("1.Add Answer\n2.Done");
    //                 ans = Console.ReadLine();
    //                 if (ans == "1")
    //                 {
    //                     Console.WriteLine("Answer:");
    //                     var answer = Console.ReadLine();
    //                     Console.WriteLine("Is it correct? 1.Yes\n2.No");
    //                     ans = Console.ReadLine();
    //                     if(ans=="1") answers.Add(new CreateAnswerDto(answer??"Untitled",true));
    //                     else answers.Add(new CreateAnswerDto(answer??"Untitled",false));
    //                     ans = string.Empty;
    //                 }
    //             }
    //             questions.Add(new CreateQuestionDto(questionTitle??"Untitled",questionDescription??"Untitled",null,answers));
    //             ans = String.Empty;
    //         }
    //     }
    //     
    //     var newTest = new CreateTestDto(
    //         
    //         description??String.Empty,
    //         new CreateLessonDto(
    //             title??"Untitled",
    //             null,
    //             CurrentUser?.Id,
    //             category?.Id,
    //             language?.Id
    //             ),
    //             questions
    //         );
    //     await _testService.AddTest(newTest);
    //     await Teach();
    // }
    // private async Task CreateArticle()
    // {
    //     ClearConsole();
    //     Console.WriteLine("Article title:");
    //     var title = Console.ReadLine();
    //     var language = await ChooseLanguage();
    //     var category = await ChooseCategory();
    //     CreateLessonDto lesson = new CreateLessonDto(
    //         title??"Untitled",
    //         null,
    //         CurrentUser?.Id,
    //         category?.Id,
    //         language?.Id
    //     );
    //     List<SectionDto> sections = new List<SectionDto>();
    //     var ans = string.Empty;
    //     int order = 0;
    //     while (ans!="2")
    //     {
    //         Console.WriteLine("1.Add Section\n2.Done");
    //         ans = Console.ReadLine();
    //         if (ans == "1")
    //         {
    //             ans = string.Empty;
    //             Console.WriteLine("Section title:");
    //             var sectionTitle = Console.ReadLine();
    //             Console.WriteLine("Section text:");
    //             var sectionText = Console.ReadLine();
    //             sections.Add(new SectionDto(
    //                 order++,
    //                 sectionTitle,
    //                 sectionText,
    //                 null
    //                 ));
    //         }
    //     }
    //
    //     await _articleService.UploadArticle(new CreateArticleDto(
    //         lesson, sections
    //     ));
    //     await Teach();
    // }
    //
    // private async Task Study()
    // {
    //     ClearConsole();
    //     SearchLessonFilter filter = new SearchLessonFilter();
    //     var langs = await _languageService.GetAll();
    //     var categories = await _categoryService.GetAll();
    //     string? ans = String.Empty;
    //     while (ans!="1"&&ans!="2"&&ans!="3")
    //     {
    //         Console.WriteLine("1.Show Tests\n2.Show Articles\n3.Filter");
    //         ans = Console.ReadLine();   
    //     }
    //     filter.LessonType = ans == "1" ? "test" : ans == "2" ? "article" : null;
    //     if (filter.LessonType == "test")
    //     {
    //         await ShowTestList();
    //         return;
    //     }
    //     else if(filter.LessonType == "article")
    //     {
    //         await ShowArticleList();
    //         return;
    //     }
    //     
    //     Console.WriteLine("Filter Lessons: ");
    //     //---------------------------------------
    //     int index = 0;
    //     int choosenOption = 0;
    //     filter.Language = (await ChooseLanguage())?.Name ?? null;
    //     //---------------------------------------
    //     filter.Category = (await ChooseCategory())?.Name ?? null;
    //     //---------------------------------------
    //     Console.WriteLine("Choose Lesson type:\n1.Test\n2.Article\n3.Translation(soon)");
    //     choosenOption = 0;
    //     ans = Console.ReadLine();
    //     while (!Int32.TryParse(ans, out choosenOption) && choosenOption>3)
    //     {
    //         ans = Console.ReadLine();
    //     }
    //
    //     filter.LessonType = choosenOption switch
    //     {
    //         1=>"test",
    //         2=>"article",
    //         _=>null
    //     };
    //
    //     if (filter.LessonType == "test") await ShowTestList(filter);
    //     else await ShowArticleList(filter);
    // }
    // private async Task ShowTestList(SearchLessonFilter? filter=null)
    // {
    //     ClearConsole();
    //     var lessons = await _lessonService.GetFiltered(filter?.Language,filter?.Category,filter?.Approved, "test");
    //     List<LessonDto> filteredOrder = new List<LessonDto>();
    //     int index = 0;
    //     Console.WriteLine("№|Title\t\t|Type\t\t|Created At\t\t|Creator\t|Rating");
    //     foreach (var item in lessons)
    //     {
    //         var test = await _testService.GetTest(item.Id);
    //         if (test is not null)
    //         {
    //             Console.WriteLine(
    //                 $"{++index}.{item?.Title}\t|Test\t\t|{item.CreatedAt}\t|{item.Creator.Username}\t|{item.Avg}");
    //             filteredOrder.Add(item);
    //         }
    //     }
    //
    //     Console.WriteLine("q to exit in menu\n№ for test");
    //     var ans = Console.ReadLine();
    //     int choosen = 0;
    //     while (ans!="q"&& (!Int32.TryParse(ans,out choosen) || choosen>index))
    //     {
    //         ans = Console.ReadLine();
    //     }
    //
    //     if (ans == "q")
    //     {
    //         await Menus();
    //         return;
    //     }
    //
    //     var result = await _testService.GetTest(filteredOrder.ElementAt(choosen-1).Id);
    //     if (result is null)
    //     {
    //         await Study();
    //         return;
    //     }
    //     await ShowTest(result);
    // }
    //
    // private async Task ShowTest(TestObjectDto test)
    // {
    //     ClearConsole();
    //     int scores = 0;
    //     Console.WriteLine($"{test.Lesson.Title}\n" +
    //                       $"-----------------------------------------------\n" +
    //                       $"{test.Description}\n" +
    //                       $"-----------------------------------------------\n" +
    //                       $"1.Start Test\n2.Reviews\n3.Quit");
    //     var ans = Console.ReadLine();
    //     int index = 0;
    //     while (!Int32.TryParse(ans,out index) || index>3)
    //     {
    //         Console.WriteLine("Wrong");
    //         ans = Console.ReadLine();
    //     }
    //
    //     if (index == 1)
    //     {
    //         foreach (var question in test.QuestionItems)
    //         {
    //             Console.Clear();
    //             Console.WriteLine($"{question.Title}\n" +
    //                               $"{question.Description}\n" +
    //                               $"---------------------------------------------------" );
    //             index = 0;
    //             foreach (var answer in question.Answers)
    //             {
    //                 Console.WriteLine($"{++index}.{answer.Answer}");
    //             }
    //             ans = Console.ReadLine();
    //             index = 0;
    //             while (!Int32.TryParse(ans,out index) && index>question.Answers.Count)
    //             {
    //                 Console.WriteLine("Wrong");
    //             }
    //
    //             if (await _testService.CheckAccuracy(question.Answers[index - 1].Id) == true)
    //             {
    //                 scores++;
    //             }
    //         }
    //        
    //         Console.WriteLine($"Result:{scores}/{test.QuestionItems.Count}\n");
    //         Console.WriteLine("-------------------------------------------------");
    //         Console.WriteLine("1.Add Review\n2.Quit");
    //         ans = Console.ReadLine();
    //         if (ans=="1")
    //         {
    //             await CreateReview(test.Lesson.Id);
    //             return;
    //         }
    //         await Menus();
    //     }
    //     else if (ans == "2")
    //     {
    //         await ReviewList(test.Lesson.Id);
    //     }
    //     else await Menus();
    // }
    // private async Task ShowArticleList(SearchLessonFilter? filter=null)
    // {
    //     ClearConsole();
    //     var lessons = await _lessonService.GetFiltered(filter?.Language,filter?.Category,filter?.Approved, "article");
    //     List<LessonDto> filteredOrder = new List<LessonDto>();
    //     int index = 0;
    //     Console.WriteLine("№|Title\t\t|Type\t\t|Created At\t\t|Creator\t|Rating");
    //     foreach (var item in lessons)
    //     {
    //         var test = await _articleService.DownloadArticle(item.Id);
    //        
    //         if (test is not null)
    //         {
    //             Console.WriteLine(
    //                 $"{++index}.{item?.Title}\t|Article\t\t|{item.CreatedAt}\t|{item.Creator.Username}\t|{item.Avg}");
    //             filteredOrder.Add(item);
    //         }
    //     }
    //     Console.WriteLine("q to exit in menu\n№ for article");
    //     var ans = Console.ReadLine();
    //     int choosen = 0;
    //     while (ans!="q"&& (!Int32.TryParse(ans,out choosen) || choosen>index))
    //     {
    //         ans = Console.ReadLine();
    //     }
    //
    //     if (ans == "q")
    //     {
    //         await Menus();
    //         return;
    //     }
    //
    //     var result = await _articleService.DownloadArticle(filteredOrder.ElementAt(choosen-1).Id);
    //     if (result is null)
    //     {
    //         await Study();
    //         return;
    //     }
    //     await ShowArticle(result);
    // }
    // private async Task ShowArticle(ArticleDto article)
    // {
    //     ClearConsole();
    //     Console.WriteLine(article.Lesson.Title);
    //     foreach (var section in article.Sections)
    //     {
    //         Console.WriteLine("\t"+section.Title);
    //         Console.WriteLine(section.RawText);
    //     }
    //     Console.WriteLine("-------------------------------------------------");
    //     Console.WriteLine("1.Add Review\n2.Reviews\n3.Quit");
    //     var ans = Console.ReadLine();
    //     if (ans=="1")
    //     {
    //         await CreateReview(article.Lesson.Id);
    //         return;
    //     }
    //     else if (ans == "2")
    //     {
    //         await ReviewList(article.Lesson.Id);
    //         return;
    //     }
    //     await Menus();
    // }
    //
    // private async Task CreateReview(Guid lessonId)
    // {
    //     ClearConsole();
    //     Console.WriteLine("Review");
    //     Console.WriteLine("----------------------------------------------");
    //     Console.WriteLine("Review title:");
    //     var title = Console.ReadLine();
    //     Console.WriteLine("Review Body:");
    //     var body = Console.ReadLine();
    //     Console.WriteLine("Rate from 1 to 5");
    //     var ans = Console.ReadLine();
    //     int option = 0;
    //     while (!Int32.TryParse(ans,out option) || option>5||option<1)
    //     {
    //         Console.WriteLine("Wrong Format");
    //         ans=Console.ReadLine();
    //     }
    //     CreateReviewDto review = new CreateReviewDto(title??"Untitled",body??"none",option,CurrentUser.Id,lessonId);
    //     await _lessonService.AddReview(review);
    //     await Study();
    // }
    //
    // private async Task ReviewList(Guid lessonId)
    // {
    //     Console.Clear();
    //     Console.WriteLine("Reviews:");
    //     var reviews = await _lessonService.GetReviews(lessonId);
    //     foreach (var review in reviews)
    //     {
    //         Console.WriteLine("---------------------------------------------------");
    //         Console.WriteLine(review.User.Username + "\tRate:"+review.Rate);
    //         Console.WriteLine(review.Title);
    //         Console.WriteLine(review.Body);
    //     }
    //     Console.WriteLine("---------------------------------------------------");
    //     Console.WriteLine("Press any key...");
    //     Console.ReadKey();
    //     await Menus();
    // }
    // private void ClearConsole()
    // {
    //     Console.Clear();
    //     Console.WriteLine($"Hello, {CurrentUser?.Username}");
    // }
    //
    // private async Task<Language?> ChooseLanguage()
    // {
    //     var langs = await _languageService.GetAll();
    //     Console.WriteLine("Choose Language:");
    //     int index = 0;
    //     foreach (var language in langs)
    //     {
    //         Console.WriteLine(++index +"."+language?.Name);
    //     }
    //     Console.WriteLine(++index+".Any");
    //     int choosenOption = 0;
    //     var ans = Console.ReadLine();
    //     while (!Int32.TryParse(ans, out choosenOption) && choosenOption>index)
    //     {
    //         ans = Console.ReadLine();
    //     }
    //     
    //     return choosenOption<index ? langs.ElementAt(choosenOption - 1):null;
    // }
    // private async Task<Category?> ChooseCategory()
    // {
    //     var langs = await _categoryService.GetAll();
    //     Console.WriteLine("Choose Category:");
    //     int index = 0;
    //     foreach (var language in langs)
    //     {
    //         Console.WriteLine(++index +"."+language?.Name);
    //     }
    //     Console.WriteLine(++index+".Any");
    //     int choosenOption = 0;
    //     var ans = Console.ReadLine();
    //     while (!Int32.TryParse(ans, out choosenOption) && choosenOption>index)
    //     {
    //         ans = Console.ReadLine();
    //     }
    //     
    //     return choosenOption<index ? langs.ElementAt(choosenOption - 1):null;
    // }
}