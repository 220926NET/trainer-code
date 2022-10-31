import { Component, OnDestroy, OnInit } from '@angular/core';
import { TestService } from '../test.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit, OnDestroy {

  constructor(public service : TestService) {

  }

  methods() : void {
    alert('hello world!');
  }
  property : string = "name";
  customIdValue : string = "property-binding-id";
  
  data : any[] = [];

  getData() : void {
    this.service.getWeatherForecast().subscribe((data) => {
      this.data = data;
    })
  }

  // Will run once the component loads
  //really great place to do any initial data loading
  ngOnInit(): void {
    this.service.getWeatherForecast().subscribe((data) => {
      this.data = data;
    })
  }

  // Runs when the component is getting destroyed from the view
  //Very good place to do any cleanups
  ngOnDestroy() : void {

  }
}
