import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ApiServiceService } from '../../services/api-service.service'
import { Observable } from 'rxjs';

@Component({
  selector: 'app-searchbar',
  templateUrl: './searchbar.component.html',
  styleUrls: ['./searchbar.component.css']
})
export class SearchbarComponent implements OnInit {

  constructor(private apiService: ApiServiceService) { }

  @Input()  searchText: string = "";
  @Output() searchTextChange = new EventEmitter<string>();

  searchSubmit(e:HTMLInputElement) {
    console.log(e.value);
    this.apiService.GetQuery(e.value).subscribe((res)=> {
        this.apiService.changeResult(res); 
        this.result = (res as any).docs;
    });
  }

  result: any[] = [];

  ngOnInit(): void {
    
    this.apiService.GetQuery("the lord of the rings").subscribe((res)=> {
        this.apiService.changeResult(res); 
        this.result = (res as any).docs;
    });
    
  }

}
