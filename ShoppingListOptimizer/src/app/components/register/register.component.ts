import {Component, OnInit} from '@angular/core';
import {AuthService} from "../../services/auth.service";
import { faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: any = {
    username: null,
    email: null,
    password: null
  };
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';
  faUser = faUser;

  constructor(private authService: AuthService) {
  }

  ngOnInit(): void {

  }

  onSubmit(): void {
    const {username, email, password} = this.form;

    this.authService.registerUser(username, email, password).subscribe(
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

}
