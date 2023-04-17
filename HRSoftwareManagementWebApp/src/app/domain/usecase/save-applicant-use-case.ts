import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CompanyGateway } from '../models/company/gateway/company-gateway';
import { Applicant } from '../models/applicant/applicant';
import { ApplicantGateway } from '../models/applicant/gateway/applicant-gateway';

@Injectable({
  providedIn: 'root',
})
export class SaveApplicantUseCase {
  constructor(private _applicantGateway: ApplicantGateway) {}

  save(applicant:Applicant): Observable<Applicant | string>{
    return this._applicantGateway.save(applicant);
  }
  
  update(applicant:Applicant): Observable<Applicant | string>{
    return this._applicantGateway.update(applicant);
  }
}
