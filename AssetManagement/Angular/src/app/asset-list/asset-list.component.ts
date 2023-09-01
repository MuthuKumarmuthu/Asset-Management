import { Component, AfterViewInit, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { assetItems, assetsdummy, AssetTableList } from '../Model/Asset.Model';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { filter, map, Observable, of, tap } from 'rxjs';
import { Router } from '@angular/router';
import { AssetEditComponent } from '../asset-edit/asset-edit.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { AssetDetailsComponent } from '../asset-details/asset-details.component';
import { AssetSearchCriteria } from '../Model/asset.Search.criteria';
import { AssetCreateComponent } from '../asset-create/asset-create.component';

import * as XLSX from 'xlsx';
//import { saveAs } from 'file-saver';


@Component({
  selector: 'app-asset-list',
  templateUrl: './asset-list.component.html',
  styleUrls: ['./asset-list.component.scss']
})
export class AssetListComponent implements OnInit {

  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  //displayedColumns: string[] = ['code', 'assetType', 'owner', 'name', 'user', 'vendor', 'description', 'action'];

  displayedColumns: string[] = ['code', 'name', 'assetType', 'description','owner' , 'user', 'vendor', 'action'];
  //dataSource = new MatTableDataSource<AssetTableList>([]);
  //assetTablelist!: any[];
  dataSource!: any;
  assetTablelist!: any;
 
  /*  forecasts: Array<assetmanager> | undefined;*/
  baseUrl = "https://localhost:7041/";
  showCard: boolean = false;
  myForm!: FormGroup;
  SearchObject!: AssetSearchCriteria;
  constructor(private http: HttpClient, private dialog: MatDialog, private fb: FormBuilder, private _router: Router) { }
  showFilter: boolean = true;
  assetfiles: assetsdummy[] = [];
  selectedAssets!: assetsdummy;
 // pagination!: PaginationModel;
  ngOnInit(): void {
    this.getcategorylist();
    this.getTableassets(this.assetfiles);
    this.myForm = this.fb.group({
      searchNameOFUser: [''],
      searchAssetName: [''],
      searchAssetCode: [''],
 
    });
    console.log(this.myForm);
  //  this.pagination = new PaginationModel();
  }

  viewAsset(assetfiles: assetItems, assetId: number) {  //string
    const selectedAsset = this.assetfiles.find(item => item.assetId === Number(assetId));
    this.selectedAssets = { ...selectedAsset };

    console.log('selectedAssets', this.selectedAssets)
    const dialogRef = this.dialog.open(AssetDetailsComponent, {
      width: '570px',
      height: '600px',
      data: this.selectedAssets,
  
    });

  }

 
  showFilters() {
    this.showFilter = !this.showFilter;
  }


  editAsset(assetfiles: assetsdummy, assetId: number) {
    const selectedAsset = this.assetfiles.find(item => item.assetId === Number(assetId));

    console.log('edit asset files', this.assetfiles)
    this.selectedAssets = { ...assetfiles };
    console.log('selectedAssets', this.selectedAssets)
    // Open the dialog box
   
      const dialogRef = this.dialog.open(AssetEditComponent, {
        width: '570px',
        data: this.selectedAssets,
      });
 
      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          // Update the selected product
        
          this.selectedAssets.name = result.name;
          this.selectedAssets.code = result.code;
          this.selectedAssets.description = result.description;
          this.selectedAssets.status = result.status;
          this.selectedAssets.assetTypeId = result.assetTypeId;
          this.selectedAssets.departmentId = result.departmentId;
          this.selectedAssets.assetStatusId = result.assetStatusId;
          this.selectedAssets.vendorId = result.vendorId;
          this.selectedAssets.ownerId = result.ownerId;
          this.selectedAssets.userId = result.userId;
          this.selectedAssets.serialNumber = result.serialNumber;
          this.selectedAssets.make = result.make;
          this.selectedAssets.model = result.model;
          this.selectedAssets.processor = result.processor;
          this.selectedAssets.memory = result.memory;
          this.selectedAssets.storage = result.storage;
          this.selectedAssets.operatingSystem = result.operatingSystem;
          this.selectedAssets.ipaddress = result.ipaddress;
          this.selectedAssets.insuranceDetails = result.insuranceDetails;
          this.selectedAssets.licenceDetails = result.licenceDetails;
          this.selectedAssets.licenceExpiry = result.licenceExpiry;
          this.selectedAssets.purchaseDate = result.purchaseDate;
          this.selectedAssets.invoiceNumber = result.invoiceNumber;
          this.selectedAssets.amc = result.amc;
          this.selectedAssets.warranty = result.warranty;
          this.selectedAssets.remarks = result.remarks;
          this.selectedAssets.location = result.location;
          this.selectedAssets.toolName = result.toolName;
          this.selectedAssets.toolSerialNo = result.toolSerialNo;
          this.selectedAssets.isInternal = result.isInternal;
          this.selectedAssets.keys = result.keys;
          this.selectedAssets.toolStatus = result.toolStatus;
          this.selectedAssets.active = result.active;
        /*  this.getcategorylist();*/
          console.log('edit1', this.assetfiles)

       
          const index = this.assetfiles.findIndex(p => p.assetId === selectedAsset?.assetId);
          this.assetfiles[index] = { ...this.selectedAssets };
          console.log('updated', this.assetfiles)
          console.log('edit6', this.assetfiles)
          console.log('Hello');
        }
      });
    console.log('edit3', this.assetfiles)

  }



  deleteAssetRequest(assetId: number) {
   
      const confirmed = window.confirm('Are you sure you want to delete this asset?');
    if (confirmed) {

        this.http.post(this.baseUrl + 'AssetManagement/DeleteAssetRegister?assetid=' + assetId, null).subscribe(response => {
          console.log('Request body', response);
          this.getcategorylist();
        //  this._router.navigate(['/Asset-list']);
        

        }, error => {
          alert("Something Wrong  Please Try Again Later")
          console.log('Error', error);
        });
        console.log("id", assetId);
      }
  
  }


  getcategorylist() {
    this.http.get(this.baseUrl + 'AssetManagement/GetAssetRegister',).subscribe((data: any) => {
      this.assetfiles = data;
     
      console.log('assetfiles', data);
      this.getTableassets(data);
      this.dataSource = new MatTableDataSource<any>(this.assetTablelist);
      console.log('DataSource', this.dataSource);
  
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    
    });
  }

  getTableassets(arr: any[]) {
    
    this.assetTablelist = arr.map(asset => ({
     
      assetId:asset.assetId,
      name:asset.name,
      code:asset.code, 
      description: asset.description,
      status: asset.status,
      assetTypeId: asset.assetTypeId,
      departmentId:asset.departmentId,
      assetStatusId:asset.assetStatusId,
      vendorId:asset.vendorId,
      ownerId:asset.ownerId,
      userId:asset.userId, 
      assetType:asset.assetType, 
      department:asset.department, 
      vendor:asset.vendor, 
      owner:asset.owner,
      user:asset.user, 
      serialNumber:asset.serialNumber, 
      make:asset.make, 
      model:asset.model,  
      processor:asset.processor,
      memory: asset.memory, 
      storage:asset.storage,
      operatingSystem:asset.operatingSystem, 
      ipaddress:asset.ipaddress, 
      insuranceDetails:asset.insuranceDetails, 
      licenceDetails:asset.licenceDetails, 
      licenceExpiry:asset.licenceExpiry, 
      purchaseDate:asset.purchaseDate,
      invoiceNumber:asset.invoiceNumber, 
      amc:asset.amc,
      warranty:asset.warranty,
      remarks:asset.remarks, 
      location:asset.location,
       toolId:asset.toolId,
      toolName:asset.toolName,
      toolSerialNo:asset.toolSerialNo,
      isInternal:asset.isInternal,
      keys: asset.keys,
  toolStatus:asset.toolStatus,
     active: asset.active,

    
    }));

    console.log('new table assets', this.assetTablelist);
  }

 
  applyFilter(event: Event) {

    const filterValue = (event.target as HTMLInputElement).value;
    console.log(filterValue);
   
  }
  onFilterSubmit() {

    const SearchObject = this.myForm.value;
    console.log(this.myForm.value);
  
    this.http.get<any>(this.baseUrl + 'AssetManagement/GetAssetFilter', { params: SearchObject }).subscribe(
      (data: any) => {
  
        this.assetfiles = data;
        console.log('assetfiles', data);
        this.getTableassets(data);
        this.dataSource = new MatTableDataSource<any>(this.assetTablelist);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      }, error => {
        alert("Something Wrong  Please Try Again Later")
          console.log('Error', error);
        });

  

  }
  downloadExcel() {
    this.http.get(this.baseUrl + 'AssetManagement/DownloadAssets',).subscribe((data: any) => {
      console.log(data);

      const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(data);
      const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
      const blob = new Blob([excelBuffer], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      const url = window.URL.createObjectURL(blob);
      const link = document.createElement('a');
      link.href = url;
      link.download = 'Assetfile' + '.xlsx';
      link.click();
      window.URL.revokeObjectURL(url);
    });
  }

}



