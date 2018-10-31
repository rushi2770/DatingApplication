import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { IValue } from './value';
// Import the map operator
import 'rxjs/add/operator/map';
@Injectable()
export class ValueService {

  constructor(private _http: HttpClient) { }

  getValues(): Observable<IValue[]> {
    return this._http.get('http://localhost:5000/api/values').map(res => <IValue[]>res);
  }

}
