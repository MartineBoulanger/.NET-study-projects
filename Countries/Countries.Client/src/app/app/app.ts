import { Component } from '@angular/core';
import { NgOptimizedImage } from '@angular/common';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [NgOptimizedImage, RouterOutlet, RouterLink],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected logoSrc = '/images/logo.png';
  protected logoAlt = 'logo van de applicatie';
  protected logoWidth = '300';
  protected logoHeight = '56';
  protected title = 'Landen';
}
