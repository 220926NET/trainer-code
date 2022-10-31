import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  constructor() { }

  greet() : void {
    console.log('hello');
  }

  publicProperty : string = "I'm a public property";
}
