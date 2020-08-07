import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RequestModel } from '../shared/request.model';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent implements OnInit {
  id: number = 10001;
  date = new Date();

  requests: RequestModel[];

  department = ['IT', 'Admin', 'Finance', 'Other'];

  ITCat = ['Hardware', 'Software'];
  ITSubCatHW = ['Laptop', 'Mouse', 'Keyboard'];
  ITSubCatSW = ['OS', 'Licensed product'];

  financeCat = ['Salary issue'];
  financeSubCat = ['Salary Calculation'];

  otherCat = ['Travel booking'];
  otherSubCat = ['International travel ticket', 'Domestic Travel booking'];

  catAdmin = [];
  subCategory = ['Cleaning'];

  deptHasValue: boolean = false;
  deptChanged = false;
  depart = '';
  reqCat = '';
  subCat = '';
  requestCreated = false;

  onSubmit(form: NgForm) {
    const value = form.value;
    console.log(value);
    console.log(value['dept']);

    // this.requests.push(
    //   new RequestModel(this.id, value['dept'],value['category'],
    //   value['subCat'],value['summary']
    //   ))
    this.id = Math.floor(Math.random() * (999999 - 100000)) + 100000;
    this.depart = '';
    this.reqCat = '';
    this.subCat = '';
    this.requestCreated = true;
  }
  onSelectDept(event: any) {
    this.depart = event.target.value;
    this.deptChanged = true;
    this.reqCat = '';
  }

  onSelectIT(event: any) {
    this.reqCat = event.target.value;
  }
  onSelectAdmin(event: any) {
    this.reqCat = event.target.value;
  }
  onSelectOther(event: any) {
    this.reqCat = event.target.value;
  }
  onSelectFinance(event: any) {
    this.reqCat = event.target.value;
  }

  onCancel() {}

  ngOnInit(): void {}
}
