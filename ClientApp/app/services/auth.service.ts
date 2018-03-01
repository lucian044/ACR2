import { SaveUser } from './../models/user';
import { UserService } from './user.service';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/filter';
import * as auth0 from 'auth0-js';
import Auth0Lock from 'auth0-lock'
import { JwtHelper } from 'angular2-jwt'


@Injectable()
export class AuthService {
    options = {
        allowShowPassword: true,
        additionalSignUpFields: [
            {
                name: "firstname",
                placeholder: "FirstName"
            },
            {
                name: "lastname",
                placeholder: "LastName"
            }
        ],
        autoclose: true,
        auth: {
            audience: 'https://api.acr.com',
            params: { scope: 'openid email profile' },
            redirectUrl: 'http://localhost:5000',
            responseType: "token id_token",
        }
    }
    lock = new Auth0Lock('7NRZ8gVGhQp4OP7nOOzFW6D6uL3m7iqn', 'acrproject.auth0.com', this.options);
    profile: any;
    private roles: string[] = ["Teacher"];
    private admin: string[] = [];
    private userId: string = "";
    private user_metadata = {
        firstname: "",
        lastname: ""
    }
    private email: string = "";

    user: SaveUser = {
        id: 0,
        firstname: "",
        lastname: "",
        email: "",
        schoolid: 0,
        auth0Id: ""
    };

    constructor(public router: Router, public userService: UserService) {
        this.profile = JSON.parse(String(localStorage.getItem('profile')));
        var token = localStorage.getItem('token');
        if (token) {
            var jwtHelper = new JwtHelper();
            var decodedToken = jwtHelper.decodeToken(token);
            this.admin = decodedToken['https://acr.com/roles'];
            var isAdmin: number;
            if(this.admin.indexOf("Admin") == -1) {
                isAdmin = 0;
            }
            else {
                isAdmin = 1;
            }
            if (isAdmin){
                this.roles.push("Admin");
            }
            this.userId = decodedToken['https://acr.com/userid'];
            this.user_metadata = decodedToken['https://acr.com/userdata'];
            this.email = decodedToken['https://acr.com/email'];
        }

        this.lock.on('unrecoverable_error', console.error.bind(console));
    }

    public login(): void {
        this.lock.show();
    }

    public handleAuthentication(): void {
        // Listening for the authenticated event
        this.lock.on("authenticated", (authResult: any) => {

            const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
            localStorage.setItem('token', authResult.accessToken);
            localStorage.setItem('expires_at', expiresAt);

            var jwtHelper = new JwtHelper();
            var decodedToken = jwtHelper.decodeToken(authResult.accessToken);
            this.admin = decodedToken['https://acr.com/roles'];
            var isAdmin: number;
            if(this.admin.indexOf("Admin") == -1) {
                isAdmin = 0;
            }
            else {
                isAdmin = 1;
            }
            if (isAdmin){
                this.roles.push("Admin");
            }
            this.userId = decodedToken['https://acr.com/userid'];
            this.user_metadata = decodedToken['https://acr.com/userdata'];
            this.email = decodedToken['https://acr.com/email'];

            this.userService.getUser(this.userId).subscribe(val => {
                if (!val.id) {
                    var u: SaveUser = {
                        id: 0,
                        firstname: this.getFirstName(),
                        lastname: this.getLastName(),
                        email: this.getEmail(),
                        schoolid: 1,
                        auth0Id: this.getUserId()
                    };
                    this.userService.createUser(u).subscribe(x => x);
                }
            });

            // Use the token in authResult to getUserInfo() and save it to localStorage
            this.lock.getUserInfo(authResult.accessToken, (error: any, profile: any) => {
                if (error) {
                    throw error;
                }

                localStorage.setItem('profile', JSON.stringify(profile));
                this.profile = profile;
            });
        });
    }

    public logout(): void {
        // Remove tokens and expiry time from localStorage
        localStorage.removeItem('token');
        localStorage.removeItem('id_token');
        localStorage.removeItem('expires_at');
        localStorage.removeItem('profile');
        this.profile = null;
        this.roles = [];
        // Go back to the home route
        this.lock.logout({
            returnTo: 'http://localhost:5000/home'
        });
    }

    public isAuthenticated(): boolean {
        return new Date().getTime() < Number(localStorage.getItem('expires_at'));
    }

    public isInRole(name: any) {
        return this.roles.indexOf(name) > -1;
    }

    public getUserId() {
        return this.userId;
    }

    public getFirstName() {
        return this.user_metadata.firstname;
    }

    public getLastName() {
        return this.user_metadata.lastname;
    }

    public getEmail() {
        return this.email;
    }

    private setUser(u: any) {
        this.user.id = u.id
        this.user.firstname = u.firstName;
        this.user.lastname = u.lastName;
        this.user.email = u.email;
        this.user.schoolid = u.schoolId;
        this.user.auth0Id = u.auth0Id;
    }

}