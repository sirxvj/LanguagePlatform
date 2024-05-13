import { Injectable } from '@angular/core';
import { Media } from '../_models/Media';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor() { }
  async getImage(media:Media|undefined) {
    if(media && media.bytes){
      
      const arr = new Uint8Array(atob(media.bytes).split("").map(function(c) {
        return c.charCodeAt(0); }))
       
      return URL.createObjectURL(new Blob([arr.buffer ],{type:'image/'+media.FileType})) 
    
    }
      else
      return ''
  }
  public arrayBufferToBase64String(buffer: ArrayBuffer) {
    let binaryString = ''
    var bytes = new Uint8Array(buffer);
    for (var i = 0; i < bytes.byteLength; i++) {
      binaryString += String.fromCharCode(bytes[i]);
    }
  
    return window.btoa(binaryString);
  }
}
