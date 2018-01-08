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

  constructor(private weekEntryService: WeekEntryService) { }

  ngOnInit() {
    this.weekEntryService.getWeeks()
      .subscribe(weeks => this.weeks = weeks);

      this.populateEntries();
  }

  private populateEntries() {
    this.weekEntryService.getWeekEntries(this.filter)
      .subscribe(entries => this.entries = entries);
  }

  onFilterChange() {
    this.populateEntries();
  }

  resetFilter() {
    this.filter = {};
    this.onFilterChange();
  }

}
