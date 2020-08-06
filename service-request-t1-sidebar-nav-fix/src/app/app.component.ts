import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from "@angular/forms";
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
//   selectedDepartment = 0;
// selectedRequestCategory = 0;
 
// requestCategories = [];
// requestSubCategories = [];
// departments =[];
// requestCategory = [];
// requestSubCategory= [];

 

  // onSelectDepartment(department_id: number) {
  //   this.selectedDepartment = department_id;
  //   this.selectedRequestCategory = 0;
  //   this.requestSubCategories = [];
  //   this.requestCategories = this.getrequestCategory().filter((item) => {
  //   return item.department_id === Number(department_id)
  //   });
  //   }
     
  //   onSelectRequestCategory(requestCategory_id: number) {
  //   this.selectedRequestCategory = requestCategory_id;
  //   this.requestSubCategories = this.getrequestSubCategory().filter((item) => {
  //   return item.requestCategory_id === Number(requestCategory_id)
  //   });
  //   }
     

  //   getDepartment(){
  //   return [
  //   { id: 1, name: 'IT' },
  //   { id: 2, name: 'Admin' },
  //   { id: 3, name: 'Finance' }
  //   ];
  // }
    
     
  //   getrequestCategory(){
  //   return[
    
  //     { id: 1 ,department_id:1, name: 'Hardware' },
  //     { id: 2 ,department_id:1, name: 'Software' },
  //     { id: 3 ,department_id:2 ,name: 'Travel Booking' },
  //     { id: 4 ,department_id:3,name: 'Salary Issue' },
     
  //   ]
  // }
    
     
  //   getrequestSubCategory(){
  //    return [
  //     { id: 1, requestCategory_id: 1, name: 'Laptop' },
  //     { id: 2, requestCategory_id: 1, name: 'Mouse' },
  //     { id: 3, requestCategory_id: 1, name: 'Keyboard' },
  //     { id: 4, requestCategory_id: 3, name: 'International Travel Ticket' },
  //     { id: 5, requestCategory_id: 4, name: 'Salary Calculation' },
  //   ]
  // }

    //  getrequestSubCategory() {
    // return [
    //   { id: 1, requestCategory_id: 1, name: 'Laptop' },
    //   { id: 2, requestCategory_id: 1, name: 'Mouse' },
    //   { id: 3, requestCategory_id: 1, name: 'Keyboard' },
    //   { id: 4, requestCategory_id: 3, name: 'International Travel Ticket' },
    //   { id: 5, requestCategory_id: 4, name: 'Salary Calculation' },
    // ]
    // }
    



 

    
      // initializeFormGroup() {
      //   this.form.setValue({
      //     $key: null,
      //     fullName: '',
      //     department: 0,
      //     requestCategory: 0,
      //     requestSubCategory: 0,
      //   });
      // }

//     // get department(): string[] {
//     //   return Array.from(this.map.keys());
//     // }
  
//     // get requestCategories(): string[] | undefined {
//     //   return this.map.get(this.departments);
//     // }

}
