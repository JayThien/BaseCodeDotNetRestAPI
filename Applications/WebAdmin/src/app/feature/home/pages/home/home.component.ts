import { Component, OnInit } from '@angular/core';
import { APIService } from 'src/app/core/services/api.service';
export class InbodySummarize {
  bodyFatMass: number;
  skeletalMuscleMass: number;
  weight: number;
}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  myId: number;
  inbodySummarize: InbodySummarize = new InbodySummarize();
  editHomeScreen = false;
  homeScreen: string;

  constructor(
  ) { }

  ngOnInit(): void {

  }
}
