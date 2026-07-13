import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { NgOptimizedImage } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Country } from '@app/model/country';
import { CountryService } from '@app/country-service';

@Component({
  selector: 'app-country-card',
  imports: [NgOptimizedImage],
  templateUrl: './country-card.html',
  styleUrl: './country-card.css',
})
export class CountryCard implements OnInit, OnChanges {
  @Input() country!: Country;

  constructor(private countryService: CountryService) {}

  protected flagSrc = 'images/noflag.png';
  protected flagAlt = '';
  protected timeStamp = new Date().getTime();

  ngOnInit() {
    // this.flagSrc = `/images/${this.country.id}.png`;
    // this.flagAlt = `Vlag van ${this.country.name}`;
    this.fillData();
  }

  ngOnChanges() {
    this.fillData();
  }

  protected fillData() {
    this.flagAlt = 'Vlag van ' + this.country.name;
    this.timeStamp = new Date().getTime();
    this.countryService.getFlag(this.country.id).subscribe({
      next: (url) => {},
      error: (error: HttpErrorResponse) => this.handleError(error, this.country.id),

      complete: () => {},
    });
  }

  protected handleError(error: HttpErrorResponse, id: number) {
    if (error.status === 200 && error.url !== null) {
      this.flagSrc = error.url + '?' + this.timeStamp;
    } else {
      this.flagSrc = 'images/noflag.png' + '?' + this.timeStamp;
    }
  }
}
