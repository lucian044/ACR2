import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import  'rxjs/add/operator/map';
import { SaveWeekEntry } from '../models/weekentry';

@Injectable()
export class WeekEntryService {

  constructor(private http: Http) { }

  getCategories(){
    return this.http.get('api/categories')
      .map(res => res.json());
  }

  getWeeks(){
    return this.http.get('api/weeks')
      .map(res => res.json());
  }

  create(entry: SaveWeekEntry){
    return this.http.post('/api/weekentries/post', entry)
      .map(res => res.json());
  }

  getWeekEntry(id: any){
    return this.http.get('/api/weekentries/' + id)
      .map(res => res.json());
  }

  update(entry: SaveWeekEntry){
    return this.http.put('/api/weekentries/' + entry.id, entry)
      .map(res => res.json);
  }

  delete(id: any){
    return this.http.delete('/api/weekentries/' + id)
      .map(res => res.json());
  }

  getWeekEntries(){
    return this.http.get('/api/weekentries')
      .map(res => res.json());
  }

}
