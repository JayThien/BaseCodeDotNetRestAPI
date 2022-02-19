import { Injectable } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { RouterService } from './router.service';

@Injectable({ providedIn: 'root' })
export class SystemErrorModalService {
  constructor(private modalService: NzModalService, private routerService: RouterService) { }

  showError() {
    this.modalService.error({
      nzTitle: '500 Internal Server Error',
      nzContent: 'There was an error. Please try again later',
      // nzOnOk: () => this.routerService.navigateToPrevious()
    });
  }
}
