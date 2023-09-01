import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatIconModule } from '@angular/material/icon'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DashboardComponent } from './dashboard/dashboard.component';
//import { AssetListComponent } from 'src/app/asset-list/asset-list.component';
import { AssetListComponent } from './asset-list/asset-list.component';
import { AssetEditComponent } from './asset-edit/asset-edit.component';
import { AssetCreateComponent } from './asset-create/asset-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTableModule } from '@angular/material/table';
import { FormsModule } from '@angular/forms';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HttpClientModule ,HTTP_INTERCEPTORS} from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { SignupComponent } from './auth/users/signup/signup.component';
import { AssetDetailsComponent } from './asset-details/asset-details.component';
import { VendorComponent } from './vendor/vendor.component';
import { StaffAssetListComponent } from './staff-asset-list/staff-asset-list.component';
import { StaffAssetDetailsComponent } from './staff-asset-details/staff-asset-details.component';
import { UserListComponent } from './user-list/user-list.component';
import { TokenInterceptor } from './Interceptor/token.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    AssetListComponent,
    AssetEditComponent,
    AssetCreateComponent,
    NavMenuComponent,
    LoginComponent,
    SignupComponent,
    AssetDetailsComponent,
    VendorComponent,
    StaffAssetListComponent,
    StaffAssetDetailsComponent,
    UserListComponent
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatDividerModule,
    MatProgressBarModule,
    MatTableModule,
    FormsModule,
    MatIconModule,
    HttpClientModule,
    MatPaginatorModule,
    MatSortModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi:true
  } ],
  bootstrap: [AppComponent]
})
export class AppModule { }
