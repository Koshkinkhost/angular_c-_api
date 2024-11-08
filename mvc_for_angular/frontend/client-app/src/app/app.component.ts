import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UsersService } from './users.service';
import {UserResponse,User } from './user'
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'clientApp';
    users:User[] = [];
   
    constructor(private userService: UsersService) { }
    ngOnInit() {
      console.log("Инициализация");
      this.userService.getUsers().subscribe((users: User[]) => {
          this.users = users;
          console.log("Пользователи после загрузки:", this.users);
      });
  }
  
  
}
