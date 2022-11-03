import { Component } from '@angular/core';
import { FlashCard } from 'src/models/flashcard';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Output, EventEmitter } from '@angular/core';
import { CardsAPIService } from '../cards-api.service';

@Component({
  selector: 'app-add-card',
  templateUrl: './add-card.component.html',
  styleUrls: ['./add-card.component.css']
})
export class AddCardComponent {
  @Output() cardAdded = new EventEmitter<void>();
  constructor(private cardsApi : CardsAPIService) { }

  cardForm : FormGroup = new FormGroup({
    question: new FormControl('', [Validators.required]),
    answer: new FormControl('', [Validators.required])
  });

  submitForm() {
    if(this.cardForm.invalid) return;
    this.cardsApi.addCard({
      question : this.cardForm.controls['question'].value,
      answer : this.cardForm.controls['answer'].value,
      correctlyAnswered : false
    }).subscribe((res) => {
      console.log(res);
      this.cardForm.reset();
      this.cardAdded.emit();
    })
  }
}
