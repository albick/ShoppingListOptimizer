import {Component, OnInit} from '@angular/core';
import {TokenStorageService} from "./services/token-storage.service";
import {GeolocationService} from './services/geolocation.service';
import {faHouse, faRightFromBracket} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  roles: string[] = [];
  isLoggedIn = false;
  showAdmin = false;
  username?: string;
  userId: string = "";

  faHouse = faHouse;
  faRightFromBracket = faRightFromBracket;

  constructor(private tokenStorageService: TokenStorageService, private geolocationService: GeolocationService) {
  }

  ngOnInit(): void {
    this.getGeolocation();
    this.isLoggedIn = !!this.tokenStorageService.getToken();

    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();

      this.roles = user.Roles;

      this.showAdmin = this.roles.includes('Admin');

      this.username = user.RefreshToken.username;
      this.userId = user.id;
    }
  }

  logout(): void {
    this.tokenStorageService.signOut();
    window.location.reload();
  }

  getGeolocation() {
    if ('geolocation' in navigator) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          const latitude = position.coords.latitude;
          const longitude = position.coords.longitude;
          this.geolocationService.saveGeolocation(latitude, longitude);
          console.log(this.geolocationService.getGeolocation());
        },
        (error) => {
          console.error('Error getting geolocation:', error);
        }
      );
    } else {
      console.error('Geolocation is not supported by this browser.');
    }
  }
}
