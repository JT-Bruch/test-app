import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable()
export class CommonApiService {

  constructor() { }

  get dotnetServerUrl(): string {
    return environment.dotnetServerUrl;
  }

}
