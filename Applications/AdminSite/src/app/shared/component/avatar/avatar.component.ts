import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-avatar',
  templateUrl: './avatar.component.html',
  styleUrls: ['./avatar.component.scss']
})
export class AvatarComponent implements OnInit {
  @Input() avatarUrl: string | undefined;
  @Input() size: string | undefined;

  get width(): number {
    switch (this.size) {
      case 'xsmall':
        return 24;
      case 'large':
        return 72;
      case 'small':
        return 46;
      case 'xlarge':
        return 92;
      default:
        return 64;
    }
  }

  get url(): string {
    if (this.avatarUrl) {
      return this.avatarUrl;
    }
    return 'assets/images/common/profile.jpg';
  }
  constructor() { }

  ngOnInit(): void {
  }

}
