import { Component, Input, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CountryService } from '@app/country-service';
import { Country } from '@app/model/country';
import { Language } from '@app/model/language';

@Component({
  selector: 'app-country-languages',
  imports: [CommonModule],
  templateUrl: './country-languages.html',
  styleUrl: './country-languages.css',
})
export class CountryLanguages {
  protected country!: Country;
  protected languagesFromCountry = signal<Language[]>([]);
  constructor(private countryService: CountryService) {}
  @Input()
  protected set id(countryId: number) {
    this.countryService.findCountryById(countryId).subscribe((data) => {
      this.country = data as Country;
      this.countryService
        .readLanguagesFromCountry(countryId)
        .subscribe((res) => this.languagesFromCountry.update((values) => res));
    });
  }
}
