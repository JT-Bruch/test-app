import { Component, OnInit } from '@angular/core';
import { TestApiService } from './testapi.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'app';
  values = '0';
  constructor(private testService: TestApiService) { }

  ngOnInit() {
    this.testService.getHero(1).subscribe(values => this.values = values);
  }


}
