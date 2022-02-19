export class ValidationMessageConfig {
  static required(controlName: string): string {
    return `${controlName} is required`;
  }
  static emailInvalid(): string {
    return 'Email is not valid';
  }

  static between(controlName: string, minLength: number, maxLength: number): string {
    return ``;
  }
  static minLength(controlName: string, minLength: number): string {
    return `${controlName} must be greater than ${minLength} ${minLength === 1 ? 'character' : 'characters'}.`;
  }

  static maxlength(controlName: string, maxLength: number): string {
    return `${controlName} must be less than ${maxLength} ${maxLength === 1 ? 'character' : 'characters'}.`;
  }

  static phoneInvalid(): string {
    return 'Phone number is not valid';
  }
}

