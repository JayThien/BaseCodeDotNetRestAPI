import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { UserDropdown } from 'src/app/core/models/user-dropdown.model';
import { UserDropdownRequest } from 'src/app/core/requests/user-dropdown.request';
import { UserService } from 'src/app/core/services/api/user.api.service';

@Component({
  selector: 'app-select-user',
  templateUrl: './select-user.component.html',
  styleUrls: ['./select-user.component.scss']
})
export class SelectUserComponent implements OnInit {
  @Input() isView = true;
  @Input() value: number;
  @Input() roleName: string;
  @Input() allowClear: boolean;
  @Output() selected: EventEmitter<number> = new EventEmitter<number>();

  users: UserDropdown[] = [];
  userDropdownRequest: UserDropdownRequest = new UserDropdownRequest();
  areasStorage: string;
  selectedUser: UserDropdown;

  constructor(
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.userDropdownRequest.roleName = 'AREA_MANAGER';
    this.userService.dropdown(this.userDropdownRequest).subscribe(
      result => {
        this.users = result.data;
      }
    );
  }

}
