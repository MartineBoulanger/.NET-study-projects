import { Component, OnInit, signal } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Subject, debounceTime, distinctUntilChanged, switchMap } from 'rxjs';
import { Country } from '@app/model/country';
import { CountryService } from '@app/country-service';

@Component({
  selector: 'app-search-country',
  imports: [RouterLink, RouterOutlet],
  templateUrl: './search-country.html',
  styleUrl: './search-country.css',
})
export class SearchCountry implements OnInit {
  protected countries = signal<Country[]>([]);
  private searchSubject = new Subject<string>();

  constructor(private countryService: CountryService) {}

  protected search(searchString: string): void {
    this.searchSubject.next(searchString);
  }

  ngOnInit(): void {
    this.searchSubject
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        switchMap((searchString) => this.countryService.searchCountry(searchString)),
      )
      .subscribe((res: Country[]) => this.countries.update((values) => res));
  }
}
