import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private _router: Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = localStorage.getItem('token');
    console.log('Token!',token)
    if (token) {
      request = request.clone({
        setHeaders: { Authorization: `Bearer ${token}` }
        /*  setHeaders: {Authorization:token}*/
      })
    }
    else {
      alert("Token Expired Please Login");
      this._router.navigate(['/User-list']);
    }
    return next.handle(request);
  }
}
