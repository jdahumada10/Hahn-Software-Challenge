import { Observable } from 'rxjs';
import { Company } from '../company';

export abstract class CompanyGateway {
  abstract getAll(): Observable<Company[] | string>;
  abstract save(company: Company): Observable<Company | string>;
  abstract update(company: Company): Observable<Company | string>;
  abstract delete(company: Company): Observable<string | null>;
}
