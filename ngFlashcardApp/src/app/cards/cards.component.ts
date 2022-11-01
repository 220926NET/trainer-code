import { Component, OnInit } from '@angular/core';
import { FlashCard } from 'src/models/flashcard';
import { CardsAPIService } from '../cards-api.service';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {

  constructor(private cardsApi : CardsAPIService) {}
  allCards : FlashCard[] = [];
  ngOnInit() : void {
    this.getAllCards();
  }

  getAllCards() : void {
    this.cardsApi.getAllCards().subscribe((data) => {
      this.allCards = data;
    })
  }
}
