import { TestBed } from '@angular/core/testing';

import { GeolocationInterceptor } from './geolocation.interceptor';

describe('GeolocationInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      GeolocationInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: GeolocationInterceptor = TestBed.inject(GeolocationInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
