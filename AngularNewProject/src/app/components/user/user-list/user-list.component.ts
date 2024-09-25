import { Component } from '@angular/core';
import { User } from '../../../model/user.model';
import { UserserviceService } from '../../../services/userservice.service';
import { Router } from '@angular/router';
import { ApiResponse } from '../../../model/ApiResponse{T}';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent {
  users: User[] | undefined;
  id: number | undefined;

  constructor(private userService: UserserviceService, private router: Router) { }


  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getAllUser().subscribe({
      next: (response: ApiResponse<User[]>) => {
        if (response.success) {
          this.users = response.data;
        }
        else {
          console.error('Falied to fetch users', response.message);
        }
      },
      error: (error => {
        console.error('Error fetching categories.', error);
      })

    })
  }

  updateUser(id: number): void {
    this.router.navigate(['/update-user', id]);
  }

  confirmDelete(id: number): void {
    if (confirm('Are you sure want to delete ?')) {
      this.id = id;
      this.deleteUser();
    }
  }

  deleteUser(): void {
    this.userService.deleteUser(this.id).subscribe({
      next: (response) => {
        if (response.success) {
          this.loadUsers();
        } else {
          alert(response.message);
        }
      },
      error: (err) => {
        alert(err.error.message);
      },
      complete: () => {
        console.log("Completed");
      }
    })
  }
}
