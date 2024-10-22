import { Component, inject, OnInit } from '@angular/core';
import { RegisterComponent } from "../register/register.component";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
canelRegisterMode($event: boolean) {
    this.registermode = $event;
}
  ngOnInit(): void {
    this.getUsers()
  }
  registermode = false;
  users: any;
  http = inject(HttpClient);
  registerToggle(){
    this.registermode = !this.registermode;
  }
  getUsers(){
    this.http.get('https://localhost:5001/api/Users').subscribe({
      next: (Response) => (this.users = Response),
      error: (error) => console.log(error),
      complete: () => console.log('completed'),
    });

  }
}

