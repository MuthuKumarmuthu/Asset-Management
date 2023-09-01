import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EmailValidator, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { login,MyResponse} from '../Model/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  baseUrl = "https://localhost:7041/";
  loginForm!: FormGroup;
  login!: login;

  responseData:any;
  
  constructor(private loginfb: FormBuilder, private http: HttpClient, private _router: Router, private authService: AuthService) {
  }


  loginSubmit() {
    const { userName, password } = this.loginForm.value;
     this.login = this.loginForm.value;
    this.authService.login(this.login).subscribe(response => {
      console.log(response);
    
       this.responseData = "Login Successful";
      if (response != null) {
        if (/*response.userName === userName && response.role != null &&*/ response.isLockedOut == false) {
          const membershipId = response.membershipId;
          const username = response.userName;
          const role = response.role;
          const token = response.token;
          localStorage.setItem('membershipId', membershipId.toString());
          localStorage.setItem('username', username.toString());
          localStorage.setItem('role', role.toString());
          localStorage.setItem('token', token.toString());
          if (response.role == "SADMIN") {
            this._router.navigate(['/dashboard']);

          }
          else if (response.role == "ADMIN" && response.isLockedOut == false) {
            this._router.navigate(['/Asset-list']);
          }
          else if (response.role == "STAFF" || response.role == "OWNER" && response.isLockedOut == false) {

            this._router.navigate(['/Staff-asset-list']);
          }

        }
        else if (response.isLockedOut == true) {

          alert("Your Account Is Blocked ");
        }
        //else if (response.failedPasswordAttemptCount > 3) {
        //  console.log(response.failedPasswordAttemptCount);
        //  alert("Your Account is Blocked ");
        //  response.failedPasswordAttemptCount;
        //  console.log(response.failedPasswordAttemptCount);

    //  }
        else {
          alert("UserName Or Password Incorrect");
        };
      }
      else {
        alert("User Name Doesn't Exists");
      }

     }, error => {
      alert("Something Wrong  Please Try Again Later")
     
    });



  
  }


  ngOnInit(): void {
    this.loginForm = this.loginfb.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }


}
