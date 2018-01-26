import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/filter';
import * as auth0 from 'auth0-js';
import Auth0Lock from 'auth0-lock'


@Injectable()
export class AuthService {
    lock = new Auth0Lock(
        '7NRZ8gVGhQp4OP7nOOzFW6D6uL3m7iqn',
        'acrproject.auth0.com'
    );
    profile: any;

    auth0 = new auth0.WebAuth({
        clientID: '7NRZ8gVGhQp4OP7nOOzFW6D6uL3m7iqn',
        domain: 'acrproject.auth0.com',
        responseType: 'token id_token',
        audience: 'https://api.acr.com',
        redirectUri: 'http://localhost:5000/weekentries',
        scope: 'openid email'
    });

    constructor(public router: Router) {
        this.profile = JSON.parse(String(localStorage.getItem('profile')));
    }

    public login(): void {
        this.auth0.authorize();
    }

    public handleAuthentication(): void {
        this.auth0.parseHash((err, authResult) => {
            console.log("authResult", authResult);
            if (authResult && authResult.accessToken && authResult.idToken) {
                console.log("In handle");
                window.location.hash = '';
                this.setSession(authResult);
                this.router.navigate(['/weekentries']);
            } else if (err) {
                this.router.navigate(['/home']);
                console.log(err);
            }
        });
    }

    private setSession(authResult: any): void {
        // Set the time that the access token will expire at
        console.log("in set")
        const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
        localStorage.setItem('access_token', authResult.accessToken);
        localStorage.setItem('id_token', authResult.idToken);
        localStorage.setItem('expires_at', expiresAt);
        this.lock.getUserInfo(authResult.accessToken, (error, profile) => {
            if (error)
                throw error;
            localStorage.setItem('profile', JSON.stringify(profile));
            this.profile = profile;
        });

    }

    public logout(): void {
        // Remove tokens and expiry time from localStorage
        localStorage.removeItem('access_token');
        localStorage.removeItem('id_token');
        localStorage.removeItem('expires_at');
        localStorage.removeItem('profile');
        this.profile = null;
        // Go back to the home route
        this.router.navigate(['/']);
    }

    public isAuthenticated(): boolean {
        // Check whether the current time is past the
        // access token's expiry time
        // var exp = localStorage.getItem('expires_at');
        // if (exp == null)
        //     exp = "";
        // const expiresAt = JSON.parse(exp);
        return new Date().getTime() < Number(localStorage.getItem('expires_at'));
    }

}