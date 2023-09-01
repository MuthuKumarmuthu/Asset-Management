import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { assetItems, AssetTypeList, DepartmentList, VendorList, OwnerList, UserList, Drop } from '../Model/Asset.Model';


@Component({
  selector: 'app-asset-create',
  templateUrl: './asset-create.component.html',
  styleUrls: ['./asset-create.component.scss'],
   
})
export class AssetCreateComponent implements OnInit {
  assetTypeList!: AssetTypeList[];
  departmentList!: DepartmentList[];
  vendorlist!: VendorList[];
  ownerList!: OwnerList[];
  userList!: UserList[];
  assetForm!: FormGroup;
  assetItems!: assetItems;
  Memberid!: number;
  storedId!: number;

  baseUrl = "https://localhost:7041/";
  constructor(private formBuilder: FormBuilder, private router: Router, private http: HttpClient, /*public dialogRef: MatDialogRef<AssetCreateComponent>*/) {
 
  }

  ngOnInit(): void {
   
    this.onDropDownList();
    this.assetForm = this.formBuilder.group({     
    name: ['', Validators.required],
    code: ['', Validators.required],
    description: [''],
    status:[null],
    assetTypeId: ['', Validators.required],
    departmentId: [''],
  //  assetStatusId: ['', Validators.required],
    vendorId: [''],
    ownerId: [''],
    userId: [''],
    serialNumber: [''],
    make: [''],
    model: [''],
    processor: [''],
    memory: [''],
    storage: [''],
    operatingSystem: [''],
    ipaddress: [''],
    insuranceDetails: [''],
    licenceDetails: [''],
    licenceExpiry: [null],
    purchaseDate: [null],
    invoiceNumber: [''],
    amc: [''],
    warranty: [''],
    remarks: [''],
    location: [''],
    toolName: [''],
    isInternal: [false],
    toolSerialNo: [''],
    keys: [''],
    toolStatus: [null],
    active: [null],
    });

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
  onSubmit() {
    const updateasset = new assetItems();
    updateasset.name = this.assetForm.get('name')?.value;
    updateasset.code = this.assetForm.get('code')?.value;
    updateasset.description = this.assetForm.get('description')?.value;
    updateasset.status = this.assetForm.get('status')?.value;
    updateasset.assetTypeId = this.assetForm.get('assetTypeId')?.value;
    updateasset.departmentId = this.assetForm.get('departmentId')?.value;
    // updateasset.assetStatusId = this.assetForm.get('assetStatusId')?.value;
    updateasset.vendorId = this.assetForm.get('vendorId')?.value;
    updateasset.ownerId = this.assetForm.get('ownerId')?.value;
    updateasset.userId = this.assetForm.get('userId')?.value;
    updateasset.serialNumber = this.assetForm.get('serialNumber')?.value;
    updateasset.make = this.assetForm.get('make')?.value;
    updateasset.model = this.assetForm.get('model')?.value;
    updateasset.processor = this.assetForm.get('processor')?.value;
    updateasset.memory = this.assetForm.get('memory')?.value;
    updateasset.storage = this.assetForm.get('storage')?.value;
    updateasset.operatingSystem = this.assetForm.get('operatingSystem')?.value;
    updateasset.ipaddress = this.assetForm.get('ipaddress')?.value;
    updateasset.insuranceDetails = this.assetForm.get('insuranceDetails')?.value;
    updateasset.licenceDetails = this.assetForm.get('licenceDetails')?.value;
    updateasset.licenceExpiry = this.assetForm.get('licenceExpiry')?.value;
    updateasset.purchaseDate = this.assetForm.get('purchaseDate')?.value;
    updateasset.invoiceNumber = this.assetForm.get('invoiceNumber')?.value;
    updateasset.amc = this.assetForm.get('amc')?.value;
    updateasset.warranty = this.assetForm.get('warranty')?.value;
    updateasset.remarks = this.assetForm.get('remarks')?.value;
    updateasset.toolName = this.assetForm.get('toolName')?.value;
    updateasset.toolSerialNo = this.assetForm.get('toolSerialNo')?.value;
    updateasset.isInternal = this.assetForm.get('isInternal')?.value;
    updateasset.keys = this.assetForm.get('keys')?.value;
    updateasset.toolStatus = this.assetForm.get('toolStatus')?.value;
    updateasset.active = this.assetForm.get('active')?.value;
    updateasset.location = this.assetForm.get('location')?.value;


    const apiUrl = this.baseUrl + 'AssetManagement/CreateAssetRegister';
    Object.keys(this.assetForm.controls).forEach(field => {
      const control = this.assetForm.get(field);
      if (control instanceof FormControl) {
    
        if (control.invalid) {
          control.markAsTouched();
        }
      }
    });
 
    if (this.assetForm.valid) {
      this.http.post(this.baseUrl + 'AssetManagement/CreateAssetRegister', updateasset).subscribe(response => {
       
        this.router.navigate(['/Asset-list']);
       
      }, error => {
        alert("Something Wrong  Please Try Again Later")
        console.log('Error', error);
        console.log('Error response', error.error);
      });
    }
  }
}
