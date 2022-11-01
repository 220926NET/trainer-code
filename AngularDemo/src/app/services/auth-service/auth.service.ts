import { Injectable } from '@angular/core';
import { LocalStorageService } from 'angular-web-storage';
import { PokeTrainer } from 'src/app/models/poketrainer';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private local : LocalStorageService) { }

  public isAuthenticated() : boolean {
    if(this.local.get('currentUser')) return true;
    return false;
  }

  public getCurrentUser() : PokeTrainer {
    return this.local.get('currentUser');
  }

  public setCurrentUser(user : PokeTrainer) : void {
    if(!user) return;
    this.local.set('currentUser', user);
  }

  public clearCurrentUser() : void {
    this.local.remove('currentUser');
  }
}
