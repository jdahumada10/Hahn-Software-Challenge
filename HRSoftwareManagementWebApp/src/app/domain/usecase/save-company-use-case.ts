import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from '../models/company/company';
import { CompanyGateway } from '../models/company/gateway/company-gateway';

@Injectable({
  providedIn: 'root',
})
export class SaveCompanyUseCase {
  constructor(private _companyGateway: CompanyGateway) {}

  save(company:Company): Observable<Company | string>{
    return this._companyGateway.save(company);
  }
  
  update(company:Company): Observable<Company | string>{
    return this._companyGateway.update(company);
  }
}
