import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyAdminComponent } from './company-admin.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyAdminComponent,
    children: [
      {
        path: 'company-view',
        loadChildren: () =>
          import('./company-view/company-view.module').then(
            (m) => m.CompanyViewModule
          ),
      },
      {
        path: ':companyId',
        loadChildren: () =>
          import(
            '../applicant-admin/applicant-view/applicant-view.module'
          ).then((m) => m.ApplicantViewModule),
      },
      {
        path: ':companyId/applicant/create',
        loadChildren: () =>
          import(
            '../applicant-admin/applicant-create/applicant-create.module'
          ).then((m) => m.ApplicantCreateModule),
      },
      {
        path: ':companyId/applicant/:applicantId/edit',
        loadChildren: () =>
          import(
            '../applicant-admin/applicant-edit/applicant-edit.module'
          ).then((m) => m.ApplicantEditModule),
      },
      {
        path: 'company-create',
        loadChildren: () =>
          import('./company-create/company-create.module').then(
            (m) => m.CompanyCreateModule
          ),
      },
      {
        path: 'company-edit',
        loadChildren: () =>
          import('./company-edit/company-edit.module').then(
            (m) => m.CompanyEditModule
          ),
      },
      {
        path: '**',
        redirectTo: 'company-view',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyAdminRoutingModule {}
