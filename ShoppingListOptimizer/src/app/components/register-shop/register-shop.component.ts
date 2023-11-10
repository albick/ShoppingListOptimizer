import {Component, ViewEncapsulation} from '@angular/core';
import {AuthService} from 'src/app/services/auth.service';
import {Location, LocationModel} from 'src/app/models/generated';
import {Feature} from 'geojson';
import { NgbTimepickerConfig } from '@ng-bootstrap/ng-bootstrap';

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
        City: "",
        Postcode: "",
        Street: "",
        Number: "",
        Longitude: 0,
        Latitude: 0
    };

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
            this.location.City = _city;
        } else {
            this.location.City = ""
        }
        // @ts-ignore
        let _postcode = data.properties['postcode']
        if (_postcode !== undefined) {
            this.location.Postcode = _postcode;
        } else {
            this.location.Postcode = ""
        }
        // @ts-ignore
        let _street = data.properties['street']
        if (_street !== undefined) {
            this.location.Street = _street;
        } else {
            this.location.Street = ""
        }
        // @ts-ignore
        let _number = data.properties['housenumber']
        if (_number !== undefined) {
            this.location.Number = _number;
        } else {
            this.location.Number = ""
        }
        // @ts-ignore
        this.location.Latitude = data.properties['lat'];
        // @ts-ignore
        this.location.Longitude = data.properties['lon'];
        console.log(this.location)
    }


}
