import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { SpinnerOverlayService } from 'src/app/ui/shared/loading/spinner-overlay/service/spinner-overlay.service';
import { Applicant } from '../../../../domain/models/applicant/applicant';
import { GetApplicantUseCase } from '../../../../domain/usecase/get-applicant-use-case';
import Swal from 'sweetalert2';
import { ApplicantCreateComponent } from '../applicant-create/applicant-create.component';
import { MatDialog } from '@angular/material/dialog';
import { ApplicantEditComponent } from '../applicant-edit/applicant-edit.component';
import { ConfirmDialogComponent } from 'src/app/ui/shared/dialog/confirm-dialog/confirm-dialog.component';
import { DeleteApplicantUseCase } from 'src/app/domain/usecase/delete-applicant-use-case';

@Component({
  selector: 'app-applicant-view',
  templateUrl: './applicant-view.component.html',
  styleUrls: ['./applicant-view.component.scss'],
})
export class ApplicantViewComponent {
  displayedColumns: string[] = [
    'name',
    'contactInfo',
    'role',
    'processStatus',
    'actions',
  ];
  applicants: Applicant[] = [];
  nameFilter: string = '';

  dataSource: MatTableDataSource<Applicant> = new MatTableDataSource<Applicant>(
    this.applicants
  );

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  @ViewChild(MatSort) sort!: MatSort;

  companyId = 0;

  constructor(
    private route: ActivatedRoute,
    private _getApplicantUseCase: GetApplicantUseCase,
    private _deleteApplicantUseCase: DeleteApplicantUseCase,
    private spinnerOverlayService: SpinnerOverlayService,
    private dialog: MatDialog
  ) {}

  ngOnInit() {
    let companyId = this.route.snapshot.paramMap.get('companyId');
    if (companyId != null) {
      this.companyId = +companyId;
    } else {
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Company Id cannot be null, please contact an administrator!',
      });
    }
    this.buildTable();
  }

  buildTable() {
    this.spinnerOverlayService.show();
    this._getApplicantUseCase
      .getApplicantsByCompanyId(this.companyId)
      .subscribe((result) => {
        if (typeof result === 'object') {
          this.applicants = result;
          this.dataSource.data = this.applicants;
        } else {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong getting applicants, please try again later!',
            footer: result,
          });
        }
        this.spinnerOverlayService.hide();
      });
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  async applicantSearch(value: string) {
    if (value) {
      this.spinnerOverlayService.show();
      this.dataSource.filter = value;
      this.spinnerOverlayService.hide();
    } else {
      this.dataSource.filter = '';
    }
  }

  editApplicant(applicant: Applicant) {
    const dialogRef = this.dialog.open(ApplicantEditComponent, {
      disableClose: true,
      width: '90%',
      height: '90%',
      data: {
        id: applicant.id,
        firstName: applicant.firstName,
        lastName: applicant.lastName,
        email: applicant.email,
        role: applicant.role,
        processStatus: applicant.processStatus,
        companyId: applicant.companyId,
      },
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result.action) {
        if (result.action == 'EDIT') {
          this.buildTable();
        }
      }
    });
  }

  deleteApplicant(applicant: Applicant) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      disableClose: true,
      width: '50%',
      height: '30%',
    });
    dialogRef.componentInstance.title = 'Do you want to delete this applicant?';
    dialogRef.afterClosed().subscribe((result) => {
      if (result.action) {
        this._deleteApplicantUseCase.delete(applicant).subscribe((result) => {
          if (!result) {
            Swal.fire({
              icon: 'success',
              title: 'Applicant deleted successfully',
            });
            this.buildTable();
          } else {
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'Something went wrong deleting the applicant, please try again later!',
              footer: result!,
            });
          }
        });
      }
    });
  }

  addApplicant() {
    const dialogRef = this.dialog.open(ApplicantCreateComponent, {
      disableClose: true,
      width: '90%',
      height: '90%',
      data: {
        companyId: this.companyId,
      },
    });
    dialogRef.componentInstance.companyId = this.companyId.toString()

    dialogRef.afterClosed().subscribe((result) => {
      if (result.action) {
        if (result.action == 'CREATE') {
          this.buildTable();
        }
      }
    });
  }
}
