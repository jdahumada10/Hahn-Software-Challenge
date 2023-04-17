import { Injectable } from '@angular/core';
import { CompanyGateway } from '../models/company/gateway/company-gateway';
import { Company } from '../models/company/company';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DeleteCompanyUseCase {
  constructor(private _companyGateway: CompanyGateway) {}

  delete(company: Company): Observable<string | null> {
    return this._companyGateway.delete(company);
  }
}