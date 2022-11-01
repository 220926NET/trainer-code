import { Component, OnInit } from '@angular/core';
import { CardsAPIService } from '../cards-api.service';
import { FlashCard } from 'src/models/flashcard';
import { Input } from '@angular/core';
@Component({
  selector: 'app-card-view',
  templateUrl: './card-view.component.html',
  styleUrls: ['./card-view.component.css']
})
export class CardViewComponent implements OnInit {

  constructor(private cardsApi : CardsAPIService) { }
  @Input() cards : FlashCard[] = [];
  currentCardIndex : number = 2;
  showAnswer : boolean = false;

  moveCard(n : number) : void {
    this.currentCardIndex += n;
    this.showAnswer = false;
  }
  
  ngOnInit(): void {

  }

}
