import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { PokeTrainer } from '../models/poketrainer';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth-service/auth.service';
import { PokeApiService } from '../services/poke-api-service/poke-api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  constructor(private auth:AuthService, private router : Router, private api : PokeApiService) { }
  
  username : FormControl = new FormControl('', [
    Validators.required
  ]);

  mode : string = 'login';
  modes : any = {
    login: 'Log In',
    register: 'Register'
  }
  loginFailed : boolean = false;
  registerFailed : boolean = false;
  errorMsg : string = ''
  loginHandler : Function = () => {
    this.username.markAsTouched();
    if(this.username.invalid) {
      return;
    }
    let user : PokeTrainer = {
      name : this.username.value
    };
    if(this.mode == 'login') {
      this.api.login(user).subscribe((res) => {
        if(!res) {
          this.loginFailed = true;
        }
        this.auth.setCurrentUser(res as PokeTrainer);
        this.router.navigateByUrl('/main');
      })
    }
    else {
      this.api.register(user).subscribe({next: (res) => {
        this.auth.setCurrentUser(res as PokeTrainer);
        this.router.navigateByUrl('/main');
      }, error: (err) => {
        if(err.status === 409) {
          this.registerFailed = true;
          this.errorMsg = err.error;
        }
      }})
    }
  }

  switchMode(mode : string) : void {
    this.mode = mode;
    this.username.reset();
    this.loginFailed = false;
    this.registerFailed = false;
  }

  ngOnInit(): void {
    if(this.auth.isAuthenticated())
    {
      this.router.navigate(['main']);
    }

    //more typical way of using observable
    // this.username.valueChanges.subscribe((valuechanged) => {
    //   console.log(valuechanged);
    // })
  }
}
