import {Component, OnInit} from '@angular/core';
import {TokenStorageService} from "./services/token-storage.service";

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

  constructor(private tokenStorageService: TokenStorageService) {
  }

  ngOnInit(): void {
    this.isLoggedIn = !!this.tokenStorageService.getToken();

    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();

      this.roles = user.roles;

      this.showAdmin = this.roles.includes('Admin');

      this.username = user.refreshToken.username;
      this.userId = user.id;
    }
  }

  logout(): void {
    this.tokenStorageService.signOut();
    window.location.reload();
  }
}
