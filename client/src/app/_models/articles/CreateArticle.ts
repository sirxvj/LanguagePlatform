import { CreateLesson } from "../lesson/CreateLesson";
import { Section } from "./Section";

export interface CreateArticle{
    lesson : CreateLesson,
    sections : Section[]
}