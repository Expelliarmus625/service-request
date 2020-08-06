import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpService } from '../serviceform/http.service';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css'],
})
export class CardsComponent implements OnInit {
  constructor(private http: HttpService) {}
  @Output() cardSelected = new EventEmitter<string>();

  completed: number;
  closed: number;
  pending: number;

  ngOnInit() {
    this.http.fetchFromAPI().subscribe((requests) => {
      this.completed = requests.filter((request) => {
        return request.statusId === 0;
      }).length;
      this.pending = requests.filter((request) => {
        return request.statusId === 1;
      }).length;
      this.closed = requests.filter((request) => {
        return request.status.status1 === 2;
      }).length;
      
    });
  }

  onSelect(type: string) {
    //emit the type of the card by which to filter the requests list
    this.cardSelected.emit(type);
  }
}
