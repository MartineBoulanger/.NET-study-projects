import { catchError, Observable, of } from 'rxjs';
import { Injectable, signal } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Country } from '@app/model/country';

const httpOptions = { headers: new HttpHeaders({}) };

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  private baseUrl = 'http://localhost:5000/';

  constructor(private http: HttpClient) {}

  deleteCountry(country: Country | number): Observable<any> {
    const id = typeof country === 'number' ? country : country.id;
    return this.http
      .delete<number>(`${this.baseUrl}}delete-country/${id}`, httpOptions)

      .pipe(catchError(this.handleError<Country>('deleteCountry')));
  }

  getTop(top: number): Observable<Country[]> {
    return this.http
      .get<Country[]>(`${this.baseUrl}top-population/${top}`)
      .pipe(catchError(this.handleError('getTop', [])));
  }

  public countries = signal<Country[]>([]);

  readCountries() {
    this.http
      .get<Country[]>(`${this.baseUrl}countries`)
      .pipe(catchError(this.handleError('readCountries', [])))
      .subscribe((res) => this.countries.update(() => res));
  }

  findCountryById(id: number) {
    return this.http
      .get<Country>(`${this.baseUrl}country/${id}`)
      .pipe(catchError(this.handleError('findCountryById', [])));
  }

  handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.log(operation, error);
      return of(result as T);
    };
  }
}
