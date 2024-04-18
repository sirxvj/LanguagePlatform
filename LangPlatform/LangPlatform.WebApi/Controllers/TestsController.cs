using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestsController:ControllerBase
{
   private readonly ITestService _testService;
   private readonly ILessonService _lessonService;
   private readonly IRepository<Language> _languageRepository;
   private readonly IRepository<Category> _categoryRepository;
   private readonly IArticleService _articleService;
   public TestsController(ITestService testService,
      ILessonService lessonService,
      IRepository<Language> languageRepository, 
      IRepository<Category> categoryRepository,
      IArticleService articleService)
   {
      _testService = testService;
      _lessonService = lessonService;
      _languageRepository = languageRepository;
      _categoryRepository = categoryRepository;
      _articleService = articleService;
   }

   [HttpGet]
   public async Task Generator()
   {
      // var en = await _languageRepository.CreateAsync(new Language{Name = "English"});
      // var es = await _languageRepository.CreateAsync(new Language{Name = "Español"});
      // var ru = await _languageRepository.CreateAsync(new Language{Name = "Русский"});
      //
      // var a1 = await _categoryRepository.CreateAsync(new Category {  Name = "A1" });
      // var a2 = await _categoryRepository.CreateAsync(new Category {  Name = "A2" });
      // var b1 =await _categoryRepository.CreateAsync(new Category { Name = "B1" });
      // var b2 =await _categoryRepository.CreateAsync(new Category {  Name = "B2" });
      // var c1 =await _categoryRepository.CreateAsync(new Category {  Name = "C1" });
      // var c2 =await _categoryRepository.CreateAsync(new Category {  Name = "C2" });
      // var c4 =await _categoryRepository.CreateAsync(new Category { Name = "C4" });

      
      
      // await _articleService.UploadArticle(new CreateArticleDto(
      //    new CreateLessonDto(
      //       "Present Simple doesnt exists",
      //       null,
      //              Guid.Parse("8997ebb8-764f-40ca-b83c-ca4d694952aa"),
      //       Guid.Parse("3b06579f-57e6-4cfa-8419-c27422db0838"),
      //       Guid.Parse("d2d20f8a-aadd-494c-b528-00d471765c8f")
      //       ),
      //     new List<SectionDto>
      //    {
      //       new SectionDto(
      //          0,
      //          "Government lied to us",
      //          "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim aeque doleamus animo, cum corpore dolemus, fieri tamen permagna accessio potest, si aliquod aeternum et infinitum impendere.\n\nUllus investigandi veri, nisi inveneris, et quaerendi defatigatio turpis est, cum esset accusata et vituperata ab Hortensio. Qui liber cum et mortem contemnit, qua qui est imbutus quietus esse numquam potest. Praeterea bona praeterita grata recordatione renovata delectant. Est autem situm in nobis ut et voluptates et dolores nasci fatemur e corporis voluptatibus et doloribus -- itaque concedo, quod modo dicebas, cadere causa, si qui.\n\nUllus investigandi veri, nisi inveneris, et quaerendi defatigatio turpis est, cum esset accusata et vituperata ab Hortensio. Qui liber cum et mortem contemnit, qua qui est imbutus quietus esse numquam potest. Praeterea bona praeterita grata recordatione renovata delectant. Est autem situm in.",
      //          null
      //          ),
      //       new SectionDto(
      //          1,
      //          "We should exposethem",
      //          "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim aeque doleamus animo, cum corpore dolemus, fieri tamen permagna accessio potest, si aliquod aeternum et infinitum impendere malum nobis opinemur. Quod idem licet transferre in voluptatem, ut postea variari voluptas distinguique possit, augeri amplificarique non possit. At etiam Athenis, ut e patre audiebam facete.\n\nUllus investigandi veri, nisi inveneris, et quaerendi defatigatio turpis est, cum esset accusata et vituperata ab Hortensio. Qui liber cum et mortem contemnit, qua qui est imbutus quietus esse numquam potest. Praeterea bona praeterita grata recordatione renovata delectant. Est autem situm.\n\nUllus investigandi veri, nisi inveneris, et quaerendi defatigatio turpis est, cum esset accusata et vituperata ab Hortensio. Qui liber cum et mortem contemnit, qua qui est imbutus quietus esse numquam potest. Praeterea bona praeterita grata recordatione renovata delectant. Est autem situm in nobis ut et voluptates et dolores nasci fatemur e corporis voluptatibus et doloribus -- itaque concedo.\n\nUllus investigandi veri, nisi inveneris, et quaerendi defatigatio turpis est, cum esset accusata et vituperata ab Hortensio. Qui liber cum et mortem contemnit, qua qui est imbutus quietus esse numquam potest. Praeterea bona praeterita grata.\n\nUllus investigandi veri, nisi inveneris, et quaerendi defatigatio turpis est, cum esset accusata et vituperata ab Hortensio. Qui liber cum et mortem contemnit, qua qui est imbutus quietus esse numquam potest. Praeterea bona praeterita grata recordatione renovata delectant. Est autem situm in nobis ut et voluptates et dolores nasci fatemur e corporis voluptatibus et doloribus -- itaque concedo, quod modo dicebas, cadere causa, si qui incurrunt, numquam.Ullus investigandi veri, nisi inveneris, et quaerendi defatigatio turpis est, cum esset accusata et vituperata ab Hortensio. Qui liber cum et mortem contemnit, qua qui est imbutus quietus esse numquam potest.\n\nUllus investigandi veri, nisi inveneris, et quaerendi defatigatio turpis est, cum esset accusata et vituperata ab Hortensio. Qui liber cum et mortem contemnit, qua qui est imbutus quietus esse numquam potest. Praeterea bona praeterita grata recordatione renovata delectant. Est autem situm in nobis ut et voluptates et dolores nasci fatemur e corporis voluptatibus et doloribus -- itaque concedo, quod modo dicebas, cadere causa, si qui incurrunt, numquam vim.\n\nUllus investigandi veri, nisi inveneris, et quaerendi defatigatio turpis est, cum esset accusata et vituperata ab Hortensio. Qui liber cum et mortem contemnit, qua qui est imbutus quietus esse numquam potest. Praeterea.",
      //       null
      //       ),
      //       new SectionDto(
      //          2,
      //          "Conclusion",
      //          "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim aeque doleamus animo, cum corpore dolemus, fieri tamen permagna accessio potest, si aliquod aeternum et infinitum impendere.\n\nUllus investigandi veri, nisi inveneris, et quaerendi defatigatio turpis est, cum esset accusata et vituperata ab Hortensio. Qui liber cum et mortem contemnit, qua qui est imbutus quietus esse numquam potest. Praeterea bona praeterita grata recordatione renovata delectant. Est autem situm in nobis ut et voluptates et dolores nasci fatemur e corporis voluptatibus et doloribus -- itaque concedo, quod modo dicebas, cadere causa, si qui.\n\nUllus investigandi veri, nisi inveneris, et quaerendi defatigatio turpis est, cum esset accusata et vituperata ab Hortensio. Qui liber cum et mortem contemnit, qua qui est imbutus quietus esse numquam potest. Praeterea bona praeterita grata recordatione renovata delectant. Est autem situm in.",
      //          null
      //       )
      //    }
      // ));

   }


   [HttpPost]
   public async Task Post([FromBody]Cringe cringe)
   {
      Console.WriteLine(cringe.Title);
      return ;
   }
}