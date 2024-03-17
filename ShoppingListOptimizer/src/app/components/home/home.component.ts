import { Component } from '@angular/core';
import {faBarcode, faMagnifyingGlass, faMicroscope, faReceipt, faShop, faSquarePlus, faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  faUser = faUser;
  faShop=faShop;
  faReceipt=faReceipt;
  faMagnifyingGlass=faMagnifyingGlass;
  faSquarePlus=faSquarePlus;
  faBarcode=faBarcode;
  faMicroscope=faMicroscope;
}
