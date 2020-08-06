import { Component, OnInit, ViewChild, Output } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, FormArray } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { CommonService } from '../common.service';
import { HttpClient } from '@angular/common/http';
import { getLocaleDateFormat } from '@angular/common';


@Component({
  selector: 'app-serviceform',
  templateUrl: './serviceform.component.html',
  styleUrls: ['./serviceform.component.css']
})
export class ServiceformComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute,private fservice: CommonService,  public fb: FormBuilder , private http: HttpClient) { }
serviceReqNumber : string;
    selectedDepartment = 0;
selectedRequestCategory = 0;
form: FormGroup;

 
requestCategories = [];
requestSubCategories = [];

  departments = [
    { id: 1, value: 'IT' },
    { id: 2, value: 'Admin' },
    { id: 3, value: 'Finance' }];

    requestCategory = [
      {id : 1 , value: 'Software'},
      {id: 2 , value : 'Travel Booking'},
      {id : 3 , value : 'Salary Issue'}
    ];

    requestSubCategory = [
      {id : 1 , value: 'Laptop'},
      {id: 2 , value : 'Travel Ticket'},
      {id : 3 , value : 'Salary Calculation'}
    ];

  ngOnInit(): void {
    
    this.form = this.fb.group({
      $key: new FormControl(null),
        serviceRequestNumber: new FormControl('', Validators.required),
        department: new FormControl(''),
        requestCategory: new FormControl(''),
        requestSubCategory: new FormControl(''),
      })
    }
  

  initializeFormGroup() {
    this.form.setValue({
      $key: null,
      fullName: '',
      department: 0,
      requestCategory: 0,
      requestSubCategory: 0,
      hireDate: '',
      isPermanent: false
    });
  }
  onClear() {
    this.form.reset();
    this.initializeFormGroup();
  }

 
  userData : FormArray[];
  
  onSubmit(userData) {
    console.log(this.form.value);
   return this.fservice.enroll(this.form.value)
      .subscribe(
        response => console.log('Success!', response),
        error => console.error('Error!', error)
        );
      }
      
      

  

  
}


