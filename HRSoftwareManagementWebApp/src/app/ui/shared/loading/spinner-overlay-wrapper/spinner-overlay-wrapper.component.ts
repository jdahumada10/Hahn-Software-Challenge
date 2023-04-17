import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-spinner-overlay-wrapper',
  templateUrl: './spinner-overlay-wrapper.component.html',
  styleUrls: ['./spinner-overlay-wrapper.component.scss']
})
export class SpinnerOverlayWrapperComponent implements OnInit {

  @Input() showSpinner = false;
  @Input() message: string = '';
  
  constructor() { }

  ngOnInit() {
  }

}
