import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Observable, Subscription, throwError } from 'rxjs';
import { ServiceformComponent } from './serviceform/serviceform.component';
import { Identifiers } from '@angular/compiler';
import { catchError } from 'rxjs/operators';
import { Requests } from './requests';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  handleError(error: HttpErrorResponse) {
    return throwError(error.message || 'Server Error');
  }

  _url = 'http://localhost:4201/dashboardpage';

  constructor(private _http: HttpClient) {}

  enroll(userData) {
    return this._http
      .post<any>(this._url, userData, {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
      })
      .pipe(catchError(this.handleError));
  }
}
