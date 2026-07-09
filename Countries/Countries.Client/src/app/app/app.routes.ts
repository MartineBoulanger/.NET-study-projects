import { Routes } from '@angular/router';
import { Countries } from '@app/countries/countries';
import { TopPopulation } from '@app/top-population/top-population'

export const routes: Routes = [
  { path: 'landen', component: Countries },
  { path: 'top', component: TopPopulation }
];