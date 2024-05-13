import { Media } from "../lesson/Media";
import { Answer } from "./Answer";
import { CreateAnswer } from "./CreateAnswer";

export interface CreateQuestion{
    title:string,
    description:string,
    media:Media|undefined,
    answers:CreateAnswer[]
}