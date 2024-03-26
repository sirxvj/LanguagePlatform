using Domain.DTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface ITestService
{
    Task AddTest(CreateTestDto test);
    Task<TestObjectDto?> GetTest(Guid lessonId);
    Task<bool?> CheckAccuracy(Guid answerId);
    Task AddQuestion(QuestionItem questionItem,Guid testId,IEnumerable<AnswerItem> answers);
}