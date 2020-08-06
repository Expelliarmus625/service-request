import { NgForm } from '@angular/forms';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Request } from './request.model';

@Injectable({ providedIn: 'root' })
export class HttpService {
  constructor(private http: HttpClient) {}

  createAndStoreRequest(formData: Request) {
    this.http
      .post('http://localhost:5000/api/requests', formData)
      .subscribe((data) => {
        console.log(data);
      });
  }

  fetchFromAPI() {
    return this.http.get('http://localhost:5000/api/requests').pipe(
      map((responseData) => {
        const postArray = [];
        for (const key in responseData) {
          if (responseData.hasOwnProperty(key)) {
            postArray.push({
              ...responseData[key],
              departmentName: responseData[key].department.name,
              categoryName: responseData[key].category.name,
              subCategory: responseData[key].subCategory.name,
              statusType: responseData[key].status.status1,
            });
          }
        }
        return postArray;
      })
    );
  }

  fetchRequestById(id: number) {
    return this.http.get('http://localhost:5000/api/requests/' + id);
  }

  getDepartments() {
    return this.http.get('http://localhost:5000/api/departments').pipe(
      map((resposeData) => {
        const departmentsArray = [];
        for (const key in resposeData) {
          if (resposeData.hasOwnProperty(key)) {
            departmentsArray.push({ ...resposeData[key] });
          }
        }
        return departmentsArray;
      })
    );
  }

  getCategories() {
    return this.http.get('http://localhost:5000/api/categories').pipe(
      map((responseData) => {
        const categoriesArray = [];
        for (const key in responseData) {
          if (responseData.hasOwnProperty(key)) {
            categoriesArray.push({ ...responseData[key] });
          }
        }
        return categoriesArray;
      })
    );
  }
}
