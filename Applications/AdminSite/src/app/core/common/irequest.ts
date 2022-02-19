import { HttpParams } from '@angular/common/http';

export abstract class IRequest {
    constructor() {

    }

    createParam(): HttpParams {
        return new HttpParams().set('request', JSON.stringify(this));
    }
}
