import { assert } from 'chai';
import { Component } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { UserService } from '../../services/user.service';
import { User, SaveUser } from '../../models/user';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    user: SaveUser = {
        id: 0,
        firstname: "",
        lastname: "",
        email: "",
        schoolid: 0,
        auth0Id: ""
    }
    constructor(public auth: AuthService, public userService: UserService) {
        auth.handleAuthentication(); 
    }

    

    ngOnInit() {
        if (!this.userService.getUser(this.user)) {
            this.userService.createUser(this.user);
        }
    }
}
