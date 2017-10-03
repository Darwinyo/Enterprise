import { NgForm } from '@angular/forms';
import 'rxjs/add/operator/filter';
import { Observable } from 'rxjs/Rx';
import { Subscription } from 'rxjs/Subscription';
import { PeriodeService } from './../../../product/services/periode/periode.service';
import { PeriodeModel } from './../../../product/models/periode/periode.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-periode-editor',
  templateUrl: './periode-editor.component.html',
  styleUrls: ['./periode-editor.component.css']
})
export class PeriodeEditorComponent implements OnInit {
  periodeModel: PeriodeModel;
  constructor(private periodeService: PeriodeService) {
    this.periodeModel = <PeriodeModel>{};
  }

  ngOnInit() {
  }
  createPeriodeModel(form: NgForm) {
    this.periodeModel = <PeriodeModel>{
      periodeDescription: form.value['periodeDescription'],
      periodeEndDate: <Date>form.value['periodeEndDate'],
      periodeStartDate: <Date>form.value['periodeStartDate']
    }
    this.periodeService.createNewPeriode(this.periodeModel).subscribe(
      (result) => console.log(result),
      (err) => console.log(err),
      () => console.log('Periode Created')
    )
  }
}
