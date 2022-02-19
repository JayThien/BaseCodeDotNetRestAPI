import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-brief',
  templateUrl: './user-brief.component.html',
  styleUrls: ['./user-brief.component.scss']
})
export class UserBriefComponent implements OnInit {
  @Input() fullname: string | undefined;
  @Input() roleName: string | undefined;
  @Input() avatarUrl: string | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
