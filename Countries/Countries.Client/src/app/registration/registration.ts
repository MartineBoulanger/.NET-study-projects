import { Component } from '@angular/core';
import { JsonPipe, CommonModule } from '@angular/common';
import {
  ReactiveFormsModule,
  // FormControl,
  FormGroup,
  FormArray,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { validatePasswordStrength } from '@app/custom-validators/password-strength';
import { passwordsAreNotIdentical } from '@app/custom-validators/passwords-are-not-identical';
import { ExistsLastName } from '@app/custom-validators/exists-last-name';

@Component({
  selector: 'app-registration',
  imports: [ReactiveFormsModule, JsonPipe, CommonModule],
  templateUrl: './registration.html',
  styleUrl: './registration.css',
})
export class Registration {
  // protected registrationModel = new FormGroup({
  //   firstName: new FormControl(''),
  //   lastName: new FormControl(''),
  //   address: new FormGroup({
  //     street: new FormControl(''),
  //     zipcode: new FormControl(''),
  //     city: new FormControl(''),
  //   }),
  //   phoneNumbers: new FormArray([new FormControl('')]),
  // });
  readonly RegExPhoneNumber =
    '[+][3][2]\\s[1-9][0-9]\{0,2\}\\s[0-9]\{2,3\}\\s[0-9]\{2\}\\s[0-9]\{2\}';
  protected registrationModel!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private existsLastName: ExistsLastName,
  ) {
    this.registrationModel = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(4)]],
      lastName: ['', null, [this.existsLastName.validate()]],
      passwordsGroup: this.fb.group(
        {
          password: [
            '',
            [Validators.required, Validators.minLength(8), validatePasswordStrength()],
          ],
          confirmPassword: [''],
        },
        {
          validators: [passwordsAreNotIdentical()],
        },
      ),
      address: this.fb.group({
        street: [''],
        zipcode: [''],
        city: [''],
      }),
      phoneNumbers: this.fb.array([this.fb.control('', Validators.pattern(this.RegExPhoneNumber))]),
    });
  }
  // getter om gemakkelijker aan de controls te kunnen van de FormArray
  protected get phoneNumbers() {
    return this.registrationModel.get('phoneNumbers') as FormArray;
  }
  protected get passwordsGroup() {
    return this.registrationModel.get('passwordsGroup')! as FormGroup;
  }
  protected get password() {
    return this.passwordsGroup.get('password')!;
  }
  protected get confirmPassword() {
    return this.passwordsGroup.get('confirmPassword')!;
  }
  // this.phoneNumbers verwijst naar de getter functie
  protected addPhoneNumber() {
    // this.phoneNumbers.push(new FormControl(''));
    this.phoneNumbers.push(this.fb.control('', Validators.pattern(this.RegExPhoneNumber)));
  }
  protected removePhoneNumberAt(index: number) {
    this.phoneNumbers.removeAt(index);
  }
  protected registerOnSubmit() {
    console.log(this.registrationModel.value);
  }
  protected toAntwerp() {
    this.registrationModel.get('address')!.get('city')!.setValue('Antwerpen');
  }
  protected johnnyLivesInAntwerp() {
    this.registrationModel.patchValue({
      firstName: 'Johnny',
      address: {
        city: 'Antwerpen',
      },
    });
  }
  protected get f() {
    return this.registrationModel.controls;
  }
}
