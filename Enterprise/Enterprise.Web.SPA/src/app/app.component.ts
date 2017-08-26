import { ImageModel } from './models/image-upload/image.model';
import { Router, NavigationEnd } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ProductService } from './services/product/product.service';
import 'rxjs/add/operator/filter';
import { Observable } from 'rxjs/Rx';
import { Subscription } from 'rxjs/Subscription';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  IsDashboardv3 = false;
  IsDashboardv1 = false;
  constructor(private router: Router, private service: ProductService) {
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
  VerifyImageExt(file: File) {
    if (/\.(jpe?g\png\gif)$/i.test(file.name)) {
      const reader = <FileReader>{};

      reader.addEventListener('load', () => {
        reader.readAsDataURL(file);
      })
    }
  }
  dispatch() {
    const file: HTMLInputElement = <HTMLInputElement>document.getElementById('upload');
    let filelist: ImageModel[] = [];
    let result: ImageModel[] = [];
    for (let i = 0; i < file.files.length; i++) {
      const reader = new FileReader();

      reader.readAsDataURL(file.files[i]);

      reader.onload = () => {
        filelist.push(<ImageModel>{
          productImageUrl: reader.result,
          productImageName: file.files[i].name,
          productImageSize: file.files[i].size
        });
        console.log(filelist);
        let qqq: any;
        if (i === file.files.length - 1) {
          this.service.TestConnection(filelist).subscribe(
            (res) => qqq = res,
            (err) => console.log(err),
            () => console.log(qqq)
          )
        }
      };
    }
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
