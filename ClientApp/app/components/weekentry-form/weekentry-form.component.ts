import { WeekEntryService } from './../../services/weekentry.service';
import { Component, OnInit } from '@angular/core';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-week-form',
  templateUrl: './weekentry-form.component.html',
  styleUrls: ['./weekentry-form.component.css']
})
export class WeekEntryFormComponent implements OnInit {
  categories: any = [];
  weeks: any = [];
  entry: any = {};

  constructor(
    private weekEntryService: WeekEntryService,
    private toastyService: ToastyService) { }

  ngOnInit() {
    this.weekEntryService.getCategories().subscribe(categories => 
      this.categories = categories);

    this.weekEntryService.getWeeks().subscribe(weeks =>
      this.weeks = weeks);
  }

  submit(){
    this.weekEntryService.create(this.entry)
      .subscribe(x => console.log(x));
  }

}
