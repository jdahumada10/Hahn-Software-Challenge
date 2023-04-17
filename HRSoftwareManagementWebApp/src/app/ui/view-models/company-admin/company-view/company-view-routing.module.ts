import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { CompanyViewComponent } from './company-view.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyViewComponent,
  },
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyViewRoutingModule {}
