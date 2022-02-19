import { Injectable } from "@angular/core";

@Injectable({providedIn: 'root'})
export class MediaService {
    dropboxHost = 'https://www.dropbox.com/s/';
    constructor() {

    }

    convertURLToString(url: string) {
        return decodeURIComponent(url.replace(this.dropboxHost, ""));
    }
    
}
