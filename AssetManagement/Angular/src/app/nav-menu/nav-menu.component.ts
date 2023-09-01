import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { AssetCreateComponent } from '../asset-create/asset-create.component';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {
  userName!: any;
  storedId!: any;
  role!: any;
  constructor(private dialog: MatDialog, private _router: Router, private location: Location, private authService: AuthService,) {

  
  }
 
  ngOnInit(): void {
  
    this.storedId = localStorage.getItem('membershipId');
    this.userName = localStorage.getItem('username');
    this.role = localStorage.getItem('role');
    console.log('User',this.userName);
    console.log("Role", this.role);
    console.log(this.storedId);
  }
 
  logout() {
    this.authService.logout();

    this.storedId = null;
    this._router.navigate(['/']);
 
  }
     
}
