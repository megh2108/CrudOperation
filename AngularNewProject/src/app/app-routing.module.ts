import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { UserListComponent } from './components/user/user-list/user-list.component';
import { UpdateUserComponent } from './components/user/update-user/update-user.component';
import { AddUserComponent } from './components/user/add-user/add-user.component';

const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path:'home', component: HomeComponent},
  {path:'user-list', component: UserListComponent},
  {path:'add-user',component:AddUserComponent},
  {path:'update-user/:id',component:UpdateUserComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
