import { Creator } from "./Creator";
import { Lesson } from "./Lesson";

export interface Review{
    createdAt:string,
    title:string,
    body:string,
    rate:number,
    lesson :Lesson,
    user:Creator
}