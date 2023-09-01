import { Component, AfterViewInit, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { assets } from '../Model/user.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  baseUrl = "https://localhost:7041/";
  role!: any;
  asset!: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
   
    this.role = localStorage.getItem('role');
    this.getdata();
  }
  getdata() {
    this.http.get<assets>(this.baseUrl + 'AssetManagement/Dashboard').subscribe(response => {
      console.log(response);
      this.asset = response;
      //if (response != null) {
      //  this.asset = response;

      //}
    
    }, error => {
     
    });
   
  }

}

