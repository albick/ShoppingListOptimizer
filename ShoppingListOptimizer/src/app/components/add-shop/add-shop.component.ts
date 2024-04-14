import {Component} from '@angular/core';
import {NgbTimeStruct} from '@ng-bootstrap/ng-bootstrap';
import {EMPTY, Observable} from 'rxjs';
import {DayOfWeek, LocationModel, OpeningHoursModel} from 'src/app/models/generated';
import {ShopService} from 'src/app/services/shop.service';
import {CommonModule} from '@angular/common';
import {Feature} from 'geojson';
import {faSquarePlus} from '@fortawesome/free-solid-svg-icons';

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


  faSquarePlus = faSquarePlus;

  weekdaysSameAsMonday = true;
  times: string[][] = []
  closedDays: boolean[] = [];

  constructor(private shopService: ShopService) {
    for (let i = 0; i <= 6; i++) {
      this.closedDays.push(false);

      const innerArray: string[] = [];
      innerArray.push("08:00");
      innerArray.push("17:00");
      this.times.push(innerArray);
    }

  }

  ngOnInit(): void {
    this.companies = this.shopService.getCompanies();
  }

  onSubmit() {
    const {company, name, details} = this.form;

    const times: string[][] = [];
    if (this.weekdaysSameAsMonday) {
      for (let i = 0; i < 5; i++) {
        if (this.closedDays[i]) {
          times.push(["00:00", "00:00"])
        } else {
          times.push(this.times[0]);
        }
      }
      for (let j = 5; j < 7; j++) {
        if (this.closedDays[j]) {
          times.push(["00:00", "00:00"])
        } else {
          times.push(this.times[j]);
        }
      }
    } else {
      for (let i = 0; i < 7; i++) {
        if (this.closedDays[i]) {
          times.push(["00:00", "00:00"])
        } else {
          times.push(this.times[i]);
        }
      }
    }


    this.shopService.addShop(name, details, company, this.location, times).subscribe(
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


  weekdaysSameAsMondayClicked() {
    this.weekdaysSameAsMonday = !this.weekdaysSameAsMonday;
  }

  closedDaysClicked(id: number) {
    if (id == 0) {
      this.weekdaysSameAsMonday = false;
    }
    this.closedDays[id] = !this.closedDays[id];
  }
}
