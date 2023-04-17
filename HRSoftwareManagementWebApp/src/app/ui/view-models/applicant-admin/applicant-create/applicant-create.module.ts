import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicantCreateComponent } from './applicant-create.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ApplicantCreateRoutingModule } from './applicant-create-routing.module';
import { MatSelectModule } from '@angular/material/select';



@NgModule({
  declarations: [ApplicantCreateComponent],
  imports: [
    CommonModule,
    ApplicantCreateRoutingModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    ReactiveFormsModule,
    FormsModule,
    MatTooltipModule,
    MatIconModule,
    MatSelectModule
  ]
})
export class ApplicantCreateModule { }
