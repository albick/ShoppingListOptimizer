import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {DayOfWeek, LocationModel, OpeningHoursModel, ShopRequest, ShopResponse} from '../models/generated';
import {NgbTimeStruct} from '@ng-bootstrap/ng-bootstrap';


const API_URL = 'https://localhost:7090/api/shops/';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  constructor(private http: HttpClient) {
  }

  getShops(distance: number = 0): Observable<ShopResponse[]> {
    return this.http.get<ShopResponse[]>(API_URL + `?limit=${distance}`);
  }
  getCompanies(): Observable<string[]> {
    return this.http.get<string[]>(API_URL + `companies`);
  }

  addShop(name: string, details: string, companyName: string, location: LocationModel, times: NgbTimeStruct[][]): Observable<ShopResponse> {

    var openingHours: OpeningHoursModel[] = [];
    for (let i = 0; i < times.length; i++) {
      let dayOfWeek: DayOfWeek = i;

      let startTime = times[i][0].hour + ":" + times[i][0].minute + ":" + times[i][0].second;
      let endTime = times[i][1].hour + ":" + times[i][1].minute + ":" + times[i][1].second;

      let day: OpeningHoursModel = {
        DayOfWeek: dayOfWeek,
        StartTime: startTime,
        EndTime: endTime
      }
      openingHours.push(day);
    }

    let shop:ShopRequest={
      Name:name,
      Details:details,
      CompanyName:companyName,
      Location:location,
      OpeningHours:openingHours
    }
    return this.http.post<ShopResponse>(API_URL,shop);
    //return this.http.get<ShopResponse>(API_URL);
  }

}
