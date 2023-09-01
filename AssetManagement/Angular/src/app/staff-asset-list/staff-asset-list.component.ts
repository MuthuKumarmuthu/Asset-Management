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

import {StaffAssetDetailsComponent } from 'src/app/staff-asset-details/staff-asset-details.component';
import { AssetSearchCriteria } from '../Model/asset.Search.criteria';
import { assets } from '../Model/user.model';
/*import { AssetCreateComponent } from '../asset-create/asset-create.component';*/
@Component({
  selector: 'app-staff-asset-list',
  templateUrl: './staff-asset-list.component.html',
  styleUrls: ['./staff-asset-list.component.scss']
})
export class StaffAssetListComponent implements OnInit {


  displayedColumns: string[] = ['code', 'name', 'assetType', 'description', 'owner', 'user', 'vendor', 'action'];
  /*displayedColumns: string[] = ['code', 'assetType', 'name', 'user', 'vendor', 'description', 'action'];*/


  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  dataSource!: any;
  assetTablelist!: any;

  baseUrl = "https://localhost:7041/";
  showCard: boolean = false;
  myForm!: FormGroup;
  searchAssetCriteria?: AssetSearchCriteria;

  constructor(private http: HttpClient, private dialog: MatDialog, private fb: FormBuilder, private _router: Router) { }

  showFilter: boolean = true;
  assetfiles: assetsdummy[] = [];
  selectedAssets!: assetsdummy;
  // pagination!: PaginationModel;
  ngOnInit(): void {
    this.getcategorylist();
    this.getTableassets(this.assetfiles);
    this.myForm = this.fb.group({
      searchNameOFUser: ['', Validators.required],
      searchAssetName: ['', Validators.required],
      searchAssetCode: ['', Validators.required],
    });
    
  }


  viewAsset(assetfiles: assetItems, code: string) {  //string
    const selectedAsset = this.assetfiles.find(item => item.code === (code));
    this.selectedAssets = { ...selectedAsset };

    console.log('selectedAssets', this.selectedAssets)
    const dialogRef = this.dialog.open(StaffAssetDetailsComponent, {
      width: '570px',
      height: '600px',
      data: this.selectedAssets,
    });

  }
  onFilterSubmit() {
    console.log(this.myForm.value);
    // do something with the form data, e.g. send it to the server
  }
  showFilters() {
    this.showFilter = !this.showFilter;
  }



  getcategorylist() {

    const member = localStorage.getItem('membershipId');
    const membershipId = member ? parseInt(member, 10) : 0;
    console.log(membershipId);
    //const member = localStorage.getItem('MembershipId');
    //var membershipId = parseInt(member, 10);
    var role = localStorage.getItem('role');
   // this.http.post(this.baseUrl + 'AssetManagement/DeleteAssetRegister?assetid=' + assetId, null).subscribe(response => {
    this.http.get(this.baseUrl + 'AssetManagement/GetStaffAssets?membershipId=' + membershipId + '&role=' + role).subscribe((data: any) => {
      this.assetfiles = data;
      this.assetTablelist = this.assetfiles.map(asset => ({
    //assetId: asset.assetId,
      name: asset.name,
      code: asset.code,
      description: asset.description,
      status: asset.status,
      assetType: asset.assetType,
      department: asset.department,
    //assetStatusId: asset.assetStatusId,
      vendor: asset.vendor,
      owner: asset.owner,
      user: asset.user,
      serialNumber: asset.serialNumber,
      make: asset.make,
      model: asset.model,
      processor: asset.processor,
      memory: asset.memory,
      storage: asset.storage,
      operatingSystem: asset.operatingSystem,
      ipaddress: asset.ipaddress,
      insuranceDetails: asset.insuranceDetails,
      licenceDetails: asset.licenceDetails,
      licenceExpiry: asset.licenceExpiry,
      purchaseDate: asset.purchaseDate,
      invoiceNumber: asset.invoiceNumber,
      amc: asset.amc,
      warranty: asset.warranty,
      remarks: asset.remarks,
      location: asset.location,
    //toolId: asset.toolId,
      toolName: asset.toolName,
      toolSerialNo: asset.toolSerialNo,
      isInternal: asset.isInternal,
      keys: asset.keys,
      toolStatus: asset.toolStatus,
    //active: asset.active,



      }));

      console.log('assetfiles', data);
      console.log('assetfiles', data);
      this.getTableassets(data);
      console.log("Asset Up", assets);
      this.dataSource = new MatTableDataSource<any>(this.assetTablelist);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      console.log("Asset Mid");

    });
  }

  getTableassets(arr: any[]) {
    // const storedId = localStorage.getItem('Memberid');
    // const id = storedId ? parseInt(storedId, 10) : 0;
    // const User = localStorage.getItem('Username');
    this.assetTablelist = arr.map(asset => ({
     

    //assetId: asset.assetId,
      name: asset.name,
      code: asset.code,
      description: asset.description,
      status: asset.status,
      assetType: asset.assetType,
      department: asset.department,
    //assetStatusId: asset.assetStatusId,
      vendor: asset.vendor,
      owner: asset.owner,
      user: asset.user,
      serialNumber: asset.serialNumber,
      make: asset.make,
      model: asset.model,
      processor: asset.processor,
      memory: asset.memory,
      storage: asset.storage,
      operatingSystem: asset.operatingSystem,
      ipaddress: asset.ipaddress,
      insuranceDetails: asset.insuranceDetails,
      licenceDetails: asset.licenceDetails,
      licenceExpiry: asset.licenceExpiry,
      purchaseDate: asset.purchaseDate,
      invoiceNumber: asset.invoiceNumber,
      amc: asset.amc,
      warranty: asset.warranty,
      remarks: asset.remarks,
      location: asset.location,
    //toolId: asset.toolId,
      toolName: asset.toolName,
      toolSerialNo: asset.toolSerialNo,
      isInternal: asset.isInternal,
      keys: asset.keys,
      toolStatus: asset.toolStatus,
      active: asset.active,


    }));

    console.log('new table assets', this.assetTablelist);
    console.log('Asset Down', assets);
  }


  applyFilter(event: Event) {

    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue;

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
