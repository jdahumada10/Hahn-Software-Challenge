import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { SpinnerOverlayService } from 'src/app/ui/shared/loading/spinner-overlay/service/spinner-overlay.service';
import Swal from 'sweetalert2';
import { SaveCompanyUseCase } from '../../../../domain/usecase/save-company-use-case';

@Component({
  selector: 'app-company-create',
  templateUrl: './company-create.component.html',
  styleUrls: ['./company-create.component.scss'],
})
export class CompanyCreateComponent {
  createForm = new FormGroup({
    name: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    email: new FormControl('', [
      Validators.required,
      Validators.pattern(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/),
    ]),
  });

  constructor(
    public dialogRef: MatDialogRef<CompanyCreateComponent>,
    private _saveCompanyUseCase: SaveCompanyUseCase,
    private spinnerOverlayService: SpinnerOverlayService
  ) {}

  onNoClick() {
    this.dialogRef.close({ action: 'CLOSE' });
  }

  onSubmit() {
    this.createForm.markAllAsTouched();
    this.createAction();
  }

  getNameErrorMessage(): string {
    if (this.createForm.controls['name'].errors?.['required']) {
      return 'Name is required';
    }
    return '';
  }
  getEmailErrorMessage(): string {
    if (this.createForm.controls['email'].errors?.['required']) {
      return 'Email is required';
    }
    if (this.createForm.controls['email'].errors?.['pattern']) {
      return 'Email does not accomplish with the pattern';
    }
    return '';
  }
  getAddressErrorMessage(): string {
    if (this.createForm.controls['address'].errors?.['required']) {
      return 'Address is required';
    }
    return '';
  }

  createAction() {
    if (this.createForm.valid) {
      this.spinnerOverlayService.show();
      this._saveCompanyUseCase
        .save({
          name: this.createForm.controls['name'].value
            ? this.createForm.controls['name'].value
            : undefined,
          address: this.createForm.controls['address'].value
            ? this.createForm.controls['address'].value
            : undefined,
          email: this.createForm.controls['email'].value
            ? this.createForm.controls['email'].value
            : undefined,
        })
        .subscribe((response) => {
          this.spinnerOverlayService.hide();
          this.dialogRef.close({ action: 'CREATE' });
          if (typeof response === 'string') {
            Swal.fire({
              icon: 'error',
              title: 'Error creating the company',
              footer: response
            });
          } else {
            Swal.fire({
              icon: 'success',
              title: 'Company created successfully',
            });
          }
        });
    }
  }
}
