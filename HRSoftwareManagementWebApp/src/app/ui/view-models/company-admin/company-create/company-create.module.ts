import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyCreateRoutingModule } from './company-create-routing.module';
import { CompanyCreateComponent } from './company-create.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatIconModule } from '@angular/material/icon';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [CompanyCreateComponent],
  imports: [
    CommonModule,
    CompanyCreateRoutingModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    ReactiveFormsModule,
    MatTooltipModule,
    MatIconModule,
  ],
})
export class CompanyCreateModule {}
