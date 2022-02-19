import { AbstractControl } from '@angular/forms';

export function ValidatePhone(control: AbstractControl): { [key: string]: any | null } {
  if (control.value && control.value.length !== 10) {
    return { phoneNumberInvalid: true };
  }
  return null;
}
