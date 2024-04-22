import { Component } from '@angular/core';
import { User } from '../../interfaces/user';
import { UserService } from '../../services/user.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-list-of-users',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './list-of-users.component.html',
  styleUrl: './list-of-users.component.css'
})
export class ListOfUsersComponent {
  users: User[] = [];

  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe((data) => this.users = data);
  }
}
