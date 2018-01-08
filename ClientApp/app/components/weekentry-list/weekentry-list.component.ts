import { WeekEntry, Week } from './../../models/weekentry';
import { WeekEntryService } from './../../services/weekentry.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-weekentry-list',
  templateUrl: './weekentry-list.component.html',
  styleUrls: ['./weekentry-list.component.css']
})
export class WeekEntryListComponent implements OnInit {
  entries: WeekEntry[];
  allEntries: WeekEntry[];
  weeks: Week[];
  filter: any = {};
  columns = [
    { title: 'Id' },
    { title: 'Quarter', key: 'quarter' },
    { title: 'Week', key: 'week' },
    { title: 'Category', key: 'cat' },
    { title: 'Monday', key: 'mon' },
    { title: 'Tuesday', key: 'tue' },
    { title: 'Wednesday', key: 'wed' },
    { title: 'Thursday', key: 'thurs' },
    { title: 'Friday', key: 'fri' },
    {}
  ];

  constructor(private weekEntryService: WeekEntryService) {}

  ngOnInit() {
    this.weekEntryService.getWeeks()
      .subscribe(weeks => this.weeks = weeks);

    this.weekEntryService.getWeekEntries()
      .subscribe(entries => this.entries = this.allEntries = entries);
  }

  onFilterChange() {
    var entries = this.allEntries;

    if (this.filter.week)
      entries = entries.filter(e => e.week.number == this.filter.week);

    if(this.filter.quarter)
    entries = entries.filter(e => e.week.quarter == this.filter.quarter);
    
    this.entries = entries;
  }

  resetFilter(){
    this.filter = {};
    this.onFilterChange();
  }

}
