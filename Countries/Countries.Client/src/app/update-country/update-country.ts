import { Component, OnInit } from '@angular/core';
import { NgOptimizedImage } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CountryService } from '@app/country-service';
import { Country } from '@app/model/country';
import { ExistsCountryNameValidatorDirective } from '@app/custom-validators/exists-country-name-validator-directive';

@Component({
  selector: 'app-update-country',
  imports: [FormsModule, ExistsCountryNameValidatorDirective, NgOptimizedImage],
  templateUrl: './update-country.html',
  styleUrl: './update-country.css',
})
export class UpdateCountry implements OnInit {
  protected id!: number;
  protected country!: Country;
  protected submitted = false;
  protected timeStamp = new Date().getTime();

  protected flagSrc = '';
  protected flagAlt = '';
  protected file!: File;
  protected fileSize = 0;
  protected isFileSizeValid = true;
  protected isFileTypeValid = true;
  protected fileType = '';

  constructor(
    private countryService: CountryService,

    private route: ActivatedRoute,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.id = +this.route.snapshot.paramMap.get('id')!;
    this.countryService.findCountryById(this.id).subscribe((data) => {
      this.country = data as Country;
      // this.flagSrc = '/images/' + this.country.id + '.png';
      this.flagAlt = 'Vlag van ' + this.country.name;
      this.countryService.getFlag(this.country.id).subscribe({
        next: (url) => {},
        error: (error: HttpErrorResponse) => this.handleError(error, this.country.id),

        complete: () => {},
      });
    });
  }

  protected selectedFiles(event: any) {
    if (event.target.files.length > 0) {
      this.file = event.target.files[0];
      this.fileSize = Math.round(this.file.size / 1024);
      this.isFileSizeValid = this.fileSize <= 2000;
      this.isFileTypeValid = this.file.type === 'image/png';
    } else {
      this.isFileSizeValid = true;
      this.isFileTypeValid = true;
    }
  }

  protected save() {
    this.countryService.updateCountry(this.country).subscribe((result) => {
      if (this.file !== null && this.file !== undefined) {
        const formData = new FormData();
        formData.append('file', this.file);
        this.countryService.uploadFlag(this.id, formData).subscribe((r) => {
          this.countryService.readCountries();
        });
      } else {
        this.countryService.readCountries();
      }
    });
    this.router.navigate(['/landen']);
  }

  protected onSubmit() {
    this.submitted = true;
    this.save();
    this.router.navigate(['/landen']);
  }

  protected handleError(error: HttpErrorResponse, id: number) {
    if (error.status === 200 && error.url !== null) {
      this.flagSrc = error.url + '?' + this.timeStamp;
    } else {
      this.flagSrc = 'images/noflag.png' + '?' + this.timeStamp;
    }
  }
}
