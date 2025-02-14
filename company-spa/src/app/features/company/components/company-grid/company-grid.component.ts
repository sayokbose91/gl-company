import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/core/services/company.service';
import { Company } from 'src/app/core/models/company.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-company-grid',
  templateUrl: './company-grid.component.html',
  styleUrls: ['./company-grid.component.css']
})
export class CompanyGridComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'exchange', 'ticker', 'isin', 'website'];
  dataSource = new MatTableDataSource<Company>();
  isLoading = true;
  errorMessage = '';

  constructor(private companyService: CompanyService) {}

  ngOnInit(): void {
    this.companyService.getCompanies().subscribe({
      next: (data) => {
        this.dataSource.data = data;
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error fetching companies:', error);
        this.errorMessage = 'Error fetching companies. Please try again later.';
        this.isLoading = false;
      }
    });
  }
}
