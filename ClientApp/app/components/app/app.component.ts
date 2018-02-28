import { assert } from 'chai';
import { Component } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { UserService } from '../../services/user.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {

    constructor(public auth: AuthService) {
        auth.handleAuthentication(); 
    }
}
