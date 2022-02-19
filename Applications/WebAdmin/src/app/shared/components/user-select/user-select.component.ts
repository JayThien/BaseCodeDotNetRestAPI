import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { UserSearch } from 'src/app/core/models/user-search.model';
import { UserSearchRequest } from 'src/app/core/requests/user/user-search.request';
import { UserSystemAPIService } from 'src/app/core/services/api/user-system.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';

@Component({
  selector: 'app-user-select',
  templateUrl: './user-select.component.html',
  styleUrls: ['./user-select.component.scss']
})
export class UserSelectComponent implements OnInit {
  @Input() isMultiSelect = false;
  // tslint:disable-next-line: no-output-on-prefix
  @Output() onSelected: EventEmitter<number[]> = new EventEmitter();

  optionList: UserSearch[] = [];
  userSearch: UserSearchRequest = new UserSearchRequest();
  isLoading = false;
  isLoadFull = false;

  selectedUser = null;

  constructor(
    private userSystemAPIService: UserSystemAPIService,
    public loaderService: LoaderService
  ) { }

  ngOnInit(): void {
  }

  onSearch(value: string) {
    this.userSearch.searchTerm = value;
  }

  selected() {
    this.onSelected.emit(this.selectedUser);
  }

  search() {
    this.userSystemAPIService.getUserSearch(this.userSearch).subscribe(
      result => {
        this.optionList = result;
      }
    );
  }
}
