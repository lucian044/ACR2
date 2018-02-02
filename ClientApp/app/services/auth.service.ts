import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/filter';
import * as auth0 from 'auth0-js';
import Auth0Lock from 'auth0-lock'


@Injectable() 
export class AuthService {
    options = {
        allowShowPassword: true,
        autoclose: true,
        auth: {
            audience: 'https://api.acr.com',
            params: { scope: 'openid email' },
            redirectUrl: 'http://localhost:5000/weekentries',
            responseType: "token id_token",
        }
    }
    lock = new Auth0Lock('7NRZ8gVGhQp4OP7nOOzFW6D6uL3m7iqn', 'acrproject.auth0.com', this.options);
    profile: any;

    constructor(public router: Router) {
        this.profile = JSON.parse(String(localStorage.getItem('profile')));
        this.lock.on('unrecoverable_error', console.error.bind(console));
    }

    public login(): void {
        this.lock.show();
    }

    public handleAuthentication(): void {
        // Listening for the authenticated event
        this.lock.on("authenticated", (authResult: any) => {
            // Use the token in authResult to getUserInfo() and save it to localStorage
            this.lock.getUserInfo(authResult.accessToken, function (error: any, profile: any) {
                if (error) {
                    throw error;
                }
                const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
                localStorage.setItem('access_token', authResult.accessToken);
                localStorage.setItem('expires_at', expiresAt);
                localStorage.setItem('profile', JSON.stringify(profile));
            });
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
        this.lock.logout({
            returnTo: 'http://localhost:5000/weekentries'
        });
    }

    public isAuthenticated(): boolean {
        return new Date().getTime() < Number(localStorage.getItem('expires_at'));
    }

 }