import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Dropdown } from 'src/app/core/common/dropdown.model';
import { UserDropdown } from 'src/app/core/model/user-dropdown.model';
import { UserDropdownRequest } from 'src/app/core/request/user-dropdown.request';
import { UserService } from 'src/app/core/service/api/configuration/user.api.service';
import { RoleService } from 'src/app/core/service/api/role.api.service';

@Component({
  selector: 'app-select-user',
  templateUrl: './select-user.component.html',
  styleUrls: ['./select-user.component.scss']
})
export class SelectUserComponent implements OnInit {
  @Input() isDisable = false;
  @Input() value!: number;
  @Input() title = 'User';
  @Input() roleName!: string;
  @Input() allowClear!: boolean;
  @Output() valueOnChange: EventEmitter<number> = new EventEmitter<number>();

  users: UserDropdown[] = [];
  userDropdownRequest: UserDropdownRequest = new UserDropdownRequest();

  constructor(
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.userDropdownRequest.roleName = this.roleName;
    this.userService.dropdown(this.userDropdownRequest).subscribe(
      result => {
        if (result.data.length === 0) {
          this.isDisable = true;
        } else {
          this.users = result.data;
        }
      }
    );
  }

  selected(event: any): void {
    this.valueOnChange.emit(event.value);
  }

}
