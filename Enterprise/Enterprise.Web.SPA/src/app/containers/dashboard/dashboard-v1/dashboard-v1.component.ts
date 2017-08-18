import { Component, OnInit, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
declare let $: any;
declare let Chart: any;
declare let toastr: any;
@Component({
  // tslint:disable-next-line:component-selector
  selector: 'dashboard-v1',
  templateUrl: './dashboard-v1.component.html',
  styleUrls: ['./dashboard-v1.component.css']
})
export class DashboardV1Component implements OnInit, AfterViewInit {
  @ViewChild('doughnutChart') doughnutChart: ElementRef;
  @ViewChild('polarChart') polarChart: ElementRef;
  constructor(private elRef: ElementRef) { }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
    setTimeout(function () {
      toastr.options = {
        closeButton: true,
        progressBar: true,
        showMethod: 'slideDown',
        timeOut: 4000
      };
      toastr.success('Responsive Admin Theme', 'Welcome to INSPINIA');

    }, 1300);

    const data1 = [
      [0, 4],
      [1, 8],
      [2, 5],
      [3, 10],
      [4, 4],
      [5, 16],
      [6, 5],
      [7, 11],
      [8, 6],
      [9, 11],
      [10, 30],
      [11, 10],
      [12, 13],
      [13, 4],
      [14, 3],
      [15, 3],
      [16, 6]
    ];
    const data2 = [
      [0, 1],
      [1, 0],
      [2, 2],
      [3, 0],
      [4, 1],
      [5, 3],
      [6, 1],
      [7, 5],
      [8, 2],
      [9, 3],
      [10, 2],
      [11, 1],
      [12, 0],
      [13, 2],
      [14, 8],
      [15, 0],
      [16, 0]
    ];
    // tslint:disable-next-line:no-unused-expression
    $('#flot-dashboard-chart').length && $.plot($('#flot-dashboard-chart'), [
      data1, data2
    ],
      {
        series: {
          lines: {
            show: false,
            fill: true
          },
          splines: {
            show: true,
            tension: 0.4,
            lineWidth: 1,
            fill: 0.4
          },
          points: {
            radius: 0,
            show: true
          },
          shadowSize: 2
        },
        grid: {
          hoverable: true,
          clickable: true,
          tickColor: '#d5d5d5',
          borderWidth: 1,
          color: '#d5d5d5'
        },
        colors: ['#1ab394', '#1C84C6'],
        xaxis: {
        },
        yaxis: {
          ticks: 4
        },
        tooltip: false
      }
    );

    const doughnutData = [
      {
        value: 300,
        color: '#a3e1d4',
        highlight: '#1ab394',
        label: 'App'
      },
      {
        value: 50,
        color: '#dedede',
        highlight: '#1ab394',
        label: 'Software'
      },
      {
        value: 100,
        color: '#A4CEE8',
        highlight: '#1ab394',
        label: 'Laptop'
      }
    ];

    const doughnutOptions = {
      segmentShowStroke: true,
      segmentStrokeColor: '#fff',
      segmentStrokeWidth: 2,
      percentageInnerCutout: 45, // This is 0 for Pie charts
      animationSteps: 100,
      animationEasing: 'easeOutBounce',
      animateRotate: true,
      animateScale: false
    };

    let ctx = this.doughnutChart.nativeElement.getContext('2d');
    const DoughnutChart = new Chart(ctx).Doughnut(doughnutData, doughnutOptions);

    const polarData = [
      {
        value: 300,
        color: '#a3e1d4',
        highlight: '#1ab394',
        label: 'App'
      },
      {
        value: 140,
        color: '#dedede',
        highlight: '#1ab394',
        label: 'Software'
      },
      {
        value: 200,
        color: '#A4CEE8',
        highlight: '#1ab394',
        label: 'Laptop'
      }
    ];

    const polarOptions = {
      scaleShowLabelBackdrop: true,
      scaleBackdropColor: 'rgba(255,255,255,0.75)',
      scaleBeginAtZero: true,
      scaleBackdropPaddingY: 1,
      scaleBackdropPaddingX: 1,
      scaleShowLine: true,
      segmentShowStroke: true,
      segmentStrokeColor: '#fff',
      segmentStrokeWidth: 2,
      animationSteps: 100,
      animationEasing: 'easeOutBounce',
      animateRotate: true,
      animateScale: false
    };
    ctx = this.polarChart.nativeElement.getContext('2d');
    const Polarchart = new Chart(ctx).PolarArea(polarData, polarOptions);
    $('.bar_dashboard').peity('bar', {
      fill: ['#1ab394', '#d7d7d7'],
      width: 100
    })
    const updatingChart = $('.updating-chart').peity('line', { fill: '#1ab394', stroke: '#169c81', width: 64 })

    setInterval(function () {
      const random = Math.round(Math.random() * 10)
      const values = updatingChart.text().split(',')
      values.shift()
      values.push(random)

      updatingChart
        .text(values.join(','))
        .change()
    }, 1000);
  }
}
