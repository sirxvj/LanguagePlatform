// using Application.Interfaces;
// using Domain.DTOs;
// using Domain.Entities;
// using Domain.Interfaces;
//
// namespace LangPlatform;
//
// public class MockManager
// {
//     private readonly IRepository<User> _userRepository;
//     private readonly IRepository<AnswerItem> _answerRepository;
//     private readonly IRepository<Article> _articleRepository;
//     private readonly IRepository<Category> _categoryRepository;
//     private readonly IRepository<Language> _languageRepository;
//     private readonly IRepository<Lesson> _lessonRepository;
//     private readonly IRepository<Media> _mediaRepository;
//     private readonly IRepository<QuestionItem> _questionRepository;
//     private readonly IRepository<Review> _reviewRepository;
//     private readonly IRepository<Section> _sectionRepository;
//     private readonly IRepository<Topic> _topicRepository;
//     private readonly IRepository<Test> _testRepository;
//     private readonly IAccountService _accountService;
//     private readonly IArticleService _articleService;
//     private readonly ITestService _testService;
//     
//     public MockManager(IRepository<User> userRepository, IRepository<AnswerItem> answerRepository, IRepository<Article> articleRepository, IRepository<Category> categoryRepository, IRepository<Language> languageRepository, IRepository<Lesson> lessonRepository, IRepository<Media> mediaRepository, IRepository<QuestionItem> questionRepository, IRepository<Review> reviewRepository, IRepository<Section> sectionRepository, IRepository<Topic> topicRepository, IRepository<Test> testRepository, IAccountService accountService, ITestService testService, IArticleService articleService)
//     {
//         _userRepository = userRepository;
//         _answerRepository = answerRepository;
//         _articleRepository = articleRepository;
//         _categoryRepository = categoryRepository;
//         _languageRepository = languageRepository;
//         _lessonRepository = lessonRepository;
//         _mediaRepository = mediaRepository;
//         _questionRepository = questionRepository;
//         _reviewRepository = reviewRepository;
//         _sectionRepository = sectionRepository;
//         _topicRepository = topicRepository;
//         _testRepository = testRepository;
//         _accountService = accountService;
//         _testService = testService;
//         _articleService = articleService;
//     }
//
//     public async Task Generate()
//     {
//         await _accountService.Register(new RegistrationDto("User", "email",
//             "password")); //{Email = "niggadiai@gmail.com",Username = "User",Password = "password"});
//          await _accountService.Register(new RegistrationDto("GigaNiga", "email",
//             "password")); //{Email = "niggadiai@gmail.com",Username = "User",Password = "password"});
//         
//         await _accountService.Register(new RegistrationDto("BigDig228", "email",
//             "password")); //{Email = "niggadiai@gmail.com",Username = "User",Password = "password"});
//         var userGuid = (await _userRepository.GetAsync(x => x.Username == "GigaNiga"))?.Id;
//         
//         
//         await _categoryRepository.CreateAsync(new Category{ Name="Easy"});
//          await _categoryRepository.CreateAsync(new Category{ Name="Medium"});
//          var catGuid = await _categoryRepository.CreateAsync(new Category{ Name="Hard"});
//         
//         await _languageRepository.CreateAsync(new Language {  Name = "English" });
//        var langGuid = await _languageRepository.CreateAsync(new Language { Name = "Espaniol" });
//         await _languageRepository.CreateAsync(new Language { Name = "Russian" });
//
//         await _testService.AddTest(
//                 new CreateTestDto(
//                     
//                     "complex test for c4 level",
//                     new CreateLessonDto(
//                         "Oxford test",
//                         null,
//                         userGuid,
//                         catGuid,
//                         langGuid
//                         ),
//                     new List<CreateQuestionDto>{
//                         new CreateQuestionDto(
//                             "Translate in espaniol",
//                             "priimite labu pozhaluista",
//                             null,
//                             new List<CreateAnswerDto>{
//                                 new CreateAnswerDto(
//                                     "sadis desiat",
//                                     true
//                                     ),
//                                 new CreateAnswerDto(
//                                     "amigo muchacha sambrero",
//                                     false
//                                     ),
//                                 new CreateAnswerDto(
//                                     "mamma mia pepperoni",
//                                     false
//                                 )
//                             }
//                             ),
//                         new CreateQuestionDto(
//                             "What is missed",
//                             "No frameworks in couse work is a ______",
//                             null,
//                             new List<CreateAnswerDto>{
//                                 new CreateAnswerDto(
//                                     "Mistake",
//                                     true
//                                 ),
//                                 new CreateAnswerDto(
//                                     "Cringe",
//                                     true
//                                 )
//                             }
//                         )
//                         }
//                     )
//             );
//         await _articleService.UploadArticle(new CreateArticleDto(
//             new CreateLessonDto(
//                 "Present simple doesnt exists",
//                 null,
//                 userGuid,
//                 catGuid,
//                 langGuid
//                 ),
//             new List<SectionDto>()
//             {
//                 new SectionDto(
//                     0,
//                     " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras et venenatis metus. Nullam laoreet nisl in erat consectetur faucibus. In ipsum metus, viverra ac mauris quis, fermentum vehicula ligula. Nunc eu iaculis tortor. Sed elementum, risus at cursus laoreet, tellus neque vulputate purus, vitae finibus turpis nisl sit amet nunc. Integer vel elementum lectus, vel rutrum justo. Suspendisse fermentum lorem odio, quis dictum risus consectetur vitae. Nunc lacinia, nisi id feugiat vehicula, turpis lectus feugiat mi, a tincidunt elit orci ut nisl. Nulla malesuada urna sed leo blandit laoreet.\n\nFusce consequat et diam eu aliquet. Sed viverra ac nisl ut maximus. Ut molestie quis felis eu suscipit. In hac habitasse platea dictumst. Nullam eget odio nulla. Ut dolor nulla, facilisis non ullamcorper eget, consequat in nisi. Phasellus sed justo egestas, consectetur nibh ut, auctor nulla. Cras euismod consectetur diam. Aliquam dignissim efficitur diam, eu scelerisque ex faucibus vitae.\n\nDonec fringilla diam nec ex vulputate, lobortis porttitor lacus viverra. Curabitur aliquam nec justo in molestie. Praesent varius lectus ex, ut rhoncus tortor laoreet non. Ut auctor magna sit amet sagittis ultricies. Sed lacinia fringilla felis, et consequat nulla ullamcorper quis. Etiam ultricies vitae lectus quis aliquam. Donec viverra felis ac est elementum, vitae sollicitudin nulla fringilla. Curabitur blandit nisi sit amet leo interdum lobortis. Pellentesque libero ligula, viverra ac lacus non, luctus feugiat mauris. Pellentesque tristique sit amet orci eu vestibulum. Vivamus tristique vel neque ac vulputate.\n\nNullam et diam sollicitudin, aliquet nisi in, varius nisi. Phasellus eu nisi eleifend, dapibus dui et, lacinia mi. Morbi vitae neque mi. Aliquam convallis ex at erat imperdiet, ut tincidunt ante sodales. Pellentesque tincidunt libero non efficitur ultrices. Sed in lectus augue. Sed ac fringilla est. Morbi vel neque quis dui iaculis ultricies. Nam elementum tristique consectetur. Suspendisse ac nunc nisl. Integer viverra nisi pharetra urna fermentum tristique at sed purus. Phasellus et dignissim lectus, non pellentesque mauris. Donec at feugiat diam. Phasellus in lectus aliquet, finibus augue a, pretium nunc. Pellentesque molestie nulla id ullamcorper luctus. Vivamus eu dui nunc. ",
//                     null,
//                     null
//                     ),
//                 new SectionDto(
//                     1,
//                     "Conclusion",
//                     " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras et venenatis metus. Nullam laoreet nisl in erat consectetur faucibus. In ipsum metus, viverra ac mauris quis, fermentum vehicula ligula. Nunc eu iaculis tortor. Sed elementum, risus at cursus laoreet, tellus neque vulputate purus, vitae finibus turpis nisl sit amet nunc. Integer vel elementum lectus, vel rutrum justo. Suspendisse fermentum lorem odio, quis dictum risus consectetur vitae. Nunc lacinia, nisi id feugiat vehicula, turpis lectus feugiat mi, a tincidunt elit orci ut nisl. Nulla malesuada urna sed leo blandit laoreet.\n\nFusce consequat et diam eu aliquet. Sed viverra ac nisl ut maximus. Ut molestie quis felis eu suscipit. In hac habitasse platea dictumst. Nullam eget odio nulla. Ut dolor nulla, facilisis non ullamcorper eget, consequat in nisi. Phasellus sed justo egestas, consectetur nibh ut, auctor nulla. Cras euismod consectetur diam. Aliquam dignissim efficitur diam, eu scelerisque ex faucibus vitae.\n\nDonec fringilla diam nec ex vulputate, lobortis porttitor lacus viverra. Curabitur aliquam nec justo in molestie. Praesent varius lectus ex, ut rhoncus tortor laoreet non. Ut auctor magna sit amet sagittis ultricies. Sed lacinia fringilla felis, et consequat nulla ullamcorper quis. Etiam ultricies vitae lectus quis aliquam. Donec viverra felis ac est elementum, vitae sollicitudin nulla fringilla. Curabitur blandit nisi sit amet leo interdum lobortis. Pellentesque libero ligula, viverra ac lacus non, luctus feugiat mauris. Pellentesque tristique sit amet orci eu vestibulum. Vivamus tristique vel neque ac vulputate.\n\nNullam et diam sollicitudin, aliquet nisi in, varius nisi. Phasellus eu nisi eleifend, dapibus dui et, lacinia mi. Morbi vitae neque mi. Aliquam convallis ex at erat imperdiet, ut tincidunt ante sodales. Pellentesque tincidunt libero non efficitur ultrices. Sed in lectus augue. Sed ac fringilla est. Morbi vel neque quis dui iaculis ultricies. Nam elementum tristique consectetur. Suspendisse ac nunc nisl. Integer viverra nisi pharetra urna fermentum tristique at sed purus. Phasellus et dignissim lectus, non pellentesque mauris. Donec at feugiat diam. Phasellus in lectus aliquet, finibus augue a, pretium nunc. Pellentesque molestie nulla id ullamcorper luctus. Vivamus eu dui nunc. ",
//                     null
//                     ),
//             }
//             ));
//
//     }
//
//     public async Task<User?> GetTest()
//     {
//         return await _userRepository.GetAsync(x=>x.Username=="GigaNiga");
//     }
//     // public async Task<IEnumerable<Language?>?> GetAll()
//     // {
//     //     return await _languageRepository.GetAllAsync(x => x.Name == "nibba2");
//     // }
// }