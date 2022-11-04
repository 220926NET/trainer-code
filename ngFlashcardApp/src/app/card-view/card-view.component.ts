import { Component } from '@angular/core';
import { FlashCard } from 'src/models/flashcard';
import { Input } from '@angular/core';
@Component({
  selector: 'app-card-view',
  templateUrl: './card-view.component.html',
  styleUrls: ['./card-view.component.css']
})
export class CardViewComponent {

  constructor() { }
  @Input() cards : FlashCard[] = [];
  currentCardIndex : number = 2;
  showAnswer : boolean = false;

  moveCard(n : number) : void {
    this.currentCardIndex += n;
    this.showAnswer = false;
  }
}
