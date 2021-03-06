import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import  'rxjs/add/operator/map';
import { SaveWeekEntry } from '../models/weekentry';
import { AuthHttp } from 'angular2-jwt';

@Injectable()
export class WeekEntryService {
  private readonly weekEntryEndpoint = '/api/weekentries/';

  constructor(private http: Http, private authHttp: AuthHttp) { }

  getCategories(){
    return this.http.get('api/categories')
      .map(res => res.json());
  }

  getWeeks(){
    return this.http.get('api/weeks') 
      .map(res => res.json());
  }

  createWeek(entries: SaveWeekEntry){
    return this.authHttp.post(this.weekEntryEndpoint + 'new/week', entries)
      .map(res => res.json());
  }

  createQuarter(entries: SaveWeekEntry[]){
    return this.authHttp.post(this.weekEntryEndpoint + 'new/quarter', entries)
      .map(res => res.json());
  }

  getWeekEntry(id: any){
    return this.authHttp.get(this.weekEntryEndpoint + id)
      .map(res => res.json());
  }

  update(entry: SaveWeekEntry){
    return this.authHttp.put(this.weekEntryEndpoint + entry.id, entry)
      .map(res => res.json);
  }

  delete(id: any){
    return this.authHttp.delete(this.weekEntryEndpoint + id)
      .map(res => res.json());
  }

  getWeekEntries(filter: any){
    return this.http.get(this.weekEntryEndpoint + '?' + this.toQueryString(filter))
      .map(res => res.json()); 
  }

  toQueryString(obj: any){
    var parts = [];
    for(var prop in obj){
      var value = obj[prop];
      if(value != null && value != undefined)
        parts.push(encodeURIComponent(prop) + '=' + encodeURIComponent(value));
    }

    return parts.join('&');
  }

}
