import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FlashCard } from 'src/models/flashcard';

@Injectable({
  providedIn: 'root'
})
export class CardsAPIService {
  // Dependency Injection
  constructor(private http : HttpClient) { }

  getAllCards() : Observable<any[]> {
    return this.http.get(environment.flashcardsAPI) as Observable<any[]>;
  }

  addCard(cardToAdd : FlashCard) : Observable<Object> {
    return this.http.post(environment.flashcardsAPI, cardToAdd);
  }
}
