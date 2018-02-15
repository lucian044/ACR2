import { AuthService } from './auth.service';
import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AuthGuard } from './auth-guard.service';

@Injectable()
export class AdminAuthGuard extends AuthGuard {

    constructor(authService: AuthService) {
        super(authService);
    }

    canActivate() {
        var isAuthenticated = super.canActivate();
        if (isAuthenticated) {
            if (this.authService.isInRole('Admin')) {
                return true
            }
        }

        alert("Must be an admin to view this page");
        window.location.href = window.location + "/home";
        return false
    }
}