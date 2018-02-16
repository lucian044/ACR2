import { AuthService } from './../../services/auth.service';
import { PaginationComponent } from './../shared/pagination.component';
import { WeekEntry, Week } from './../../models/weekentry';
import { WeekEntryService } from './../../services/weekentry.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-weekentry-list',
  templateUrl: './weekentry-list.component.html',
  styleUrls: ['./weekentry-list.component.css']
})
export class WeekEntryListComponent implements OnInit {
  private readonly PAGE_SIZE = 10;

  queryResult: any = {};
  weeks: Week[] = [];
  query: any = {
    pageSize: this.PAGE_SIZE
  };
  columns = [
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

  constructor(private weekEntryService: WeekEntryService,
              private authService: AuthService) { }

  ngOnInit() {
    this.weekEntryService.getWeeks()
      .subscribe(weeks => this.weeks = weeks);

      this.populateEntries();
  }

  private populateEntries() {
    this.query.auth0Id = this.authService.getUserId();
    this.weekEntryService.getWeekEntries(this.query)
      .subscribe(result => this.queryResult = result);
  } 

  onFilterChange() {
    this.query.page = 1;
    this.populateEntries();
  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateEntries();
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

  onPageChange(page: any){
    this.query.page = page;
    this.populateEntries();
  }

}
