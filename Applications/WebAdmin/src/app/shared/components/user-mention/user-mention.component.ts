import { Component, Input, OnInit, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { MentionOnSearchTypes } from 'ng-zorro-antd/mention';
import { UserMentionRequest } from 'src/app/core/requests/user/user-mention.request';
import { UserSystemAPIService } from 'src/app/core/services/api/user-system.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { SharedUser } from '../../models/shared-user.model';

@Component({
  selector: 'app-user-mention',
  templateUrl: './user-mention.component.html',
  styleUrls: ['./user-mention.component.scss']
})
export class UserMentionComponent implements OnInit, OnChanges {
  @Input() inputValue = '';
  @Output() inputValueChange: EventEmitter<string> = new EventEmitter<string>();

  @Input() mentioned: SharedUser[] = [];
  @Output() mentionedChange: EventEmitter<SharedUser[]> = new EventEmitter<SharedUser[]>();

  @Input() isMultiRow = false;

  suggestions: any[] = [];
  userMentionRequest: UserMentionRequest = new UserMentionRequest();

  constructor(
    private userSystemAPIService: UserSystemAPIService,
    public loaderService: LoaderService,
  ) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.mentioned?.currentValue) {
      if (this.inputValue === undefined) { this.inputValue = ''; }
      this.mentioned.forEach(p => {
        this.inputValue += '@' + p.fullname + ' ';
      });
    }
  }

  ngOnInit(): void {

  }

  valueWith = (data: { id: number, fullname: string; avatarURL: string }) => data.fullname;

  onSearchChange({ value }: MentionOnSearchTypes): void {
    if (value === ''
      || (this.suggestions.length > 0 && value.length > 0)
      || this.loaderService.isLoading
    ) {
      return;
    }
    this.userMentionRequest.fullname = value;
    this.userSystemAPIService.getMentionUser(this.userMentionRequest).subscribe(
      result => {
        this.suggestions = result;
      }
    );
  }

  onSelectedMention(event: SharedUser) {
    if (!this.mentioned.map(p => p.id).includes(event.id)) {
      this.mentioned.push({ id: event.id, fullname: event.fullname });
      this.mentionedChange.emit(this.mentioned);
    }
  }

  onChange(event: string) {
    this.mentioned.forEach(
      (e, index) => {
        if (!this.inputValue.includes(e.fullname)) {
          this.mentioned.splice(index, 1);
          this.buildMentionName();
        }
      }
    );
  }

  private buildMentionName() {
    this.inputValue = '';
    this.mentioned.forEach(e => {
      this.inputValue += '@' + e.fullname + ' ';
    });
  }
}

