import { Component, Input, OnInit } from '@angular/core';
import { NgOptimizedImage } from '@angular/common';
import { Country } from '@app/model/country';

@Component({
  selector: 'app-country-card',
  imports: [NgOptimizedImage],
  templateUrl: './country-card.html',
  styleUrl: './country-card.css',
})

export class CountryCard implements OnInit {
  @Input() country!: Country;
  protected flagSrc = '';
  protected flagAlt = '';

  ngOnInit() {
    this.flagSrc = `/images/${this.country.id}.png`;
    this.flagAlt = `Vlag van ${this.country.name}`;
  }
}
