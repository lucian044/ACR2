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
  query: any = {};
  columns = [
    { title: 'Id' },
    { title: 'Quarter', key: 'quarter', isSortable: true },
    { title: 'Week', key: 'week', isSortable: true },
    { title: 'Category', key: 'category', isSortable: true },
    { title: 'Monday', key: 'mon', isSortable: false },
    { title: 'Tuesday', key: 'tue', isSortable: false },
    { title: 'Wednesday', key: 'wed', isSortable: false },
    { title: 'Thursday', key: 'thurs', isSortable: false },
    { title: 'Friday', key: 'fri', isSortable: false },
    {}
  ];

  constructor(private weekEntryService: WeekEntryService) { }

  ngOnInit() {
    this.weekEntryService.getWeeks()
      .subscribe(weeks => this.weeks = weeks);

      this.populateEntries();
  }

  private populateEntries() {
    this.weekEntryService.getWeekEntries(this.query)
      .subscribe(entries => this.entries = entries);
  }

  onFilterChange() {
    this.populateEntries();
  }

  resetFilter() {
    this.query = {};
    this.onFilterChange();
  }

  sortBy(columnName: any){
    if (this.query.sortBy === columnName){
      this.query.isSortAscending = !this.query.isSortAscending;
    }
    else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.populateEntries();
  }

}
