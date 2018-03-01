import { UserService } from './services/user.service';
import { AdminAuthGuard } from './services/admin-auth-guard.service';
import * as Raven from 'raven-js';
import { ViewWeekEntryComponent } from './components/view-weekentry/view-weekentry';
import { PaginationComponent } from './components/shared/pagination.component';
import { WeekEntryFormComponent } from './components/weekentry-form/weekentry-form.component';
import { QuarterEntryFormComponent } from './components/quarterentry-form/quarterentry-form.component';
import { WeekEntryListComponent } from './components/weekentry-list/weekentry-list.component';
import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';

import { AppComponent } from './components/app/app.component';
import { AdminComponent } from './components/admin/admin.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { WeekEntryService } from './services/weekentry.service';
import { AuthService } from './services/auth.service';
import { AppErrorHandler } from './app.error-handler';
import { AuthGuard } from './services/auth-guard.service';
import { AuthHttp, AuthConfig, AUTH_PROVIDERS } from 'angular2-jwt';

Raven.config('https://4a82a6287bc049729f403390db1b1ec4@sentry.io/266502').install();

@NgModule({ 
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent, 
        WeekEntryFormComponent,
        QuarterEntryFormComponent,
        WeekEntryListComponent,
        PaginationComponent,
        ViewWeekEntryComponent,
        AdminComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ToastyModule.forRoot(),
        RouterModule.forRoot([ 
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path:'weekentries/new', component: WeekEntryFormComponent, canActivate: [ AuthGuard ] },
            { path:'quarterentries/new', component: QuarterEntryFormComponent, canActivate: [ AuthGuard ] },
            { path:'weekentries/:id', component: ViewWeekEntryComponent, canActivate: [ AuthGuard ] },
            { path: 'weekentries/edit/:id', component: WeekEntryFormComponent, canActivate: [ AuthGuard ] },
            { path:'weekentries', component: WeekEntryListComponent, canActivate: [ AuthGuard ] },
            { path: 'admin', component: AdminComponent, canActivate: [ AdminAuthGuard ] },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        WeekEntryService,
        AuthService,
        UserService,
        AuthGuard,
        AdminAuthGuard,
        AUTH_PROVIDERS
    ]
})
export class AppModuleShared {
}
