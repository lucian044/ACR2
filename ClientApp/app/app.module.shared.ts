import { PaginationComponent } from './components/shared/pagination.component';
import * as Raven from 'raven-js';
import { WeekEntryFormComponent } from './components/weekentry-form/weekentry-form.component';
import { WeekEntryListComponent } from './components/weekentry-list/weekentry-list.component';
import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { WeekEntryService } from './services/weekentry.service';
import { AppErrorHandler } from './app.error-handler';

Raven.config('https://4a82a6287bc049729f403390db1b1ec4@sentry.io/266502').install();

@NgModule({ 
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        WeekEntryFormComponent,
        WeekEntryListComponent,
        PaginationComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'weekentries', pathMatch: 'full' },
            { path:'weekentries/new', component: WeekEntryFormComponent },
            { path:'weekentries/:id', component: WeekEntryFormComponent },
            { path:'weekentries', component: WeekEntryListComponent },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        WeekEntryService
    ]
})
export class AppModuleShared {
}
