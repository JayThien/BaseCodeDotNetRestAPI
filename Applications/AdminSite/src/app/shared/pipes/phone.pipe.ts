import { Pipe, PipeTransform } from '@angular/core';
@Pipe({ name: 'phone' })
export class PhonePipe implements PipeTransform {
  constructor() { }
  transform(phoneNumber: string): string {
    if (phoneNumber) {
      return `(${phoneNumber.substring(0, 3)}) ${phoneNumber.substring(3, 6)}-${phoneNumber.substring(6, 10)}`;
    }
    return '';
  }
}
