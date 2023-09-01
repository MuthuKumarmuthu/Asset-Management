import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { assetItems, assetsdummy, } from '../Model/Asset.Model';


@Component({
  selector: 'app-staff-asset-details',
  templateUrl: './staff-asset-details.component.html',
  styleUrls: ['./staff-asset-details.component.scss']
})
export class StaffAssetDetailsComponent implements OnInit {

  Viewassetfiles!: assetItems;
  constructor(public dialogRef: MatDialogRef<StaffAssetDetailsComponent>,
    @Inject(MAT_DIALOG_DATA) private _matdata: any, private http: HttpClient
  ) {
  }
  baseUrl = "https://localhost:7041/";

  ngOnInit(): void {
    this.Viewassetfiles = this._matdata;
    console.log('sented data', this.Viewassetfiles)
  }
  close(): void {
    this.dialogRef.close();
  }

}
