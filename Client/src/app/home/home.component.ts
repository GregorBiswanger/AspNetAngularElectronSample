import { Weather, WeatherService } from './../weather.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  weatherDatas: Weather[] = [];

  constructor(private weatherService: WeatherService) { }

  async loadWeather() {
    this.weatherDatas = await this.weatherService.loadWeather();
  }
}
