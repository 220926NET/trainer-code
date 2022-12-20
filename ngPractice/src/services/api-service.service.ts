import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {
  private rootUrl: string = "http://openlibrary.org/search.json?"

  private result : BehaviorSubject<any> = new BehaviorSubject<any>({});
  currentResult = this.result.asObservable();
  

  constructor(private http: HttpClient) { }

  public GetQuery(input: string) {
    return this.http.get(this.rootUrl + "q=" + input.replaceAll(' ', '+') + '&limit=5');
  }


  changeResult(result :any) {
    this.currentResult = result; 
  }


}
