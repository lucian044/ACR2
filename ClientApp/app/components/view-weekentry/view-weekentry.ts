import { AuthService } from './../../services/auth.service';
import { ToastyService } from 'ng2-toasty';
import { WeekEntryService } from './../../services/weekentry.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: 'view-weekentry.html'
})
export class ViewWeekEntryComponent implements OnInit {
  entry: any;
  entryId: any; 

  constructor(
    private authService: AuthService,
    private route: ActivatedRoute, 
    private router: Router,
    private toasty: ToastyService,
    private weekEntryService: WeekEntryService) { 

    route.params.subscribe(p => {
      this.entryId = +p['id'];
      if (isNaN(this.entryId) || this.entryId <= 0) {
        router.navigate(['/weekentries']);
        return; 
      }
    });
  }
 
  ngOnInit() { 
    this.weekEntryService.getWeekEntry(this.entryId)
      .subscribe(
        e => this.entry = e,
        err => {
          if (err.status == 404) {
            this.router.navigate(['/weekentries']);
            return; 
          }
        });
  }

  delete() {
    if (confirm("Are you sure?")) {
      this.weekEntryService.delete(this.entry.id)
        .subscribe(x => {
          this.router.navigate(['/weekentries']);
        });
    }
  }
}