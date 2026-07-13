import { Injectable } from '@angular/core';
import { AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { LastNameService } from '@app/last-name-service';

@Injectable({ providedIn: 'root' })
export class ExistsLastName {
  constructor(private lastNameService: LastNameService) {}

  validate(): AsyncValidatorFn {
    return (ctrl: AbstractControl): Observable<{ [key: string]: any } | null> => {
      return this.lastNameService.existsLastName(ctrl.value.trim()).pipe(
        map((existsInDB) => {
          return existsInDB ? { exists: true } : null;
        }),
      );
    };
  }
}
