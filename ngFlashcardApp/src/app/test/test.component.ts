import { Component, OnInit } from '@angular/core';
import { TestService } from '../test.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  constructor(public service : TestService) {

  }

  ngOnInit(): void {

  }
  methods() : void {
    alert('hello world!');
    this.service.greet();
  }
  property : string = "name";
  customIdValue : string = "property-binding-id";
}
