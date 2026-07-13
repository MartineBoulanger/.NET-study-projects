import { Routes } from '@angular/router';
import { Countries } from '@app/countries/countries';
import { TopPopulation } from '@app/top-population/top-population';
import { SearchCountry } from '@app/search-country/search-country';
import { CountryDetail } from '@app/country-detail/country-detail';
import { Registration } from '@app/registration/registration';
import { FavouriteCar } from '@app/favourite-car/favourite-car';
import { PersonForm } from '@app/person-form/person-form';
import { AddCountry } from '@app/add-country/add-country';
import { UpdateCountry } from '@app/update-country/update-country';
import { CountryLanguages } from '@app/country-languages/country-languages';

export const routes: Routes = [
  { path: 'landen', component: Countries },
  { path: 'top', component: TopPopulation },
  {
    path: 'zoeken',
    component: SearchCountry,
    children: [
      {
        path: ':id/talen',
        component: CountryLanguages,
      },
    ],
  },
  { path: 'detail/:id', component: CountryDetail },
  { path: 'registreer', component: Registration },
  { path: 'wagen', component: FavouriteCar },
  { path: 'persoon', component: PersonForm },
  { path: 'nieuw-land', component: AddCountry },
  { path: 'wijzig-land/:id', component: UpdateCountry },
];
