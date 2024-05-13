import { Media } from "../lesson/Media";

export interface Section{
    order : number,
    title : string,
    rawText : string,
    media : Media | undefined
}