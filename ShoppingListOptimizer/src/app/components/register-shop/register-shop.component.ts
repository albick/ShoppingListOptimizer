import {Component, ViewEncapsulation} from '@angular/core';
import {AuthService} from 'src/app/services/auth.service';
import {Location, LocationModel} from 'src/app/models/generated';
import {Feature} from 'geojson';
import {NgbTimepickerConfig} from '@ng-bootstrap/ng-bootstrap';
import {faUser} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-register-shop',
  templateUrl: './register-shop.component.html',
  styleUrls: ['./register-shop.component.css']
})
export class RegisterShopComponent {

  form: any = {
    company: null,
    email: null,
    password: null
  };
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';

  location: LocationModel = {
    city: "",
    postcode: "",
    street: "",
    number: "",
    longitude: 0,
    latitude: 0
  };
  faUser = faUser;

  constructor(private authService: AuthService) {
  }

  ngOnInit(): void {

  }

  onSubmit(): void {
    const {company, email, password} = this.form;

    this.authService.registerShop(company, email, password, this.location).subscribe(
      data => {
        console.log(data);
        this.isSuccessful = true;
        this.isSignUpFailed = false;
      },
      err => {
        console.log(err)
        this.errorMessage = err.error.message;
        this.isSignUpFailed = true;
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
    console.log(this.location)
  }


}
