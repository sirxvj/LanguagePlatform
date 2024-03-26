using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace LangPlatform;

public class MockManager
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<AnswerItem> _answerRepository;
    private readonly IRepository<Article> _articleRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Language> _languageRepository;
    private readonly IRepository<Lesson> _lessonRepository;
    private readonly IRepository<MediaLesson> _mediaRepository;
    private readonly IRepository<MediaQuestion> _mediaQRepository;
    private readonly IRepository<MediaTopic> _mediaTRepository;
    private readonly IRepository<QuestionItem> _questionRepository;
    private readonly IRepository<Review> _reviewRepository;
    private readonly IRepository<Section> _sectionRepository;
    private readonly IRepository<Topic> _topicRepository;
    private readonly IRepository<Test> _testRepository;
    private readonly IAccountService _accountService;
    private readonly ITestService _testService;
    public MockManager(IRepository<User> userRepository, IRepository<AnswerItem> answerRepository, IRepository<Article> articleRepository, IRepository<Category> categoryRepository, IRepository<Language> languageRepository, IRepository<Lesson> lessonRepository, IRepository<MediaLesson> mediaRepository, IRepository<MediaQuestion> mediaQRepository, IRepository<MediaTopic> mediaTRepository, IRepository<QuestionItem> questionRepository, IRepository<Review> reviewRepository, IRepository<Section> sectionRepository, IRepository<Topic> topicRepository, IRepository<Test> testRepository, IAccountService accountService, ITestService testService)
    {
        _userRepository = userRepository;
        _answerRepository = answerRepository;
        _articleRepository = articleRepository;
        _categoryRepository = categoryRepository;
        _languageRepository = languageRepository;
        _lessonRepository = lessonRepository;
        _mediaRepository = mediaRepository;
        _mediaQRepository = mediaQRepository;
        _mediaTRepository = mediaTRepository;
        _questionRepository = questionRepository;
        _reviewRepository = reviewRepository;
        _sectionRepository = sectionRepository;
        _topicRepository = topicRepository;
        _testRepository = testRepository;
        _accountService = accountService;
        _testService = testService;
    }

    public async Task Generate()
    {
        // await _accountService.Register(new RegistrationDto("User", "email",
        //     "password")); //{Email = "niggadiai@gmail.com",Username = "User",Password = "password"});
        // await _accountService.Register(new RegistrationDto("GigaNiga", "email",
        //     "password")); //{Email = "niggadiai@gmail.com",Username = "User",Password = "password"});
        //
        // await _accountService.Register(new RegistrationDto("BigDig228", "email",
        //     "password")); //{Email = "niggadiai@gmail.com",Username = "User",Password = "password"});
        //
        //
        //
        // await _categoryRepository.CreateAsync(new Category{Id = Guid.NewGuid(), Name="Easy"});
        // await _categoryRepository.CreateAsync(new Category{Id = Guid.NewGuid(), Name="Medium"});
        // await _categoryRepository.CreateAsync(new Category{Id = Guid.NewGuid(), Name="Hard"});
        //
        // await _languageRepository.CreateAsync(new Language { Id = Guid.NewGuid(), Name = "English" });
        // await _languageRepository.CreateAsync(new Language { Id = Guid.NewGuid(), Name = "Espaniol" });
        // await _languageRepository.CreateAsync(new Language { Id = Guid.NewGuid(), Name = "Russian" });

        // await _testService.AddTest(
        //         new CreateTestDto(
        //             "Test title",
        //             "Test description",
        //             new CreateLessonDto(
        //                 null,
        //                 new Guid("c3c3df62-a539-48c4-bc2d-a6ef59524f2d"),
        //                 new Guid("01d9bbdc-92b8-4f29-adac-d52f4681ec86"),
        //                 new Guid("389bd972-02f1-47f1-96d0-c29830f8a71c")
        //                 ),
        //             new List<CreateQuestionDto>{
        //                 new CreateQuestionDto(
        //                     "What the fuck",
        //                     "Are you doing motherfucker",
        //                     null,
        //                     new List<CreateAnswerDto>{
        //                         new CreateAnswerDto(
        //                             "Yes",
        //                             true
        //                             ),
        //                         new CreateAnswerDto(
        //                             "No",
        //                             false
        //                             )
        //                     }
        //                     )
        //                 }
        //             )
        //     );
        //
    }

    public async Task<TestObjectDto?> GetTest()
    {
        return await _testService.GetTest(new Guid("c408926c-9dd6-43d7-9a26-92193ff2dc14"));
    }
    // public async Task<IEnumerable<Language?>?> GetAll()
    // {
    //     return await _languageRepository.GetAllAsync(x => x.Name == "nibba2");
    // }
}