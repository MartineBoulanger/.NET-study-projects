import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CountryService } from '@app/country-service';
import { Country } from '@app/model/country';

@Component({
  selector: 'app-top-population',
  imports: [CommonModule],
  templateUrl: './top-population.html',
  styleUrl: './top-population.css',
})
export class TopPopulation implements OnInit {
  topCountries = signal<Country[]>([]);

  constructor(private countryService: CountryService) {}

  ngOnInit(): void {
    this.countryService.getTop(3).subscribe(res => this.topCountries.update(() => res));
  }
}
