import { Lesson } from "../lesson/Lesson";
import { Section } from "./Section";

export interface Article{
    lesson : Lesson,
    sections : Section[]
}