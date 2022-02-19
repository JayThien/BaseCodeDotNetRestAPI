import { Component, OnInit } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzTableQueryParams } from 'ng-zorro-antd/table';
import { Area } from 'src/app/core/models/area.model';
import { COUNTRY_NAME, COUNTRY_FLAG, COUNTRIES } from 'src/app/core/models/country.model';
import { AreasRequest } from 'src/app/core/requests/areas.request';
import { AreasResponse } from 'src/app/core/responses/areas.response';
import { AreaService } from 'src/app/core/services/api/area.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { AreaDetailComponent } from '../../components/area-detail/area-detail.component';

@Component({
  selector: 'app-area',
  templateUrl: './area.component.html',
  styleUrls: ['./area.component.scss']
})
export class AreaComponent implements OnInit {
  areasResponse: AreasResponse = new AreasResponse();
  AreasRequest: AreasRequest = new AreasRequest();

  countryName = COUNTRY_NAME;
  countryFlag = COUNTRY_FLAG;
  countries = COUNTRIES;

  constructor(
    public loaderService: LoaderService,
    private areaService: AreaService,
    private modal: NzModalService
  ) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.areaService.list(this.AreasRequest).subscribe(
      result => {
        this.areasResponse = result;
      }
    );
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    this.AreasRequest.pageNumber = params.pageIndex;
    this.loadData();
  }

  edit(data: Area) {
    this.modal.create({
      nzTitle: 'Edit admin area',
      nzContent: AreaDetailComponent,
      nzComponentParams: { area: data },
      nzClosable: false,
      nzMaskClosable: false,
      nzOnOk: (result) => {
        this.areaService.update(result.form.value).subscribe(
          rs => {
            this.loadData();
          }
        );
      },
      nzOnCancel: () => {
      }
    });
  }

  addArea() {
    const newArea = new Area();
    this.modal.create({
      nzTitle: 'New admin area',
      nzContent: AreaDetailComponent,
      nzComponentParams: { area: newArea },
      nzClosable: false,
      nzMaskClosable: false,
      nzOnOk: (result) => {
        this.areaService.create(result.form.value).subscribe(
          rs => {
            this.loadData();
          }
        );
      },
      nzOnCancel: () => {
      }
    });
  }
}
