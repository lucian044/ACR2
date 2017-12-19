import { Component, OnInit } from '@angular/core';
import { WeekEntryService } from '../../services/weekentry.service';

@Component({
  selector: 'app-week-form',
  templateUrl: './weekentry-form.component.html',
  styleUrls: ['./weekentry-form.component.css']
})
export class WeekEntryFormComponent implements OnInit {
  categories: any;
  weeks: any;

  constructor(
    private weekEntryService: WeekEntryService) { }

  ngOnInit() {
    this.weekEntryService.getCategories().subscribe(categories => 
      this.categories = categories);

    this.weekEntryService.getWeeks().subscribe(weeks =>
      this.weeks = weeks);
  }

}
