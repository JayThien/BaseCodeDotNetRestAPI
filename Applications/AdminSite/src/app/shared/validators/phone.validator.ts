import { AbstractControl } from '@angular/forms';

export function ValidatePhone(control: AbstractControl): { [key: string]: any | null } {
  if (control.value && control.value.length < 14) {
    return { phoneInvalid: true };
  }
  return {};
}
