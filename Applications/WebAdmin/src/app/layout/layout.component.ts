import { Component, OnInit } from '@angular/core';
import { LoaderService } from 'src/app/core/services/loader.service';
import { environment } from 'src/environments/environment';
import { AuthService } from '../feature/auth/core/auth.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  isCollapsed = false;
  isLogin = false;
  avatar: string;

  constructor(
    public authService: AuthService,
    public loaderService: LoaderService,
  ) {
  }

  ngOnInit(): void {
    this.avatar = this.authService._loginUser._avatarURL;
  }

}
