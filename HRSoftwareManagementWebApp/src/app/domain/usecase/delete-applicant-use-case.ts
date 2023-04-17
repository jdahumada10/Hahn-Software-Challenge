import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApplicantGateway } from '../models/applicant/gateway/applicant-gateway';
import { Applicant } from '../models/applicant/applicant';

@Injectable({
  providedIn: 'root',
})
export class DeleteApplicantUseCase {
  constructor(private _applicantGateway: ApplicantGateway) {}

  delete(applicant: Applicant): Observable<string | null> {
    return this._applicantGateway.delete(applicant);
  }
}