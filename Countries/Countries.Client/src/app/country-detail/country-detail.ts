import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Location } from '@angular/common';
import { CountryService } from '@app/country-service';
import { Country } from '@app/model/country';

@Component({
  selector: 'app-country-detail',
  imports: [FormsModule],
  templateUrl: './country-detail.html',
  styleUrl: './country-detail.css',
})
export class CountryDetail implements OnInit {
  country!: Country | undefined;

  constructor(
    private countryService: CountryService,
    private route: ActivatedRoute,
    private location: Location,
  ) {}

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.countryService.findCountryById(id).subscribe((data) => (this.country = data as Country));
  }

  protected goBack(): void {
    this.location.back();
  }
}
