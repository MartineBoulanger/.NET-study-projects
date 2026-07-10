import { Routes } from '@angular/router';
import { Countries } from '@app/countries/countries';
import { TopPopulation } from '@app/top-population/top-population';
import { SearchCountry } from '@app/search-country/search-country';
import { CountryDetail } from '@app/country-detail/country-detail';

export const routes: Routes = [
  { path: 'landen', component: Countries },
  { path: 'top', component: TopPopulation },
  { path: 'zoeken', component: SearchCountry },
  { path: 'detail/:id', component: CountryDetail },
];
