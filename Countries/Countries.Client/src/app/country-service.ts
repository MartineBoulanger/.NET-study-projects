import { catchError, Observable, of, debounceTime, distinctUntilChanged, map } from 'rxjs';
import { Injectable, signal } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Country } from '@app/model/country';
import { Language } from '@app/model/language';

const httpOptions = { headers: new HttpHeaders({}) };

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  constructor(private http: HttpClient) {}

  searchCountry(searchstring: string): Observable<Country[]> {
    if (!searchstring.trim()) return of([]);
    return this.http
      .get<Country[]>(`api/search-country?name=${searchstring}`)
      .pipe(catchError(this.handleError<Country[]>('searchCountry', [])));
  }

  deleteCountry(country: Country | number): Observable<any> {
    const id = typeof country === 'number' ? country : country.id;
    return this.http
      .delete<number>(`api/delete-country/${id}`, httpOptions)

      .pipe(catchError(this.handleError<Country>('deleteCountry')));
  }

  getTop(top: number): Observable<Country[]> {
    return this.http
      .get<Country[]>(`api/top-population/${top}`)
      .pipe(catchError(this.handleError('getTop', [])));
  }

  public countries = signal<Country[]>([]);

  readCountries() {
    this.http
      .get<Country[]>('api/countries')
      .pipe(catchError(this.handleError('readCountries', [])))
      .subscribe((res) => this.countries.update(() => res));
  }

  findCountryById(id: number) {
    return this.http
      .get<Country>(`api/detail/${id}`)
      .pipe(catchError(this.handleError('findCountryById', [])));
  }

  handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.log(operation, error);
      return of(result as T);
    };
  }

  addCountry(country: Country): Observable<any> {
    return this.http
      .post('api/country', country, httpOptions)
      .pipe(catchError(this.handleError<any>('addCountry')));
  }

  validateCountryIdByName(name: string, currentId: string): Observable<any> {
    return this.http
      .post('api/findcountryidbyname', { countryName: name }, httpOptions)

      .pipe(
        debounceTime(500),
        distinctUntilChanged(),
        map((id) => {
          return id !== 0 && currentId !== id.toString() ? { existsCountryName: true } : null;
        }),
      );
  }

  updateCountry(country: Country): Observable<any> {
    return this.http
      .put(`api/country/${country.id}`, country)
      .pipe(catchError(this.handleError<any>('updateCountry')));
  }

  uploadFlag(id: number, flag: FormData): Observable<any> {
    const httpOptionsUpload = new HttpHeaders();
    httpOptionsUpload.set('accept', '*/*');
    httpOptionsUpload.set('Content-Type', 'multipart/form-data');
    httpOptionsUpload.set('Content-Disposition', `attachment; filename="${id}.png"`);
    return this.http

      .post(
        `api/upload-flag/${id}`,

        flag,
        { headers: httpOptionsUpload },
      )

      .pipe(catchError(this.handleError<any>('uploadFlag')));
  }

  getFlag(id: number): Observable<string> {
    return this.http.get<string>(`api/get-flag/${id}`);
  }

  readLanguagesFromCountry(id: number): Observable<Language[]> {
    console.log('readLanguagesFromCountry');
    return this.http.get<Language[]>(`api/country/${id}/languages`).pipe(
      catchError(
        this.handleError(
          'readLanguagesFromCountry',

          [],
        ),
      ),
    );
  }
}
