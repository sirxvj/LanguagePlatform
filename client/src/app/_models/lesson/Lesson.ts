import { Creator } from "../Creator";
import { Media } from "./Media";

export interface Lesson{
    id : string,
    title:string,
    approved : boolean,
    createdAt : string,
    avg : number,
    media:Media | undefined,// MediaDto Media,
    creator : Creator,
    category : string,
    language:string
}