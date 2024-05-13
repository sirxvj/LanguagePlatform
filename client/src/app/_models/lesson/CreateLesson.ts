import { Category } from "./Category";
import { Creator } from "../Creator";
import { Language } from "./Language";
import { Media } from "./Media";

export interface CreateLesson{
    title:string,
    media:Media | undefined,// MediaDto Media,
    creatorId : string,
    categoryId : string,
    languageId : string
}