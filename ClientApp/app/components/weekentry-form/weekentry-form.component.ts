import { AuthService } from './../../services/auth.service';
import * as _ from 'underscore';
import { WeekEntry, SaveWeekEntry } from './../../models/weekentry';
import { WeekEntryService } from './../../services/weekentry.service';
import { Component, OnInit } from '@angular/core';
import { ToastyService } from 'ng2-toasty';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/Observable/forkJoin';

@Component({
  selector: 'app-week-form',
  templateUrl: './weekentry-form.component.html',
  styleUrls: ['./weekentry-form.component.css']
})
export class WeekEntryFormComponent implements OnInit {
  categories: any = [];
  weeks: any = [];
  entry: SaveWeekEntry = {
    id: 0,
    categoryId: 0,
    weekId: 0,
    mon: 0,
    tue: 0,
    wed: 0,
    thurs: 0,
    fri: 0,
    auth0Id: this.authService.getUserId()
  };

  constructor(
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router,
    private weekEntryService: WeekEntryService,
    private toastyService: ToastyService) {

    route.params.subscribe(p => {
      this.entry.id = +p['id'] || 0;
    });
  }

  ngOnInit() {
    var sources = [
      this.weekEntryService.getCategories(),
      this.weekEntryService.getWeeks(),
    ];

    if (this.entry.id)
      sources.push(this.weekEntryService.getWeekEntry(this.entry.id)); 

    Observable.forkJoin(sources).subscribe(data => {
      this.categories = data[0];
      this.weeks = data[1]; 
      if (this.entry.id) {
        this.setWeekEntry(data[2]);
      }
    }, err => {
      if (err.status == 404)
        this.router.navigate(['/home']);
    });
  }

  private setWeekEntry(e: WeekEntry) {
    this.entry.id = e.id;
    this.entry.weekId = e.week.id;
    this.entry.categoryId = e.category.id;
    this.entry.mon = e.mon;
    this.entry.tue = e.tue;
    this.entry.wed = e.wed;
    this.entry.thurs = e.thurs;
    this.entry.fri = e.fri;
    this.entry.auth0Id = this.authService.getUserId();
  }

  submit() {
    if (this.entry.id) {
      this.weekEntryService.update(this.entry)
        .subscribe(x => {
          this.toastyService.success({
            title: 'Success',
            msg: 'The Week Entry was successfully updated.',
            theme: 'bootstrap',
            timeout: 5000
          });
        });
    }
    else {
      this.weekEntryService.createWeek(this.entry)
        .subscribe(x => {
          this.toastyService.success({
            title: 'Success',
            msg: 'Successfully added a Week Entry',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          })
        });
    }
  }

  delete(){
    if(confirm("Are you sure you want to delete this entry?"))
      this.weekEntryService.delete(this.entry.id)
        .subscribe(x => {
          this.router.navigate(['/home']);
        });
  }
}
