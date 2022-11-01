import { Component, OnDestroy, OnInit } from '@angular/core';
import { CardsAPIService } from '../cards-api.service';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit, OnDestroy {

  constructor(public service : CardsAPIService) {

  }

  methods() : void {
    alert('hello world!');
  }
  property : string = "name";
  customIdValue : string = "property-binding-id";
  
  data : any[] = [];
  currentDate : Date = new Date();
  getData() : void {
    this.service.getAllCards().subscribe((data) => {
      this.data = data;
    })
  }

  // Will run once the component loads
  //really great place to do any initial data loading
  ngOnInit(): void {
    this.service.getAllCards().subscribe((data) => {
      this.data = data;
    })
  }

  // Runs when the component is getting destroyed from the view
  //Very good place to do any cleanups
  ngOnDestroy() : void {

  }
}
