import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CompanyGateway } from './domain/models/company/gateway/company-gateway';
import { CompanyApiService } from './infraestructure/company-api/company-api.service';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './ui/shared/shared.module';
import { RouterModule } from '@angular/router';
import { ApplicantGateway } from './domain/models/applicant/gateway/applicant-gateway';
import { ApplicantApiService } from './infraestructure/applicant-api/applicant-api.service';
import { ApplicantEditComponent } from './ui/view-models/applicant-admin/applicant-edit/applicant-edit.component';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    SharedModule,
    RouterModule,
  ],
  providers: [
    {
      provide: CompanyGateway,
      useClass: CompanyApiService,
    },
    {
      provide: ApplicantGateway,
      useClass: ApplicantApiService,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
