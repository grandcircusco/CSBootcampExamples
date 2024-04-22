import { Injectable } from '@angular/core';
import { User } from '../interfaces/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loggedInUser: User|null = {
    id: 1,
    username: "orville",
    displayName: "Orville Wright"
  }

  constructor() { }

  setLoggedInUser(newUser: User|null) {
    this.loggedInUser = newUser;
  }

  getLoggedInUser(): User|null {
    return this.loggedInUser;
  }

  getLoggedInUserId(): number|null {
    return this.loggedInUser?.id ?? null;
  }
}
