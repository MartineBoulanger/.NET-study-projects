import { Service } from '@angular/core';
import { Observable, of } from 'rxjs';

const LASTNAMES: string[] = ['Tesla', 'Kelvin', 'Einstein', 'Edison'];

@Service()
export class LastNameService {
  existsLastName(name: string): Observable<boolean> {
    return of(LASTNAMES.includes(name));
  }
}
