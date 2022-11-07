import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth-service/auth.service';
import { PokeTrainer } from '../models/poketrainer';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private auth: AuthService, private router:Router) { }

  currentUser : PokeTrainer = {
    name : ''
  };
  logout() {
    this.auth.clearCurrentUser();
    this.router.navigate(['login']);
  }
  ngOnInit(): void {
    this.currentUser = this.auth.getCurrentUser();
  }

}
