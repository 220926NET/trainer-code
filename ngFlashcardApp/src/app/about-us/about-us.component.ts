import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent implements OnInit {

  constructor(private currentRoute : ActivatedRoute) { }

  ngOnInit(): void {

    this.currentRoute.url.subscribe((url) => {
      console.log(url);
    })
  }
}