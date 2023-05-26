import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { User } from './_models/User';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'Dating App';
  users: any;
  user: any;

  constructor(private http: HttpClient, private accountService: AccountService){
  }

  ngOnInit(): void {
    this.getUsers();
    this.setCurrentUser();

    this.http.get('https://localhost:5001/api/users/1').subscribe({
      next: response => this.user = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed with userId.')
    })
  }

  getUsers() {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed.')
    })
  }
  
  setCurrentUser() {
    const userString = localStorage.getItem("user");
    if (userString) {
      const user: User = JSON.parse(userString);
      this.accountService.setCurrentUser(user);
    }
  }
  
}
