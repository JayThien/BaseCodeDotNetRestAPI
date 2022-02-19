import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AuthService } from './feature/auth/core/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(
    private authService: AuthService
  ) {

  }
  ngOnInit(): void {
    // get version storage
    const appVersion = localStorage.getItem('appVersion');
    if (appVersion) {
      if (appVersion === environment.appVersion) {
        return;
      }
    }
    this.authService.logout();
  }
}
