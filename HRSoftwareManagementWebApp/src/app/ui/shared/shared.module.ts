import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerModule } from './loading/spinner/spinner.module';
import { SpinnerOverlayModule } from './loading/spinner-overlay/spinner-overlay.module';
import { SpinnerOverlayWrapperModule } from './loading/spinner-overlay-wrapper/spinner-overlay-wrapper.module';
import { HeaderModule } from './header/header.module';
import { SearchbarModule } from './searchbar/searchbar.module';
import { ConfirmDialogModule } from './dialog/confirm-dialog/confirm-dialog.module';

@NgModule({
  imports: [
    CommonModule,
    SpinnerModule,
    SpinnerOverlayModule,
    SpinnerOverlayWrapperModule,
    HeaderModule,
    SearchbarModule,
    ConfirmDialogModule
  ],
  exports: [
    SpinnerModule,
    SpinnerOverlayModule,
    SpinnerOverlayWrapperModule,
    HeaderModule,
    SearchbarModule,
    ConfirmDialogModule
  ],
  declarations: [
  ],
})
export class SharedModule {}
