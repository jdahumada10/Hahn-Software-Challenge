import { OverlayModule } from '@angular/cdk/overlay';
import { NgModule } from '@angular/core';
import { SpinnerModule } from '../spinner/spinner.module';
import { SpinnerOverlayComponent } from './spinner-overlay.component';



@NgModule({
  imports: [SpinnerModule, OverlayModule],
  declarations: [SpinnerOverlayComponent],
  exports: [SpinnerOverlayComponent]
})
export class SpinnerOverlayModule { }
