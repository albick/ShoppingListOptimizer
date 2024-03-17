import {Component} from '@angular/core';
import {NgbTimeStruct} from '@ng-bootstrap/ng-bootstrap';
import {EMPTY, Observable} from 'rxjs';
import {DayOfWeek, LocationModel, OpeningHoursModel} from 'src/app/models/generated';
import {ShopService} from 'src/app/services/shop.service';
import { CommonModule } from '@angular/common';
import { Feature } from 'geojson';
import { faSquarePlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-add-shop',
  templateUrl: './add-shop.component.html',
  styleUrls: ['./add-shop.component.css']
})
export class AddShopComponent {
  isSuccessful = false;
  isAddFailed = false;
  errorMessage = "";

  companies: Observable<string[]> = EMPTY;

  protected readonly DayOfWeek = DayOfWeek;
  daysOfWeek = Object.keys(DayOfWeek).map(key => parseInt(key)).filter(value => !isNaN(value));

  form: any = {
    company: null,
    name: null,
    details: null
  };

  location: LocationModel = {
    city: "",
    postcode: "",
    street: "",
    number: "",
    longitude: 0,
    latitude: 0
  };
  //days from monday to sunday
  times: NgbTimeStruct[][] = [];


  faSquarePlus=faSquarePlus;

  weekdaysSameAsMonday=true;

  constructor(private shopService: ShopService) {
    for (let i = 0; i <= 6; i++) {
      const innerArray: NgbTimeStruct[] = [];
      for (let j = 0; j <= 1; j++) {
        innerArray.push({hour: 0, minute: 0, second: 0});
      }
      this.times.push(innerArray);
    }
  }

  ngOnInit(): void {
    this.companies=this.shopService.getCompanies();
  }

  onSubmit() {
    const {company, name, details} = this.form;

    this.shopService.addShop(name, details, company, this.location, this.times).subscribe(
      data => {
        console.log(data);
        this.isSuccessful = true;
        this.isAddFailed = false;
      },
      err => {
        console.log(err)
        this.errorMessage = err.error.message;
        this.isAddFailed = true;
      }
    );

  }

  placeSelected(data: Feature) {
    // @ts-ignore
    let _city = data.properties['city']
    if (_city !== undefined) {
      this.location.city = _city;
    } else {
      this.location.city = ""
    }
    // @ts-ignore
    let _postcode = data.properties['postcode']
    if (_postcode !== undefined) {
      this.location.postcode = _postcode;
    } else {
      this.location.postcode = ""
    }
    // @ts-ignore
    let _street = data.properties['street']
    if (_street !== undefined) {
      this.location.street = _street;
    } else {
      this.location.street = ""
    }
    // @ts-ignore
    let _number = data.properties['housenumber']
    if (_number !== undefined) {
      this.location.number = _number;
    } else {
      this.location.number = ""
    }
    // @ts-ignore
    this.location.latitude = data.properties['lat'];
    // @ts-ignore
    this.location.longitude = data.properties['lon'];
  }


}
