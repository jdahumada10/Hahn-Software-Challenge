import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home.component';

const routes: Routes = [
  {
    path:'',
    component: HomeComponent,
    children:[
      {
        path: 'overview',
        loadChildren: () => import('../overview/overview.module').then(m => m.OverviewModule)
      },
      {
        path: 'companies',
        loadChildren: () => import('../company-admin/company-admin.module').then(m => m.CompanyAdminModule)
      },
      {
        path: '**',
        redirectTo: 'overview'
      }
    ]
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class HomeRoutingModule { }
