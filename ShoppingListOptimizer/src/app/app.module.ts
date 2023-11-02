import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {LoginComponent} from './components/login/login.component';
import {RegisterComponent} from './components/register/register.component';
import {AppRoutingModule} from "./app-routing.module";

import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {RegisterShopComponent} from './components/register-shop/register-shop.component';
import {GeoapifyGeocoderAutocompleteModule} from '@geoapify/angular-geocoder-autocomplete';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    RegisterShopComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule,
    GeoapifyGeocoderAutocompleteModule.withConfig('d69bf89b9e5c4838bc7dd0cf2ede270a')
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
