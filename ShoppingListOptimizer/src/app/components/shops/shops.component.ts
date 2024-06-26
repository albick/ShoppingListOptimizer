import {Component, OnInit} from '@angular/core';
import {faMagnifyingGlass, faMagnifyingGlassLocation } from '@fortawesome/free-solid-svg-icons';
import {EMPTY, Observable} from 'rxjs';
import {ShopResponse} from 'src/app/models/generated';
import {ShopService} from 'src/app/services/shop.service';

@Component({
  selector: 'app-shops',
  templateUrl: './shops.component.html',
  styleUrls: ['./shops.component.css']
})
export class ShopsComponent implements OnInit{
  form={
    name:"",
    distance:0
  }

  maxShopDistance: Observable<number> = EMPTY;
  shops: Observable<ShopResponse[]> = EMPTY;

  faMagnifyingGlass= faMagnifyingGlass;

  constructor(private shopService: ShopService) {

  }

  ngOnInit(): void {
    this.maxShopDistance = this.shopService.getMaxShopDistance();
    this.shops = this.shopService.getShops();
    this.shops.subscribe(data=>{
      console.log(data)
    });
  }

  onSubmit(): void {

    const {name,distance} = this.form;
    console.log(name,distance)
    this.shops=this.shopService.getShops(name,distance);
    /*this.authService.login(email, password).subscribe(
      data => {
        console.log(data.AccessToken)
        this.tokenStorage.saveToken(data.AccessToken);
        this.tokenStorage.saveUser(data);

        this.isLoginFailed = false;
        this.isLoggedIn = true;

        this.roles = this.tokenStorage.getUser().Roles;
        this.reloadPage();
        this.router.navigate(['home']);
      },
      err => {
        this.errorMessage = err.error.message;
        this.isLoginFailed = true;
      }
    );*/
  }

}
