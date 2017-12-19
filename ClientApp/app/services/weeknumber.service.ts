import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import  'rxjs/add/operator/map';

@Injectable()
export class WeekNumberService {

  constructor(private http: Http) { }

  getWeeks(){
    return this.http.get('api/weeknumbers')
      .map(res => res.json());
  }

}
