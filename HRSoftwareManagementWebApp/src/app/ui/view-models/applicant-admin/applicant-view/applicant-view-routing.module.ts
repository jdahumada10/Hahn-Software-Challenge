import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplicantViewComponent } from './applicant-view.component';

const routes: Routes = [
  {
    path:'',
    component: ApplicantViewComponent
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplicantViewRoutingModule { }
