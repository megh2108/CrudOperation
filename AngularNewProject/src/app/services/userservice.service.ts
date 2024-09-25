import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../model/ApiResponse{T}';
import { User } from '../model/user.model';
import { HttpClient } from '@angular/common/http';
import { AddUser } from '../model/addUser.model';

@Injectable({
  providedIn: 'root'
})
export class UserserviceService {

  private apiUrl = 'http://localhost:5260/api/User';

  constructor(private http: HttpClient) { }

  getAllUser(): Observable<ApiResponse<User[]>> {
    return this.http.get<ApiResponse<User[]>>(this.apiUrl + '/GetAllUsers');
  }

  getUserById(id: number | undefined): Observable<ApiResponse<User>> {
    return this.http.get<ApiResponse<User>>(this.apiUrl + '/GetUserById/' + id);
  }
  addUser(addUser: AddUser): Observable<ApiResponse<string>> {
    return this.http.post<ApiResponse<string>>(this.apiUrl + '/AddUser', addUser);
  }

  updateUser(updatedUser: User): Observable<ApiResponse<string>> {
    return this.http.put<ApiResponse<string>>(this.apiUrl + '/UpdateUser', updatedUser);
  }

  deleteUser(id: number | undefined): Observable<ApiResponse<string>> {
    return this.http.delete<ApiResponse<string>>(this.apiUrl + '/DeleteUser/' + id);
  }
}
