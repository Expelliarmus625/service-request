import { Component, OnInit, ViewChild } from '@angular/core';
import {
  trigger,
  state,
  style,
  transition,
  animate,
} from '@angular/animations';
import { MatTableDataSource } from '@angular/material/table';
import { HttpService } from '../serviceform/http.service';
import { MatPaginator } from '@angular/material/paginator';

export interface ServiceRequest {
  serviceNo: number;
  department: string;
  status: string;
  requestCategory: string;
  requestSubCategory: string;
  summary: string;
}

@Component({
  selector: 'app-dashboardpage',
  templateUrl: './dashboardpage.component.html',
  styleUrls: ['./dashboardpage.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition(
        'expanded <=> collapsed',
        animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')
      ),
    ]),
  ],
})
export class DashboardpageComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  dataSource: any;
  columnsToDisplay = [
    'id',
    'title',
    'departmentName',
    'categoryName',
    'subCategory',
  ];
  expandedElement: ServiceRequest | null;

  constructor(private httpService: HttpService) {}

  onFilter(value: string) {
    this.dataSource.filter = value.trim().toLowerCase();
  }

  filterFromCard(type: string) {
    this.dataSource.filter = type.trim().toLowerCase();
  }

  onClearFilter() {
    this.dataSource.filter = '';
  }

  ngOnInit() {
    this.httpService.fetchFromAPI().subscribe((requests) => {
      this.dataSource = new MatTableDataSource(requests);
      this.dataSource.paginator = this.paginator;
    });
  }
}
