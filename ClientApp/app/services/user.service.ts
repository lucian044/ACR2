import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import  'rxjs/add/operator/map';
import { SaveUser } from '../models/user';
import { AuthHttp } from 'angular2-jwt';

@Injectable()
export class UserService {
  private readonly userEndPoint = '/api/users/';

  constructor(private http: Http, private authHttp: AuthHttp) { }

  createUser(entries: SaveUser){
    return this.authHttp.post(this.userEndPoint + 'new', entries)
      .map(res => res.json());
  }

  getUser(id: any){
    return this.authHttp.get(this.userEndPoint + id)
      .map(res => res.json());
  }

  deleteUser(id: any){
    return this.authHttp.delete(this.userEndPoint + id)
      .map(res => res.json());
  }

}
