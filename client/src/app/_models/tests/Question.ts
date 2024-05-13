import { Media } from "../lesson/Media";
import { Answer } from "./Answer";

export interface Question{
    title:string,
    description:string,
    media:Media|undefined,
    answers:Answer[]
}