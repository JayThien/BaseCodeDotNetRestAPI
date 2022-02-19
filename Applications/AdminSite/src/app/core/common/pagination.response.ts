export class PaginationResponse<T> {
  pageNumber!: number;
  totalRows!: number;
  data: T[] = [];
}
