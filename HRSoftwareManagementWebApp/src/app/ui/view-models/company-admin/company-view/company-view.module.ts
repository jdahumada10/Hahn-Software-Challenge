import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompanyViewComponent } from './company-view.component';
import { CompanyViewRoutingModule } from './company-view-routing.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDialogModule } from '@angular/material/dialog';
import { SharedModule } from '../../../shared/shared.module';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [CompanyViewComponent],
  imports: [
    CommonModule,
    CompanyViewRoutingModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatDialogModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    SharedModule,
    MatButtonModule,
  ],
  exports: [CompanyViewComponent],
})
export class CompanyViewModule {}
