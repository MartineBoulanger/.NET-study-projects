import { ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';

export function passwordsAreNotIdentical(): ValidatorFn {
  return (frm: AbstractControl): ValidationErrors | null => {
    const password = frm.get('password');
    const confirmPassword = frm.get('confirmPassword');
    return password && confirmPassword && password.value !== confirmPassword.value
      ? { noMatch: true }
      : null;
  };
}
