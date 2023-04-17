import { LiveAnnouncer } from '@angular/cdk/a11y';
import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Company } from 'src/app/domain/models/company/company';
import { GetCompanyUseCase } from 'src/app/domain/usecase/get-company-use-case';
import { SpinnerOverlayService } from 'src/app/ui/shared/loading/spinner-overlay/service/spinner-overlay.service';
import { CompanyCreateComponent } from '../company-create/company-create.component';
import { CompanyEditComponent } from '../company-edit/company-edit.component';
import { ConfirmDialogComponent } from 'src/app/ui/shared/dialog/confirm-dialog/confirm-dialog.component';
import { DeleteCompanyUseCase } from 'src/app/domain/usecase/delete-company-use-case';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-company-view',
  templateUrl: './company-view.component.html',
  styleUrls: ['./company-view.component.scss'],
})
export class CompanyViewComponent {
  displayedColumns: string[] = ['name', 'contactInfo', 'actions'];
  companies: Company[] = [];
  nameFilter: string = '';
  startsWith = '';

  dataSource: MatTableDataSource<Company> = new MatTableDataSource<Company>(
    this.companies
  );

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _liveAnnouncer: LiveAnnouncer,
    private _getCompanyUseCase: GetCompanyUseCase,
    private _deleteCompanyUseCase: DeleteCompanyUseCase,
    private dialog: MatDialog,
    private spinnerOverlayService: SpinnerOverlayService
  ) {}

  ngOnInit(): void {
    this.spinnerOverlayService.show();
    this.buildTable();
  }

  buildTable() {
    this._getCompanyUseCase.getAll().subscribe((result) => {
      if (typeof result === 'object') {
        this.companies = result;
        this.dataSource.data = this.companies;
      } else {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Something went wrong getting companies, please try again later!',
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

  announceSortChange(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  async companySearch(value: string) {
    if (value) {
      this.spinnerOverlayService.show();
      this.dataSource.filter = value;
      this.spinnerOverlayService.hide();
    } else {
      this.dataSource.filter = '';
    }
  }

  addCompany() {
    const dialogRef = this.dialog.open(CompanyCreateComponent, {
      disableClose: true,
      width: '60%',
      height: '60%',
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result.action) {
        if (result.action == 'CREATE') {
          this.buildTable();
        }
      }
    });
  }

  editCompany(company: Company) {
    const dialogRef = this.dialog.open(CompanyEditComponent, {
      disableClose: true,
      width: '60%',
      height: '60%',
      data: {
        id: company.id,
        name: company.name,
        address: company.address,
        email: company.email,
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

  deleteCompany(company: Company) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      disableClose: true,
      width: '50%',
      height: '30%',
    });
    dialogRef.componentInstance.title = 'Do you want to delete this company?';
    dialogRef.afterClosed().subscribe((result) => {
      if (result.action) {
        this._deleteCompanyUseCase.delete(company).subscribe((result) => {
          if (!result) {
            Swal.fire({
              icon: 'success',
              title: 'Company deleted successfully',
            });
            this.buildTable();
          } else {
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'Something went wrong deleting the company, please try again later!',
              footer: result!,
            });
          }
        });
      }
    });
  }
}
