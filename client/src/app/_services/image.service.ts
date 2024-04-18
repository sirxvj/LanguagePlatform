import { Injectable } from '@angular/core';
import { Media } from '../_models/Media';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor() { }
  getImage(media:Media|undefined){
    if(media && media.Bytes)
      return URL.createObjectURL(new Blob([Uint8Array.from(media.Bytes).buffer ],{type:'image/'+media.FileType}))
    else
      return ''
  }
}
