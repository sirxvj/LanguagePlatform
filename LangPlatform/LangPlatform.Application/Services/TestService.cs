using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services;

public class TestService:ITestService
{
    private readonly IRepository<Test> _testRepository;
    private readonly IRepository<QuestionItem> _questionRepository;
    private readonly IRepository<AnswerItem> _answerRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Lesson> _lessonRepository;

    public TestService(IRepository<Test> testRepository, IRepository<QuestionItem> questionRepository, IRepository<AnswerItem> answerRepository, IRepository<User> userRepository, IRepository<Lesson> lessonRepository)
    {
        _testRepository = testRepository;
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
        _userRepository = userRepository;
        _lessonRepository = lessonRepository;
    }

    public async Task AddTest(CreateTestDto test)
    {
        Test newTest = test.Adapt<Test>();
        
        //Lesson newLesson = test.Lesson.Adapt<Lesson>();
        if (newTest.Lesson != null) newTest.Lesson.CreatedAt = DateTime.Now;

        User? creator = await _userRepository.GetAsync(test.Lesson.CreatorId??Guid.Empty);
        if (newTest.Lesson != null) newTest.Lesson.Approved = creator?.Role == RoleType.Admin;

        if (creator != null) await _userRepository.UpdateAsync(creator);

        //newLesson.Test = newTest;
        
        
       await _testRepository.CreateAsync(newTest);
        
        // IEnumerable<QuestionItem> questions = test.Questions.Adapt<IEnumerable<QuestionItem>>();
        // foreach (var question in questions)
        // {
        //     question.TestId = testId;
        //     IEnumerable<AnswerItem> answer = question.Answers.Adapt<IEnumerable<AnswerItem>>();
        //     question.Answers = null;
        //     var qid = await _questionRepository.CreateAsync(question);
        //     foreach (var ans in answer)
        //     {
        //         ans.QuestionItemId = qid;
        //         await _answerRepository.CreateAsync(ans);
        //     }
        //     
        // }
        
       
    }
    public async Task<TestObjectDto?> GetTest(Guid lessonId)
    {
        var testObj = await _testRepository.GetAsync(x => x.LessonId == lessonId);
        if (testObj is null)
            return null;
        // testObj.Lesson = await _lessonRepository.GetAsync(lessonId);
        // testObj.QuestionItems = (await _questionRepository.GetAllAsync(x => x.TestId == testObj.Id))!.ToList();
        // foreach (var question in testObj.QuestionItems)
        // {
        //     question!.Answers = ((await _answerRepository.GetAllAsync(x => x.QuestionItemId == question.Id))!).ToList()!;
        // }
        TestObjectDto testRes = testObj.Adapt<TestObjectDto>();

        return testRes;
    }

    public async Task<bool?> CheckAccuracy(Guid answerId)
    {
        var answer = await _answerRepository.GetAsync(answerId);
        if (answer is null)
            return null;
        return answer.Accuracy;
    }

    public Task AddQuestion(QuestionItem questionItem, Guid testId, IEnumerable<AnswerItem> answers)
    {
        throw new NotImplementedException();
    }
}