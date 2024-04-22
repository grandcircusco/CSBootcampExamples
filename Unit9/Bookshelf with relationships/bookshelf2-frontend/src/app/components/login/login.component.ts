import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../interfaces/user';
import { AuthService } from '../../services/auth.service';
import { UserService } from '../../services/user.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  message: string = "";
  username: string = "";
  password: string = "";

  demoUsers: User[] = [];

  constructor(private userService: UserService, private authService: AuthService, private router:Router) { }

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(users => {
      this.demoUsers = users;
    })
  }

  login(): void {
    if (!this.username) {
      this.message = "Username is required."
      return;
    }

    // For this demo app, we're ignoring password.
    this.userService.getUsersByUsername(this.username).subscribe(matchingUsers => {
      const matchingUser = matchingUsers[0];
      if (matchingUser) {
        this.authService.setLoggedInUser(matchingUser);
        this.router.navigateByUrl("/");
      } else {
        this.message = "No matching user found."
      }
    })
  }
}
