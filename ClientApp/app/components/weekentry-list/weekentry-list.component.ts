import { WeekEntry } from './../../models/weekentry';
import { WeekEntryService } from './../../services/weekentry.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-weekentry-list',
  templateUrl: './weekentry-list.component.html',
  styleUrls: ['./weekentry-list.component.css']
})
export class WeekEntryListComponent implements OnInit {
  entries: WeekEntry[];
  columns = [
    { title: 'Id' },
    { title: 'Year', key: 'year'},
    { title: 'Quarter', key: 'quarter'},
    { title: 'Week', key: 'week'},
    { title: 'Category', key: 'cat'},
    { title: 'Monday', key: 'mon'},
    { title: 'Tuesday', key: 'tue'},
    { title: 'Wednesday', key: 'wed'},
    { title: 'Thursday', key: 'thurs'},
    { title: 'Friday', key: 'fri'},
    { }
  ];

  constructor(private weekEntryService: WeekEntryService) { }

  ngOnInit() {
    this.weekEntryService.getWeekEntries()
      .subscribe(entries => this.entries = entries);
  }

}
