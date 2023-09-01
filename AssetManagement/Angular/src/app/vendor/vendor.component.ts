import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { Router } from '@angular/router';
import { Vendor, city, CountryList, region, addressType } from '../Model/user.model';


@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styleUrls: ['./vendor.component.scss']
})
export class VendorComponent implements OnInit {

  vendorForm!: FormGroup;
  Vendors!: Vendor;
  countryList: CountryList[]  | undefined;
  //countryList: country[] | null|un ;
  regionList!: region[] | undefined;
  cityList!: city[] | undefined;
  addressTypeList!: addressType[];
 
  constructor(private Vendorfb: FormBuilder, private router: Router, private http: HttpClient,) { }
  baseUrl = "https://localhost:7041/";
  

  ngOnInit() {
   
    this.addressTypeSelect();
    this.onselectCountry();
 
    this.vendorForm = this.Vendorfb.group({

      vendorName: ['', Validators.required],
    /*  isPrimary: [false],*/
      salutation: ['', Validators.required],
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      dob: [null],
      sex: [''],
      email: ['', [Validators.required, Validators.email]],
     /* email: ['', Validators.required, Validators.email],*/
      phoneAreaCode: [''],
      phone: [''],
      homePhone: [''],
      mobilePhone: [''],
      fax: [''],
      preferredContact: [''],
      website: [''],
      addTypeId: ['', Validators.required],
      address1: ['', Validators.required],
      address2: [''],
      address3: [''],
      cityId: ['', Validators.required],
      regionId: ['', Validators.required],
      countryId: ['', Validators.required],
      postCode: ['', Validators.required],
      active: [false],
      status:[false],




    });
  }
  VendorSubmit() {


    Object.keys(this.vendorForm.controls).forEach(field => {
      const control = this.vendorForm.get(field);
      if (control instanceof FormControl) {
     
        if (control.invalid) {
          control.markAsTouched();
        }
      }
    });

    if (this.vendorForm.valid) {
    this.Vendors = this.vendorForm?.value;
      this.http.post(this.baseUrl + 'Login/AccessVendorSignUp', this.Vendors, { responseType: 'text' }).subscribe(data => {
      console.log('Request body', data);
      alert(data);
      this.router.navigate(['/User-list']);

    }, error => {
  
    });
  }
  }
 

  addressTypeSelect() {

    this.http.get<addressType[]>(this.baseUrl + 'Login/AddressTypeDropdownList').subscribe(Response => {
      console.log(Response);
      this.addressTypeList = Response;
      console.log('Adderss  Type', this.addressTypeList);


    }, error => {
  
    });

  }


  onselectCountry() {

    this.http.get<CountryList[]>(this.baseUrl + 'Login/CountryDropdownList').subscribe(Response => {
      console.log(Response);
      this.countryList = Response;
     


    }, error => {
   
    });

  }


  onregionSelect(countryId: number): void {
    this.http.get<region[]>(this.baseUrl + 'Login/RegionDropdownList?countryId='+countryId).subscribe(response => {
      this.regionList = response;
    
    }, error => {
    


    });

  }
  oncitySelect(regionId: number) {
  this.http.get<city[]>(this.baseUrl + 'Login/CityDropdownList?regionId='+regionId).subscribe(response => {
      this.cityList = response;
     


    }, error => {
     


    });

  }

}
