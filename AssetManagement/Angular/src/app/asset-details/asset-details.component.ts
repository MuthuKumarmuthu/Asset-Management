import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { assetItems, assetsdummy,  } from '../Model/Asset.Model';

@Component({
  selector: 'app-asset-details',
  templateUrl: './asset-details.component.html',
  styleUrls: ['./asset-details.component.scss']
})
export class AssetDetailsComponent implements OnInit {

  Viewassetfiles!: assetItems;
  constructor(public dialogRef: MatDialogRef<AssetDetailsComponent>,
    @Inject(MAT_DIALOG_DATA) private _matdata: any , private http: HttpClient
  ) {
  }
  baseUrl = "https://localhost:7041/";
  ngOnInit(): void {
    this.Viewassetfiles = this._matdata;
  }
  close(): void {
    this.dialogRef.close();
  }
}
