import { Component, OnInit } from '@angular/core';
import { AddUser } from '../../../model/addUser.model';
import { Router } from '@angular/router';
import { UserserviceService } from '../../../services/userservice.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrl: './add-user.component.css'
})
export class AddUserComponent  implements OnInit{

  user : AddUser = {
    name: '',
    age: 0,
  }

  constructor(private userService: UserserviceService, private router: Router) { }

  ngOnInit(): void {}

  onSubmit(addUserForm: NgForm): void {
    if (addUserForm.valid) {
      console.log(addUserForm.value);
      this.userService.addUser(this.user).subscribe({
        next: (response) => {
          console.log("res" + response);
          if (response.success) {
            console.log('User added successfully:', response);
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
