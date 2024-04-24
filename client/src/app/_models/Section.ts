import { Media } from "./Media";

export interface Section{
    order : number,
    title : string,
    rawText : string,
    media : Media | undefined
}