import { Location } from '@angular/common';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { FormAction } from '../const/form';
import { Keys } from '../const/keys';

@Injectable({ providedIn: 'root' })
export class RouterService {
  constructor(private router: Router, private location: Location) {
  }

  get url(): string {
    return this.router.url;
  }

  navigateToDetail(url: string) {
    this.router.navigate([url]);
  }

  navigateToCreate(key: string) {
    localStorage.setItem(`${Keys.FormAction}_${key}`, FormAction[FormAction.create]);
    this.router.navigate([key, 0]);
  }
}
