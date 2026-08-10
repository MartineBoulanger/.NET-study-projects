import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-favourite-car',
  imports: [FormsModule],
  templateUrl: './favourite-car.html',
  styleUrl: './favourite-car.css',
})
export class FavouriteCar {
  protected favouriteCar = '';
}
