import { FormGroup } from '@angular/forms';
import { NzModalService } from 'ng-zorro-antd/modal';
import { Keys } from '../const/keys';

import { RoutingKey } from '../const/routing-key';
import { WizardService } from '../services/wizard.service';
export abstract class BaseWizard {
  form: FormGroup;
  rootKey: RoutingKey;

  constructor(
    protected modal: NzModalService,
    public wizardService: WizardService,
  ) {
    this.initForm();
  }

  storageRootRouting() {
    localStorage.setItem(Keys.Root, this.rootKey);
  }

  initForm() { }
  loadData() { }

  deserialize(data: any) { }

  resetForm(): void {
    if (this.form.dirty) {
      this.modal.confirm({
        nzTitle: 'Are you sure you want to leave this page?',
        nzContent: 'The changes you made will be lost.',
        nzOnOk: () => {
          this.loadData();
        },
      });
    } else {
    }
  }
}
