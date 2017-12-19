import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { WeekNumberService } from '../../services/weeknumber.service';

@Component({
  selector: 'app-week-form',
  templateUrl: './weekentry-form.component.html',
  styleUrls: ['./weekentry-form.component.css']
})
export class WeekEntryFormComponent implements OnInit {
  categories: any;
  weeknumbers: any;

  constructor(private categoryService: CategoryService, private weekService: WeekNumberService) { }

  ngOnInit() {
    this.categoryService.getCategories().subscribe(categories => {
      this.categories = categories;
    console.log("CATEGORIES", this.categories);
    });

    this.weekService.getWeeks().subscribe(weeknumbers => {
      this.weeknumbers = weeknumbers;
    console.log("WEEKS", this.weeknumbers);
    });
  }

}
