import { Injectable } from '@angular/core';
import { ApplicantGateway } from '../models/applicant/gateway/applicant-gateway';
import { Applicant } from '../models/applicant/applicant';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GetApplicantUseCase {
  constructor(private _applicantGateway: ApplicantGateway) {}

  getApplicantsByCompanyId(companyId: number): Observable<Applicant[] | string> {
    return this._applicantGateway.getApplicantsByCompanyId(companyId);
  }
}
