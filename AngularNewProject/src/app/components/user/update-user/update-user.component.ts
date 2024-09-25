import { Component, OnInit } from '@angular/core';
import { User } from '../../../model/user.model';
import { UserserviceService } from '../../../services/userservice.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrl: './update-user.component.css'
})
export class UpdateUserComponent implements OnInit {
  id: number | undefined;
  user: User = {
    id: 0,
    name: '',
    age: 0,
  }

  constructor(private userService: UserserviceService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.id = params['id'];
      this.loadUserDetail(this.id);
    });
  }

  loadUserDetail(id: number | undefined): void {
    this.userService.getUserById(id).subscribe({
      next: (response) => {
        if (response.success) {
          console.log(response.data);
          this.user = response.data;
        } else {
          console.error("Falied to fetch contact", response.message);
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

  onSubmit(updateUserForm: NgForm): void {
    if (updateUserForm.valid) {
      console.log(updateUserForm.value);
      this.userService.updateUser(this.user).subscribe({
        next: (response) => {
          console.log("res" + response);
          if (response.success) {
            console.log('User updated successfully:', response);
            this.router.navigate(['/user-list']);
          } else {
            alert(response.message);
          }
        },
        error: (err) => {
          console.error(err.error.message);
          alert(err.error.message);
        },
        complete: () => {
          console.log("completed");
        }

      });
    }
  }
}
