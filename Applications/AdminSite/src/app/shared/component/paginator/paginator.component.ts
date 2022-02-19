import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

export enum PaginatorSign {
  NextPage,
  PreviousPage,
  Next5Pages,
  Previous5Pages,
  PageNumber,
}

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.scss']
})
export class PaginatorComponent implements OnInit {
  @Input() pageIndex!: number;
  @Input() total!: number;
  @Input() pageSize!: number;
  @Output() pageIndexChange: EventEmitter<number> = new EventEmitter<number>();

  jumpPage!: number;

  get pageCount(): number {
    if (this.total) {
      // tslint:disable-next-line: no-bitwise
      const value = (this.total / this.pageSize) | 0;
      return (this.total % this.pageSize) === 0 ? value : value + 1;
    }
    return 0;
  }

  get pages(): { value: number, title: string, sign: PaginatorSign }[] {
    const previousPage = { value: -1, title: '<', sign: PaginatorSign.PreviousPage };
    const nextPage = { value: -1, title: '>', sign: PaginatorSign.NextPage };
    const previous5Page = { value: -1, title: '...', sign: PaginatorSign.Previous5Pages };
    const next5Page = { value: -1, title: '...', sign: PaginatorSign.Next5Pages };
    const pageCalculate: { value: number, title: string, sign: PaginatorSign }[] = [];

    if (this.pageCount < 10) {
      for (let i = 0; i < this.pageCount; i++) {
        pageCalculate.push({ value: i + 1, title: (i + 1).toString(), sign: PaginatorSign.PageNumber });
      }
    } else if (this.pageIndex < 7) {
      for (let i = 0; i < 7; i++) {
        pageCalculate.push({ value: i + 1, title: (i + 1).toString(), sign: PaginatorSign.PageNumber });
      }
      pageCalculate.push(next5Page);
      pageCalculate.push({ value: this.pageCount, title: this.pageCount.toString(), sign: PaginatorSign.PageNumber });
    } else if (this.pageIndex > this.pageCount - 7) {
      pageCalculate.push({ value: 1, title: '1', sign: PaginatorSign.PageNumber });
      pageCalculate.push(previous5Page);
      for (let i = this.pageCount - 7; i < this.pageCount; i++) {
        pageCalculate.push({ value: i + 1, title: (i + 1).toString(), sign: PaginatorSign.PageNumber });
      }
    } else {
      pageCalculate.push({ value: 1, title: '1', sign: PaginatorSign.PageNumber });
      pageCalculate.push(previous5Page);
      for (let i = this.pageIndex - 2; i < this.pageIndex + 3; i++) {
        pageCalculate.push({ value: i, title: (i).toString(), sign: PaginatorSign.PageNumber });
      }
      pageCalculate.push(next5Page);
      pageCalculate.push({ value: this.pageCount, title: this.pageCount.toString(), sign: PaginatorSign.PageNumber });
    }
    return [
      previousPage,
      ...pageCalculate,
      nextPage,
    ];
  }

  constructor() { }

  ngOnInit(): void {
  }

  isDisable(page: { value: number, title: string, sign: PaginatorSign }): boolean {
    return (page.sign === PaginatorSign.PreviousPage && this.pageIndex === 1)
      || (page.sign === PaginatorSign.NextPage && this.pageIndex === this.pageCount);
  }

  selected(page: { value: number, title: string, sign: PaginatorSign }): void {
    if (page.value === this.pageIndex) {
      return;
    }
    switch (page.sign) {
      case PaginatorSign.PageNumber:
        this.pageIndex = page.value;
        break;
      case PaginatorSign.PreviousPage:
        this.pageIndex--;
        break;
      case PaginatorSign.NextPage:
        this.pageIndex++;
        break;
      case PaginatorSign.Previous5Pages:
        this.pageIndex -= 5;
        break;
      case PaginatorSign.Next5Pages:
        this.pageIndex += 5;
        break;
      default:
        break;
    }
    this.pageIndexChange.emit(this.pageIndex);
  }

  jumpTo(): void {
    if (this.jumpPage < 1 || this.jumpPage > this.pageCount || this.jumpPage === this.pageIndex) {
      return;
    }
    this.pageIndex = this.jumpPage;
    this.pageIndexChange.emit(this.pageIndex);
  }
}
