import { Component, Input, OnInit } from '@angular/core';
import { RouterService } from 'src/app/core/services/router.service';
import { AuthService } from 'src/app/feature/auth/core/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Input() avatarURL: string;
  constructor(
    public authService: AuthService,
    public routerService: RouterService,
  ) { }

  ngOnInit(): void {
  }

  logout() {
    this.authService.logout();
  }

  detail() {
    // this.routerService.navigateToUser(this.authService._loginUser._id);
  }
}
