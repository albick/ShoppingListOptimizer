import { Injectable } from '@angular/core';

const GEOLOCATION = 'GEOLOCATION';
@Injectable({
  providedIn: 'root'
})
export class GeolocationService {

  constructor() { }

  public saveGeolocation(latitude:Number,longitude:Number): void {
    window.sessionStorage.removeItem(GEOLOCATION);
    window.sessionStorage.setItem(GEOLOCATION, latitude+";"+longitude);
  }

  public getGeolocation(): string | null {
    return window.sessionStorage.getItem(GEOLOCATION);
  }
}
