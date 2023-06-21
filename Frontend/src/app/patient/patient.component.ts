import { Component, OnInit, Inject, ViewChild, ElementRef } from '@angular/core';
import { PatientService } from './../patient/patient.service';
import { PageEvent } from '@angular/material/paginator';
import * as Highcharts from 'highcharts'   

import HighchartsMore from 'highcharts/highcharts-more';
import HighchartsExporting from 'highcharts/modules/exporting';
import HighchartsData from 'highcharts/modules/data';

HighchartsMore(Highcharts);
HighchartsExporting(Highcharts);
HighchartsData(Highcharts);

@Component({
  selector: 'app-patient', 
  templateUrl: './../patient/patient.component.html',
  styleUrls: ['./../patient/patient.component.css']
})

export class PatientComponent implements OnInit {
  title = 'CloudBeat';

  displayedColumns: string[] = ['id', 'name', 'dateOfBirth', 'studyStartTime', 'studyEndTime', 'deviceSerialNumber', 'totalNumberOfEvents'];

  dataSource: any;

  currentPage = 1;
  totalPages = 0;
  pageSize = 20;
  pages: number[] = [];

  constructor(private service: PatientService) {
  }

  ngOnInit(): void {
    this.GetPatientsDetails();
  }
  GetPatientsDetails() {
    this.service.GetPatientsDetails( this.currentPage).subscribe((result: any) => {
      this.dataSource = result;
    });
  }

  onRowClick(row:any){
    this.service.GetPatientEventsSummary(row.id).subscribe((result:any)=>{

      const eventDetails = result.eventDetails;
      const numEvents = eventDetails.length;
  
      const dates: string[] = new Array<string>(numEvents);
      const bpmValues: number[] = new Array<number>(numEvents);
  
      for (let i = 0; i < numEvents; i++) {
        dates[i] = eventDetails[i].date; 
        bpmValues[i] = eventDetails[i].bpm;
      }

      this.generateChart(dates,bpmValues);

    });
  }

  generateChart(dates: string[],bpmValues: number[]) {
Highcharts.chart('chartContainer',{
  chart: {
    type: 'line'
  },
  title: {
    text: 'BPM Values'
  },
  xAxis: {
    categories: dates
  },
  yAxis: {
    title: {
      text: 'BPM'
    }
  },
  series: [{
    name: 'BPM',
    data: bpmValues 
  }] as Highcharts.SeriesOptionsType[],
  tooltip: {
    shared: true,
    valueSuffix: ' BPM'
  },
  plotOptions: {
    series: {
      point: {
        events: {
          mouseOver: this.displaySummary.bind(this)
        }
      }
    }
  }

  // tooltip: {
  //   shared: true,
  //   valueSuffix: ' BPM',
  //   formatter: function () {
  //     let tooltip = `<b>${this.x}</b><br/>`;
  //     tooltip += `<b>Patient:</b> Rami<br/>`;
  //     tooltip += `<b>Min:</b> 90<br/>`;
  //     tooltip += `<b>Max:</b> 200<br/>`;
  //     tooltip += `<b>Average:</b> 130<br/>`;
  //     tooltip += `BPM: ${this.y}`;
  //     return tooltip;
  //   }
  // }
});
  }

  displaySummary() {
    // const min = Math.min(...this.bpmData);
    // const max = Math.max(...this.bpmData);
    // const average = Math.round(this.bpmData.reduce((sum, value) => sum + value, 0) / this.bpmData.length);

    // const summary = `Patient:Rami<br>`;
    // summary += `Min: 90<br>`;
    // summary += `Max: 200<br>`;
    // summary += `Average: 140`;

    // this.summaryContainer.nativeElement.innerHTML = summary;
  }


  getColumnTitle(column: string): string {
    switch (column) {
      case 'id':
        return 'Patient ID';
      case 'name':
        return 'Name';
      case 'dateOfBirth':
        return 'Date Of Birth';
      case 'studyStartTime':
        return 'Study Start Time';
      case 'studyEndTime':
        return 'Study End Time';
      case 'deviceSerialNumber':
        return 'Device Serial Number';
      case 'totalNumberOfEvents':
        return 'Total Number Of Events';
      default:
        return column;
    }
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.goToPage(this.currentPage - 1);
    }
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.goToPage(this.currentPage + 1);
    }
  }

  goToPage(page: number): void {
    if (this.currentPage !== page) {
      this.currentPage = page;
      this.GetPatientsDetails();
    }
  }

  onPageChange(event: PageEvent): void {
    this.currentPage = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.GetPatientsDetails();
  }
}
