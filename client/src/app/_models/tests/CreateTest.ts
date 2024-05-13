import { CreateLesson } from "../lesson/CreateLesson";
import { CreateQuestion } from "./CreateQuestion";



export interface CreateTest{
    description:string,
    lesson:CreateLesson,
    questions:CreateQuestion[]
}



// public record CreateTestDto(
//     string Description,
//     CreateLessonDto Lesson,
//     List<CreateQuestionDto> Questions
//     );