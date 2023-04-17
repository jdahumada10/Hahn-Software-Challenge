import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SaveCompanyUseCase } from 'src/app/domain/usecase/save-company-use-case';
import { SpinnerOverlayService } from 'src/app/ui/shared/loading/spinner-overlay/service/spinner-overlay.service';
import Swal from 'sweetalert2';
import { Company } from '../../../../domain/models/company/company';

@Component({
  selector: 'app-company-edit',
  templateUrl: './company-edit.component.html',
  styleUrls: ['./company-edit.component.scss'],
})
export class CompanyEditComponent {
  createForm = new FormGroup({
    name: new FormControl(
      this.company.name ? this.company.name : '',
      Validators.required
    ),
    address: new FormControl(
      this.company.address ? this.company.address : '',
      Validators.required
    ),
    email: new FormControl(this.company.email ? this.company.email : '', [
      Validators.required,
      Validators.pattern(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/),
    ]),
  });

  constructor(
    public dialogRef: MatDialogRef<CompanyEditComponent>,
    @Inject(MAT_DIALOG_DATA) public company: Company,
    private _saveCompanyUseCase: SaveCompanyUseCase,
    private spinnerOverlayService: SpinnerOverlayService
  ) {}

  onNoClick() {
    this.dialogRef.close({ action: 'CLOSE' });
  }

  onSubmit() {
    this.createForm.markAllAsTouched();
    this.editAction();
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

  editAction() {
    if (this.createForm.valid) {
      this.spinnerOverlayService.show();
      this._saveCompanyUseCase
        .update({
          id: this.company.id,
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
          this.dialogRef.close({ action: 'EDIT' });
          if (typeof response === 'string') {
            Swal.fire({
              icon: 'error',
              title: 'Error editing the company, please try again later...',
              footer: response
            });
          } else {
            Swal.fire({
              icon: 'success',
              title: 'Company edited successfully',
            });
          }
        });
    }
  }
}
