import { NgModule } from '@angular/core';
import { SpinnerModule } from '../spinner/spinner.module';
import { SpinnerOverlayWrapperComponent } from './spinner-overlay-wrapper.component';
import { CommonModule } from '@angular/common';



@NgModule({
  imports: [CommonModule,SpinnerModule],
  declarations: [SpinnerOverlayWrapperComponent],
  exports: [SpinnerOverlayWrapperComponent]
})
export class SpinnerOverlayWrapperModule { }
