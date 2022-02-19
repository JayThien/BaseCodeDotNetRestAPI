import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LoaderService {
  private showLoader = false;
  public get isLoading(): boolean {
    return this.showLoader;
  }

  constructor() { }

  show(): void {
    this.showLoader = true;
  }

  hide(): void {
    this.showLoader = false;
  }
}
