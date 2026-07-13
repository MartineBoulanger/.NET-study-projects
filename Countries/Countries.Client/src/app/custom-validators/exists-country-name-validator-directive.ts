import {
  NG_ASYNC_VALIDATORS,
  AsyncValidator,
  AbstractControl,
  ValidationErrors,
} from '@angular/forms';
import { Directive, Input } from '@angular/core';
import { CountryService } from '../country-service';
import { Observable } from 'rxjs';

@Directive({
  selector: '[existsCountryName]',
  providers: [
    {
      provide: NG_ASYNC_VALIDATORS,
      useExisting: ExistsCountryNameValidatorDirective,
      multi: true,
    },
  ],
})
export class ExistsCountryNameValidatorDirective implements AsyncValidator {
  @Input('existsCountryName') oldId: string = '';

  constructor(private countryService: CountryService) {}

  validate(
    ctrl: AbstractControl,
  ): Promise<ValidationErrors | null> | Observable<ValidationErrors | null> {
    {
      return this.countryService.validateCountryIdByName(ctrl.value, this.oldId);
    }
  }
}
