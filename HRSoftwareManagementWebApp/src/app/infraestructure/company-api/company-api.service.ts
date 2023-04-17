import {
  HttpClient,
  HttpErrorResponse,
  HttpResponse,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, of, retry } from 'rxjs';
import { Company } from 'src/app/domain/models/company/company';
import { CompanyGateway } from '../../domain/models/company/gateway/company-gateway';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CompanyApiService extends CompanyGateway {
  private companyApiUrl: string = environment.companyApiUrl;
  constructor(private httpClient: HttpClient) {
    super();
  }

  getAll(): Observable<Company[] | string> {
    return this.httpClient.get(this.companyApiUrl).pipe(
      map((response: any) => {
        return response as Company[];
      }),
      retry({ count: 3, delay: 2000 }),
      catchError((err: HttpErrorResponse) => {
        this.logError(err);
        return of(err.message);
      })
    );
  }

  private logError(error: HttpErrorResponse) {
    console.error('CompanyApiService:', error);
  }

  save(company: Company): Observable<Company | string> {
    return this.httpClient.post(this.companyApiUrl, company).pipe(
      map((response: any) => {
        return response as Company;
      }),
      retry({ count: 1, delay: 1000 }),
      catchError((err: HttpErrorResponse) => {
        this.logError(err);
        return of(err.message);
      })
    );
  }

  update(company: Company): Observable<Company | string> {
    return this.httpClient
      .put(this.companyApiUrl + `/${company.id}`, company)
      .pipe(
        map((response: any) => {
          return response as Company;
        }),
        retry({ count: 1, delay: 1000 }),
        catchError((err: HttpErrorResponse) => {
          this.logError(err);
          return of(err.message);
        })
      );
  }

  delete(company: Company): Observable<string | null> {
    return this.httpClient
      .delete(this.companyApiUrl + `/${company.id}`)
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
