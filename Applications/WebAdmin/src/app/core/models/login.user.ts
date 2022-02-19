import { Claim } from './claim.model';
import jwt_decode from 'jwt-decode';

export class LoginUser {
  private id: number;
  private restaurant: number;
  private avatarUrl: string;
  private roles: string[] = [];
  private claims: Claim[] = [];

  resetLoginUser() {
    this.id = -1;
    this.avatarUrl = 'assets/images/default-avatar.png';
    this.roles = [];
    this.claims = [];
  }

  updateLoginUser(token: string) {
    this.resetLoginUser();
    const tokenPayload = jwt_decode(token);
    this.roles = tokenPayload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    this.id = tokenPayload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
    this.avatarUrl = tokenPayload.avatarURL;
    this.restaurant = tokenPayload.restaurant;
    // tslint:disable-next-line: no-string-literal
    if (tokenPayload['permissions']?.length > 0) {
      tokenPayload.permissions.forEach(permission => {
        this.claims.push(JSON.parse(permission));
      });
    }
  }

  public get _id(): number { return this.id; }
  public get _roles(): string[] { return this.roles; }
  public get _claims(): Claim[] { return this.claims; }
  public get _avatarURL(): string { return this.avatarUrl; }
  public get _restaurant(): number { if (this.restaurant) { return this.restaurant; } return -1; }
}
