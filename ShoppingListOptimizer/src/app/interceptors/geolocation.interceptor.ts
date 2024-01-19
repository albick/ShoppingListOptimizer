import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { GeolocationService } from '../services/geolocation.service';

@Injectable()
export class GeolocationInterceptor implements HttpInterceptor {

  constructor(private geolocationService:GeolocationService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let geoRequest = request;
    const geolocation = this.geolocationService.getGeolocation();

    if (geolocation != null) {
      geoRequest = request.clone({headers: request.headers.set('Geolocation', 'Geolocation ' + geolocation)});
    }

    return next.handle(geoRequest);
  }
}
