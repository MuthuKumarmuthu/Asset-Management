import { Component, AfterViewInit, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { assetItems, assetsdummy, AssetTableList } from '../Model/Asset.Model';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { map, Observable, of, tap } from 'rxjs';
import { Router } from '@angular/router';
import { AssetEditComponent } from '../asset-edit/asset-edit.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { StaffAssetDetailsComponent } from 'src/app/staff-asset-details/staff-asset-details.component';
import { UserItems,AssetSearchCriteria, User } from '../Model/user.model';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {



  displayedColumns: string[] = ['userName', 'role','isLockedOut','action'];


  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  dataSource!: any;
  userTablelist!: any;
  userName!: string;
  baseUrl = "https://localhost:7041/";
  showCard: boolean = false;
  myForm!: FormGroup;
  searchAssetCriteria?: AssetSearchCriteria;
 
 // public isEnabled: boolean = true;
  constructor(private http: HttpClient, private dialog: MatDialog, private fb: FormBuilder, private _router: Router) { }

  showFilter: boolean = true;
  //assetfiles: assetsdummy[] = [];
  //selectedAssets!: assetsdummy;


  userfiles: UserItems[]=[];
  selectUsers!: UserItems;
 // user!: any;
  // pagination!: PaginationModel;
  ngOnInit(): void {
    
    this.getcategorylist();
    this.getTableassets(this.userfiles);
    this.myForm = this.fb.group({
      searchNameOFUser: ['', Validators.required],
      searchAssetName: ['', Validators.required],
      searchAssetCode: ['', Validators.required],
    });
    //  this.pagination = new PaginationModel();
  }


 

  showFilters() {
    this.showFilter = !this.showFilter;
  }



  getcategorylist() {
    this.http.get<UserItems[]>(this.baseUrl + 'AssetManagement/GetUserRegister',).subscribe((data: any) => {
      this.userfiles = data;
      this.userTablelist = this.userfiles.map(user => ({

        membershipId: user.membershipId,
        userName: user.userName,
        role: user.role,
        isLockedOut: user.isLockedOut,
     //   active:user.active
    


      }));
      this.getTableassets(data);
     // this.userTablelist = this.user;
      console.log('userfiles', data);

      console.log('user Table List', this.userTablelist);
    
      this.dataSource = new MatTableDataSource<any>(this.userTablelist);
      console.log("DataSource",this.dataSource);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;

    });



  }


  getTableassets(arr: any[]) {

    this.userTablelist = arr.map(user => ({
      membershipId: user.membershipId,
      userName: user.userName,
      role: user.role,
      isLockedOut: user.isLockedOut,
     


    }));

    console.log('new table assets', this.userTablelist);
  }


  
  editUser(membershipId: any,isLockedOut:boolean) {

    console.log(membershipId);
    console.log(isLockedOut);
  //  this.http.get(this.baseUrl + 'AssetManagement/GetStaffAssets?membershipId=' + membershipId + '&role=' + role).subscribe((data: any) => {
    this.http.post(this.baseUrl + 'AssetManagement/UpdateUserStatus?membershipId=' + membershipId + '&isLockedOut=' + isLockedOut, null).subscribe(response => {
      this.getcategorylist();
      console.log('Request body', response);
    }, error => {
      console.log('Error', error);
      console.log('edit', this.userfiles);

    });
  }

  onFilterSubmit() {
    console.log(this.userName);
    const SearchObject = this.myForm.value;
    console.log(this.myForm.value);

    this.http.get<any>(this.baseUrl + 'AssetManagement/GetUserFilter?userName='+this.userName).subscribe(
      (data: any) => {
        console.log("Hello");
        console.log('Request body', Response);

        this.userfiles = data;

        console.log('assetfiles', data);
        this.getTableassets(data);
        this.dataSource = new MatTableDataSource<any>(this.userTablelist);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.showCard = false;
        console.log(this.showCard);
      }, error => {
        console.log('Error', error);
      });

    // do something with the form data, e.g. send it to the server




  }


  applyFilter(event: Event) {

    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue;

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
