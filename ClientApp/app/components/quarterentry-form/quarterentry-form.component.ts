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
  templateUrl: './quarterentry-form.component.html',
  styleUrls: ['./quarterentry-form.component.css']
})
export class QuarterEntryFormComponent implements OnInit {
  entries: SaveWeekEntry[] = [
    { id: 0, categoryId: 1, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 2, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 3, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 4, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 5, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 6, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 7, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 8, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 9, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 10, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 11, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 12, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 13, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 },
    { id: 0, categoryId: 14, weekId: 1, mon: 0, tue: 0, wed: 0, thurs: 0, fri: 0 }
  ];

  constructor(
    private router: Router,
    private weekEntryService: WeekEntryService,
    private toastyService: ToastyService) {
  }

  ngOnInit() { }

  submit() {
    for (var entry of this.entries) {
      this.weekEntryService.create(entry)
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
}
