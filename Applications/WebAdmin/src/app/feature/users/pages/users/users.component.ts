import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NzTableQueryParams } from 'ng-zorro-antd/table';
import { FormAction } from 'src/app/core/const/form';
import { User } from 'src/app/core/models/user';
import { UsersRequest } from 'src/app/core/requests/user/users.request';
import { PaginationResponse } from 'src/app/core/responses/pagination.response';
import { APIService } from 'src/app/core/services/api.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { RouterService } from 'src/app/core/services/router.service';
import { WizardService } from 'src/app/core/services/wizard.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  usersRequest: UsersRequest = new UsersRequest();
  usersResponse: PaginationResponse<User> = new PaginationResponse<User>();

  formAction = FormAction;

  constructor(
    public loaderService: LoaderService,
    private apiService: APIService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadData();
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    if (this.loaderService.isLoading) {
      return;
    }
    this.usersRequest.pageNumber = params.pageIndex;
    this.loadData();
  }

  loadData() {
    this.apiService.getUsers(this.usersRequest).subscribe(
      result => {
        this.usersResponse = result;
      }
    );
  }

  reload() {
    this.loadData();
  }

  detail(id: number) {
    this.router.navigate(['user', id]);
  }
}
