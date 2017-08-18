import { Component, OnInit, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
declare let $: any;
declare let Chart: any;
@Component({
  selector: 'dashboard-v3',
  templateUrl: './dashboard-v3.component.html',
  styleUrls: ['./dashboard-v3.component.css']
})
export class DashboardV3Component implements OnInit, AfterViewInit {
  @ViewChild('lineChart') lineChart: ElementRef;
  constructor(private elRef: ElementRef) { }

  ngOnInit() {
  }
  ngAfterViewInit(): void {
    const lineData = {
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [
        {
          label: 'Example dataset',
          fillColor: 'rgba(220,220,220,0.5)',
          strokeColor: 'rgba(220,220,220,1)',
          pointColor: 'rgba(220,220,220,1)',
          pointStrokeColor: '#fff',
          pointHighlightFill: '#fff',
          pointHighlightStroke: 'rgba(220,220,220,1)',
          data: [65, 59, 80, 81, 56, 55, 40]
        },
        {
          label: 'Example dataset',
          fillColor: 'rgba(26,179,148,0.5)',
          strokeColor: 'rgba(26,179,148,0.7)',
          pointColor: 'rgba(26,179,148,1)',
          pointStrokeColor: '#fff',
          pointHighlightFill: '#fff',
          pointHighlightStroke: 'rgba(26,179,148,1)',
          data: [28, 48, 40, 19, 86, 27, 90]
        }
      ]
    };

    const lineOptions = {
      scaleShowGridLines: true,
      scaleGridLineColor: 'rgba(0,0,0,.05)',
      scaleGridLineWidth: 1,
      bezierCurve: true,
      bezierCurveTension: 0.4,
      pointDot: true,
      pointDotRadius: 4,
      pointDotStrokeWidth: 1,
      pointHitDetectionRadius: 20,
      datasetStroke: true,
      datasetStrokeWidth: 2,
      datasetFill: true,
      responsive: true,
    };


    const ctx = this.lineChart.nativeElement.getContext('2d');
    const myNewChart = new Chart(ctx).Line(lineData, lineOptions);
    $('.bar_dashboard').peity('bar', {
      fill: ['#1ab394', '#d7d7d7'],
      width: 100
    })
    $('.line').peity('line', {
        fill: '#1ab394',
        stroke: '#169c81',
    })

    $('.bar').peity('bar', {
        fill: ['#1ab394', '#d7d7d7']
    })
  }
}
