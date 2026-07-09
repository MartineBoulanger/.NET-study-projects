import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { CountryCard } from '@app/country-card/country-card';
import { CountryService } from '@app/country-service';
import { Country } from '@app/model/country';

@Component({
  selector: 'app-countries',
  imports: [CountryCard, CommonModule, FontAwesomeModule],
  templateUrl: './countries.html',
  styleUrl: './countries.css',
})
export class Countries implements OnInit {
  protected trash = faTrash;
  protected selectedCountryId = signal<number>(0);
  protected selectedCountry = signal<Country>(new Country());

  constructor(public countryService: CountryService) {}

  ngOnInit(): void {
    this.countryService.readCountries();
    this.close();
  }

  protected select(country: Country): void {
    this.selectedCountryId.update(() => country.id);
    this.selectedCountry.update(() => country);
  }

  protected close(): void {
    this.selectedCountryId.update(() => 0);
  }

  protected delete(country: Country): void {
    this.countryService.deleteCountry(country).subscribe(() => {
      this.countryService.readCountries();
      this.close();
    });
  }
}
