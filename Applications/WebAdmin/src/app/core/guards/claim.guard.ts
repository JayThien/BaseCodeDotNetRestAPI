import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from 'src/app/feature/auth/core/auth.service';

@Injectable({ providedIn: 'root' })
export class ClaimGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
  // Get property name on security object to check
  const claimName: string = route.data.claimName;

  if (this.authService.hasClaim(claimName)) {
    return true;
  }
  else {
    this.router.navigate(['error-page']);
    return false;
  }
  }
}
