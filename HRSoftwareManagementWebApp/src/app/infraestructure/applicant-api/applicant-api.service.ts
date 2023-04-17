import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApplicantGateway } from '../../domain/models/applicant/gateway/applicant-gateway';
import { Applicant } from 'src/app/domain/models/applicant/applicant';
import { Observable, catchError, map, of, retry } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Company } from 'src/app/domain/models/company/company';

@Injectable({
  providedIn: 'root',
})
export class ApplicantApiService extends ApplicantGateway {
  private companyApiUrl: string = environment.companyApiUrl;
  private applicantApiUrl: string = environment.applicantApiUrl;

  constructor(private httpClient: HttpClient) {
    super();
  }

  getApplicantsByCompanyId(
    companyId: number
  ): Observable<Applicant[] | string> {
    return this.httpClient
      .get(`${this.companyApiUrl}/${companyId}/applicants`)
      .pipe(
        map((response: any) => {
          return response as Applicant[];
        }),
        retry({ count: 3, delay: 2000 }),
        catchError((err: HttpErrorResponse) => {
          this.logError(err);
          return of(err.message);
        })
      );
  }

  private logError(error: HttpErrorResponse) {
    console.error('ApplicantApiService:', error);
  }

  save(applicant: Applicant): Observable<string | Applicant> {
    console.log(applicant)
    return this.httpClient.post(this.applicantApiUrl, applicant).pipe(
      map((response: any) => {
        return response as Applicant;
      }),
      retry({ count: 1, delay: 1000 }),
      catchError((err: HttpErrorResponse) => {
        this.logError(err);
        return of(err.message);
      })
    );
  }
  update(applicant: Applicant): Observable<string | Applicant> {
    return this.httpClient
      .put(this.applicantApiUrl + `/${applicant.id}`, applicant)
      .pipe(
        map((response: any) => {
          return response as Applicant;
        }),
        retry({ count: 1, delay: 1000 }),
        catchError((err: HttpErrorResponse) => {
          this.logError(err);
          return of(err.message);
        })
      );
  }
  delete(applicant: Applicant): Observable<string | null> {
    return this.httpClient
      .delete(this.applicantApiUrl + `/${applicant.id}`)
      .pipe(
        map(() => {
          return null;
        }),
        catchError((err: HttpErrorResponse) => {
          this.logError(err);
          return of(err.message);
        })
      );
  }
}
