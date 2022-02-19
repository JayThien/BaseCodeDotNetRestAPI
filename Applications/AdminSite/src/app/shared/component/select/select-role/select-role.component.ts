import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Dropdown } from 'src/app/core/common/dropdown.model';
import { RoleService } from 'src/app/core/service/api/role.api.service';

@Component({
  selector: 'app-select-role',
  templateUrl: './select-role.component.html',
  styleUrls: ['./select-role.component.scss']
})
export class SelectRoleComponent implements OnInit {
  @Input() isDisable = false;
  @Input() value!: number;
  @Output() valueOnChange: EventEmitter<number> = new EventEmitter<number>();

  roles: Dropdown[] = [];

  constructor(
    private roleService: RoleService
  ) { }

  ngOnInit(): void {
    this.roleService.dropdown().subscribe(
      result => {
        if (result.data) {
          this.roles = result.data;
        }
      }
    );
  }

  selected(event: any): void {
    this.valueOnChange.emit(event.value);
  }

}
