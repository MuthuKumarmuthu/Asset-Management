import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { User } from '../Model/user.model';

@Injectable({ 
  providedIn: 'root'
})
export class AuthService {
  baseUrl = "https://localhost:7041/Login/AccessLogin";
  Url = "https://localhost:7041";
  private currentUser!: User; 
  constructor(private http: HttpClient) { }
 
 

  logout(): any {

    const member = localStorage.getItem('membershipId');
    const membershipId = member ? parseInt(member, 10) : 0;
    console.log(membershipId);

  /*  var membershipId = localStorage.getItem('membershipId');*/
    this.http.post(this.Url + '/Login/LogOutDetails?membershipId='+membershipId,null).subscribe(response => {
   
      console.log("Message");
      console.log('Request body', response);
      localStorage.removeItem('membershipId');
      localStorage.removeItem('username');
      localStorage.removeItem('role');
      localStorage.removeItem('isLockedOut');
     
    }, error => {
      console.log('Error', error);
      console.log('edit', membershipId);

    });

   

  }

  isLoggedIn(): boolean {

    return !!localStorage.getItem('membershipId');
 
  }
  hasRequiredRole(requiredRoles: string[]): boolean {

    var userRole = localStorage.getItem('role');
    return requiredRoles.includes(userRole!);
  


  }

  getUserRole(): string {
    var roleId = localStorage.getItem('role');
    return roleId!;
  }
  login(login: any) {
    return this.http.post<any>(this.baseUrl, login);
  }

}
interface MyResponse {

  membershipId: number;
  userName: string;
  role?: string;
}
