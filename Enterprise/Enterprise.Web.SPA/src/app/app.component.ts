import { Router, NavigationEnd } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  IsDashboardv3 = false;
  IsDashboardv1 = false;
  constructor(private router: Router) {
  }
  ngOnInit(): void {
    this.router.events
      .filter((event) => event instanceof NavigationEnd)
      .subscribe(
      (event) => {
        this.SetDashboard3Class(event['url'])
      }
      )
  }

  SetDashboard3Class(event: string) {
    switch (event) {
      case '/dashboard/dashboardv1':
        console.log(event);
        this.IsDashboardv3 = false;
        this.IsDashboardv1 = true;
        break;
      case '/dashboard/dashboardv3':
        console.log(event);
        this.IsDashboardv1 = false;
        this.IsDashboardv3 = true;
        console.log(this.IsDashboardv3);
        break;
      default:
        this.IsDashboardv3 = false;
        this.IsDashboardv1 = false;
        break;
    }
  }
}
