import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup,FormControl, Validators,EmailValidator } from '@angular/forms';
import { Signup, role, city, CountryList, region, addressType } from '../../../Model/user.model';
import { count } from 'rxjs';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})

export class SignupComponent implements OnInit {
  baseUrl = "https://localhost:7041/";
  responseData?: string;
  roleList!:role[];
  addressTypeList!: addressType[];
  // countryList!: any[];
  countryList!: CountryList[];
  //countryList: country[] | null|un ;
  regionList!: region[];
  cityList!: city[];

 
  //https://localhost:7041/AssetManagement/AccessSignUp
  signupForm!: FormGroup;

 
  constructor(private Signupfb: FormBuilder, private http: HttpClient, private _router: Router) { }
  Signupdata?: Signup;

  ngOnInit(): void {
    this.roleSelect();
    this.addressTypeSelect();
    this.onselectCountry();
    this.signupForm = this.Signupfb.group({
      //country:[],
      //firstName: ['', Validators.required],
      //lastName: ['', Validators.required],
      //mobileNo: ['', Validators.required],
      //userName: ['', Validators.required],
      //email: ['', [Validators.required, Validators.email]],
      //password: ['', [Validators.required, Validators.minLength(6)]],
      // role: ['', Validators.required],
      membershipTypeCode:['', Validators.required],
      userName: ['', Validators.required],
/*      aliasName: ['',],*/
      password: ['', Validators.required],
      emailAddress: ['', [Validators.required, Validators.email]],
    
      tandCAccepted: [false],
      //profileImage: [''],
      //imageContentType: [''],
  /*    isPrimary: [false],*/
      salutation: ['', Validators.required],
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      dob: [null],
      sex: [''],
      email: [''],
      phoneAreaCode: [''],
      phone: [''],
      homePhone: [''],
      mobilePhone: [''],
      //website:[''],
      //fax: [''],
     isLockedOut:[false],
      preferredContact: [''],
      addTypeId: ['', Validators.required],
      address1: ['', Validators.required],
      address2: [''],
      address3: [''],
      countryId: ['', Validators.required],
      regionId: ['', Validators.required],
      cityId: ['', Validators.required],
      postCode: ['', Validators.required],
      active: [false],
      status: [false],


    });
  }
  
  SignupSubmit() {
    console.log('signup', this.signupForm.value)
    Object.keys(this.signupForm.controls).forEach(field => {
      const control = this.signupForm.get(field);
      if (control instanceof FormControl) {
     
        if (control.invalid) {
          control.markAsTouched();
        }
      }
    });

    if (this.signupForm.valid) {

      //const formData: FormData = new FormData();
    
      //Object.keys(this.signupForm.value).forEach(key => {
      //  formData.append(key, this.signupForm.value[key]);
      //});
     
      //const file: File = this.signupForm.get('profileImage')?.value;
      //formData.append('profileImage', file);
   

      console.log('signup', this.signupForm)
      const selectedValue = this.signupForm.value.country;
      console.log('selectedValue:', selectedValue);
      this.Signupdata = this.signupForm?.value;
      this.http.post(this.baseUrl + 'Login/AccessSignUp', this.Signupdata, { responseType: 'text' }).subscribe(response => {
        alert(response);
        console.log("Message");
        console.log('Request body', response);
        if (response == "Register Successful") {
          this._router.navigate(['/User-list']);
        
        }

      }, error => {
        console.log('Error', error);
        console.log('edit', this.Signupdata);

      });
    }
  }
  roleSelect() {
   
    this.countryList = this.signupForm?.value;
    this.http.get<role[]>(this.baseUrl + 'Login/RoleDropdownList').subscribe(Response => {
      console.log(Response);
      this.roleList = Response;
    }, error => {
   
    });

  }
  addressTypeSelect() { 
this.http.get<addressType[]>(this.baseUrl + 'Login/AddressTypeDropdownList').subscribe(Response => {
 
  this.addressTypeList = Response;
 
}, error => {
 
});

  }
  onregionSelect(countryId: number): void {
    this.http.get<region[]>(this.baseUrl + 'Login/RegionDropdownList?countryId='+countryId,).subscribe(response => {
      this.regionList = response;

    }, error => {
    });
   
  }
  oncitySelect(regionId:number) {
    this.http.get<city[]>(this.baseUrl + 'Login/CityDropdownList?regionId='+regionId).subscribe(response => {
      this.cityList = response;
    }, error => {
    });

  }
  onselectCountry() {
    this.countryList = this.signupForm?.value;
    this.http.get<CountryList[]>(this.baseUrl + 'Login/CountryDropdownList').subscribe(Response => {
      this.countryList =Response;
    }, error => {
    
    });

  }
}


