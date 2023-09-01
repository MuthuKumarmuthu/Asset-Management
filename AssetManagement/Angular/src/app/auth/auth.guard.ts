
import { Injectable } from '@angular/core';
  import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
  import { Observable } from 'rxjs';
  import { AuthService } from './auth.service';


@Injectable({
  providedIn: 'root'
})

  export  class AuthGuard implements CanActivate {
    
    constructor(private authService: AuthService, private router: Router) { }


    canActivate(
      route: ActivatedRouteSnapshot,
      state: RouterStateSnapshot
    ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    
      if (this.authService.isLoggedIn() && this.authService.hasRequiredRole(route.data['requiredRoles'])) {
       
        return true;
      }

      else {
        if (this.authService.isLoggedIn() == false) {
          alert("Please Login");
          this.router.navigate(['/']);
          return false;
        }
        alert("You Don't Have Access");
      
        return false;
      }
    }

  }
