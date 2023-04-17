import { Component, Input } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.scss'],
})
export class ConfirmDialogComponent {
  @Input() title: string = '';
  @Input() text: string | null = null;

  constructor(private dialogRef: MatDialogRef<ConfirmDialogComponent>) {}

  onAnswer(answer: boolean) {
    this.dialogRef.close({ action: answer });
  }
}
