import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyEditRoutingModule } from './company-edit-routing.module';
import { CompanyEditComponent } from './company-edit.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from '../../../shared/shared.module';


@NgModule({
  declarations: [
    CompanyEditComponent
  ],
  imports: [
    CommonModule,
    CompanyEditRoutingModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    ReactiveFormsModule,
    MatTooltipModule,
    MatIconModule
  ]
})
export class CompanyEditModule { }
