import { Creator } from "./Creator";

export interface Lesson{
    id : string,
    title:string,
    approved : boolean,
    createdAt : string,
    avg : number,
    // MediaDto Media,
    creator : Creator,
    category : string
}