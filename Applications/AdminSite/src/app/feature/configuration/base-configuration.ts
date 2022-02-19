import { FormGroup } from '@angular/forms';
import { IBaseForm } from 'src/app/core/common/ibaseform';

export abstract class BaseConfiguration implements IBaseForm {
  form!: FormGroup;
  get isCreate(): boolean {
    return this.form.value.id === 0;
  }

  deserialize(data: any): void {
  }

  create(): void {
  }
  save(): void {
  }

  submit(): void {
    if (this.isCreate) {
      this.create();
    } else {
      this.save();
    }
  }
}
