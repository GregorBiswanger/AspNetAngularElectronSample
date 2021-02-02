import { environment } from './../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  constructor(private httpClient: HttpClient) {}

  loadWeather() {
    console.log(environment.apiBaseUrl);
    return this.httpClient.get<Weather[]>(environment.apiBaseUrl + '/WeatherForecast').toPromise();
  }
}

export interface Weather {
	date: string;
	temperatureC: number;
	temperatureF: number;
	summary: string;
}