import { CreateLesson } from "./CreateLesson";
import { Section } from "./Section";

export interface CreateArticle{
    lesson : CreateLesson,
    sections : Section[]
}