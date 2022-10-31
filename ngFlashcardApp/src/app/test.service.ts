import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  private apiUrl : string = "https://fcappapi.azurewebsites.net/weatherforecast";
  constructor(private http : HttpClient) { }

  getWeatherForecast() : Observable<any[]> {
    console.log('getting some weather forecasts');
    return this.http.get(this.apiUrl) as Observable<any[]>;
  }
}
