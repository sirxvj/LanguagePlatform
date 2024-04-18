import { Media } from "./Media";

export interface Section{
    order : number,
    title : string,
    rawText : string,
    mediaTopic : Media | undefined
}