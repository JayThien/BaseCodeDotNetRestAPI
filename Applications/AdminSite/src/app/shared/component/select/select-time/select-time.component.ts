import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UserDropdown } from 'src/app/core/model/user-dropdown.model';
import { UserDropdownRequest } from 'src/app/core/request/user-dropdown.request';

@Component({
  selector: 'app-select-time',
  templateUrl: './select-time.component.html',
  styleUrls: ['./select-time.component.scss']
})
export class SelectTimeComponent implements OnInit {
  @Input() isDisable = false;
  @Input() value!: string;
  @Input() title = 'Time';
  @Output() valueOnChange: EventEmitter<string> = new EventEmitter<string>();

  users: UserDropdown[] = [];
  userDropdownRequest: UserDropdownRequest = new UserDropdownRequest();

  hours = Array.from({ length: 24 }, (_, i) => i < 10 ? `0${i}` : `${i}`);
  minutes = ['00', '30'];

  get datas(): string[] {
    const result: string[] = [];
    this.hours.forEach(hour => {
      result.push(`${hour}:00`);
      result.push(`${hour}:30`);
    });
    return result;
  }
  constructor(
  ) { }

  ngOnInit(): void {

  }

  selected(event: any): void {
    this.valueOnChange.emit(event.value);
  }

}
