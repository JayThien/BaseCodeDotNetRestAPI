import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../core/auth.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    private authService: AuthService,
    public loaderService: LoaderService,
  ) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  signIn() {
    this.authService.login(this.loginForm.value);
  }
}
