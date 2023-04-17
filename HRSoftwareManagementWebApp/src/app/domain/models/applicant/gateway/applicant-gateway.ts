import { Observable } from 'rxjs';
import { Applicant } from '../applicant';

export abstract class ApplicantGateway {
  abstract getApplicantsByCompanyId(
    companyId: number
  ): Observable<Applicant[] | string>;

  abstract save(applicant: Applicant): Observable<Applicant | string>;
  abstract update(applicant: Applicant): Observable<Applicant | string>;
  abstract delete(applicant: Applicant): Observable<string | null>;
}
