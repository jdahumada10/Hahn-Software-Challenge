import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from '../models/company/company';
import { CompanyGateway } from '../models/company/gateway/company-gateway';

@Injectable({
  providedIn: 'root',
})
export class GetCompanyUseCase {
  constructor(private _companyGateway: CompanyGateway) {}

  getAll(): Observable<Company[] | string> {
    return this._companyGateway.getAll();
  }
}
