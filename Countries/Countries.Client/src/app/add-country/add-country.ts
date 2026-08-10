import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Country } from '@app/model/country';
import { CountryService } from '@app/country-service';
import { ExistsCountryNameValidatorDirective } from '@app/custom-validators/exists-country-name-validator-directive';

@Component({
  selector: 'app-add-country',
  imports: [FormsModule, ExistsCountryNameValidatorDirective],
  templateUrl: './add-country.html',
  styleUrl: './add-country.css',
})
export class AddCountry {
  protected country = new Country();
  protected submitted = false;

  protected file!: File;
  protected fileSize = 0;
  protected isFileSizeValid = true;
  protected isFileTypeValid = true;
  protected fileType = '';

  constructor(
    private countryService: CountryService,

    private router: Router,
  ) {}

  protected onSubmit() {
    this.submitted = true;
    this.add();
    this.router.navigate(['/landen']);
  }

  protected add(): void {
    if (
      !this.country.name.trim() ||
      !this.country.capital.trim() ||
      isNaN(this.country.population)
    ) {
      return;
    }
    this.countryService
      .addCountry({
        name: this.country.name,
        capital: this.country.capital,
        population: this.country.population,
      } as Country)

      .subscribe((result) => {
        const formData = new FormData();
        if (this.file !== null && this.file !== undefined) {
          formData.append('file', this.file);
          this.countryService.uploadFlag(result, formData).subscribe((r) => {
            this.country = {} as Country; // of = new Country()
            this.countryService.readCountries();
          });
        } else {
          this.country = {} as Country; // of = new Country()
          this.countryService.readCountries();
        }
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
}
