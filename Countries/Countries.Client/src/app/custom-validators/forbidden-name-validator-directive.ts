import { NG_VALIDATORS, Validator, AbstractControl } from '@angular/forms';
import { Directive, Input } from '@angular/core';

@Directive({
  selector: '[forbiddenName]',
  providers: [
    { provide: NG_VALIDATORS, useExisting: ForbiddenNameValidatorDirective, multi: true },
  ],
})
export class ForbiddenNameValidatorDirective implements Validator {
  @Input('forbiddenName') forbiddenName!: string;

  validate(control: AbstractControl): { [key: string]: any } | null {
    const nameRegEx = new RegExp(this.forbiddenName, 'i');
    const forbidden = nameRegEx.test(control.value);
    return forbidden ? { forbiddenName: { value: control.value } } : null;
  }
}
