import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SpinnerOverlayService } from 'src/app/ui/shared/loading/spinner-overlay/service/spinner-overlay.service';
import Swal from 'sweetalert2';
import { CompanyCreateComponent } from '../../company-admin/company-create/company-create.component';
import { SaveApplicantUseCase } from 'src/app/domain/usecase/save-applicant-use-case';
import { ProcessStatus } from 'src/app/domain/models/applicant/processStatus';
import { Applicant } from 'src/app/domain/models/applicant/applicant';

@Component({
  selector: 'app-applicant-edit',
  templateUrl: './applicant-edit.component.html',
  styleUrls: ['./applicant-edit.component.scss'],
})
export class ApplicantEditComponent {
  processStatus = Object.values(ProcessStatus);
  selected = '';
  createForm = new FormGroup({
    firstName: new FormControl(
      this.applicant.firstName ? this.applicant.firstName : '',
      Validators.required
    ),
    lastName: new FormControl(
      this.applicant.lastName ? this.applicant.lastName : '',
      Validators.required
    ),
    role: new FormControl(
      this.applicant.role ? this.applicant.role : '',
      Validators.required
    ),
    status: new FormControl(
      this.applicant.processStatus ? this.applicant.processStatus : '',
      Validators.required
    ),
    contactInfo: new FormControl(
      this.applicant.email ? this.applicant.email : '',
      [
        Validators.required,
        Validators.pattern(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/),
      ]
    ),
  });

  constructor(
    public dialogRef: MatDialogRef<CompanyCreateComponent>,
    @Inject(MAT_DIALOG_DATA) public applicant: Applicant,
    private _saveApplicantUseCase: SaveApplicantUseCase,
    private spinnerOverlayService: SpinnerOverlayService
  ) {
    console.log(applicant);
  }

  onNoClick() {
    this.dialogRef.close({ action: 'CLOSE' });
  }

  onSubmit() {
    this.createForm.markAllAsTouched();
    this.createAction();
  }

  getFirstNameErrorMessage(): string {
    if (this.createForm.controls['firstName'].errors?.['required']) {
      return 'First name is required';
    }
    return '';
  }

  getStatusErrorMessage(): string {
    if (this.createForm.controls['status'].errors?.['required']) {
      return 'Status is required';
    }
    return '';
  }

  getLastNameErrorMessage(): string {
    if (this.createForm.controls['lastName'].errors?.['required']) {
      return 'Last name is required';
    }
    return '';
  }
  getRoleErrorMessage(): string {
    if (this.createForm.controls['role'].errors?.['required']) {
      return 'Role is required';
    }
    return '';
  }
  getContactInfoErrorMessage(): string {
    if (this.createForm.controls['contactInfo'].errors?.['required']) {
      return 'Contact Info is required';
    }
    if (this.createForm.controls['contactInfo'].errors?.['pattern']) {
      return 'Contact Info does not accomplish with the pattern';
    }
    return '';
  }

  createAction() {
    if (this.createForm.valid) {
      this.spinnerOverlayService.show();
      this._saveApplicantUseCase
        .update({
          id: this.applicant.id ? this.applicant.id : '',
          firstName: this.createForm.controls['firstName'].value
            ? this.createForm.controls['firstName'].value
            : undefined,
          lastName: this.createForm.controls['lastName'].value
            ? this.createForm.controls['lastName'].value
            : undefined,
          role: this.createForm.controls['role'].value
            ? this.createForm.controls['role'].value
            : undefined,
          email: this.createForm.controls['contactInfo'].value
            ? this.createForm.controls['contactInfo'].value
            : undefined,
          companyId: this.applicant.companyId,
          processStatus: this.createForm.controls['status'].value
            ? (this.createForm.controls['status'].value as ProcessStatus)
            : undefined,
        })
        .subscribe((response) => {
          this.spinnerOverlayService.hide();
          this.dialogRef.close({ action: 'EDIT' });
          if (typeof response === 'string') {
            Swal.fire({
              icon: 'error',
              title: 'Error updating the applicant',
              footer: response,
            });
          } else {
            Swal.fire({
              icon: 'success',
              title: 'Applicant updated successfully',
            });
          }
        });
    }
  }
}
