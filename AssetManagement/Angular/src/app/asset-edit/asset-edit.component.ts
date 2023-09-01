import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { assetItems, assetsdummy,AssetTypeList,DepartmentList,VendorList,OwnerList,UserList,Drop } from '../Model/Asset.Model';
import { MatDialogModule } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { AssetListComponent } from '../asset-list/asset-list.component';


@Component({
  selector: 'app-asset-edit',
  templateUrl: './asset-edit.component.html',
  styleUrls: ['./asset-edit.component.scss'],
  providers: [MatDialog]
})
export class AssetEditComponent implements OnInit {
  baseUrl = "https://localhost:7041/";
  assetfiles!: assetsdummy;
  assetsProp!: assetItems;

  assetTypeList: any[] = [];
 
  departmentList!: DepartmentList[];
  vendorlist!: VendorList[];
  ownerList!: OwnerList[];
  userList!: UserList[];
  constructor(public dialogRef: MatDialogRef<AssetEditComponent>,
    @Inject(MAT_DIALOG_DATA) private _matdata: any, private http: HttpClient
  /*  @Inject(AssetListComponent) private assetListComponent: AssetListComponent*/
  ) {
  }
  save() {
 
    this.dialogRef.close({
     });

   
    this.http.post(this.baseUrl + 'AssetManagement/UpdateAssetRegister?assetId=' + this.assetfiles.assetId, this.assetfiles).subscribe(response => {
  
    }, error => {
      alert("Something Wrong  Please Try Again Later")
      

    });
  }

  cancel() {
    this.dialogRef.close();
  }
  close(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
   
    this.assetfiles = this._matdata;
    this.onDropDownList();

  }
  onDropDownList() {
  
    this.http.get<Drop>(this.baseUrl + 'AssetManagement/GetDropdownList').subscribe(Response => {
   
      this.assetTypeList = Response.assetTypeList;
   
      this.departmentList = Response.departmentList;
      this.vendorlist = Response.vendorlist;
      this.ownerList = Response.ownerList;
      this.userList = Response.userList;
    }, error => {
   
    });

  }


}
