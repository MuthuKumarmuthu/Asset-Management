import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssetCreateComponent } from './asset-create/asset-create.component';
import { AssetEditComponent } from './asset-edit/asset-edit.component';
import { AssetListComponent } from './asset-list/asset-list.component';
import { AuthGuard } from './auth/auth.guard';
import { SignupComponent } from './auth/users/signup/signup.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { StaffAssetListComponent } from './staff-asset-list/staff-asset-list.component';
import { UserListComponent } from './user-list/user-list.component';
import { VendorComponent } from './vendor/vendor.component';


const routes: Routes = [
  { path: '', component: LoginComponent, pathMatch: 'full', },
  { path: 'dashboard', component: DashboardComponent, pathMatch: 'full', canActivate: [AuthGuard], data: { requiredRoles: ['SADMIN','ADMIN'] } },
  { path: 'Asset-list', component: AssetListComponent, pathMatch: 'full', canActivate: [AuthGuard], data: { requiredRoles: ['ADMIN'] } },
  { path: 'Create-asset', component: AssetCreateComponent, pathMatch: 'full', canActivate: [AuthGuard], data: { requiredRoles: ['ADMIN'] }},

  { path: 'signup', component: SignupComponent, pathMatch: 'full', canActivate: [AuthGuard], data: { requiredRoles: ['SADMIN'] } },
  { path: 'edit', component: AssetEditComponent, pathMatch: 'full', canActivate: [AuthGuard], data: { requiredRoles: ['ADMIN'] } },
  { path: 'vendor', component: VendorComponent, pathMatch: 'full', canActivate: [AuthGuard], data: { requiredRoles: ['SADMIN'] } },
  { path: 'Staff-asset-list', component: StaffAssetListComponent, pathMatch: 'full', canActivate: [AuthGuard], data: { requiredRoles: ['STAFF','OWNER'] } },
  { path: 'User-list', component: UserListComponent, pathMatch: 'full', canActivate: [AuthGuard], data: { requiredRoles: ['SADMIN', 'ADMIN'] } },

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],

  exports: [RouterModule],
 
})
export class AppRoutingModule { }
