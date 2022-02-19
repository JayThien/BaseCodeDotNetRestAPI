import { FormGroup } from '@angular/forms';
export interface IBaseForm {
  form: FormGroup;
  deserialize(data: any): void;
}
