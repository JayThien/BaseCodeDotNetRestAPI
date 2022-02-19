import { IFilterRequest } from '../ifilter.request';
import { ILoadingRequest } from '../loading.request';

export class UserOverviewRequest implements IFilterRequest, ILoadingRequest {
  skip = 0;
  take = 10;
  getLoadingKey(): string {
    return 'UserOverviewRequest';
  }
}
