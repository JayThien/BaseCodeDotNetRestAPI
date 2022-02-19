import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Keys } from '../const/keys';
@Injectable({ providedIn: 'root' })
export class WizardService {
  constructor(
    private router: Router,
  ) {
  }

  public get _id(): number {
    const params = this.router.url.split('/');
    // tslint:disable-next-line: radix
    return Number.parseInt(params[2]);
  }

  public get _isCreate(): boolean {
    return this._id === 0;
  }
}
