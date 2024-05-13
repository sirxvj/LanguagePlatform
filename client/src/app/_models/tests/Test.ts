import { Lesson } from "../lesson/Lesson";
import { Question } from "./Question";


export interface Test{
    id:string,
    description:string,
    lesson:Lesson,
    questions:Question[]
}
