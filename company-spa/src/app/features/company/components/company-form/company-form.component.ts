
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyService } from 'src/app/core/services/company.service';
import { Company } from 'src/app/core/models/company.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-company-form',
  templateUrl: './company-form.component.html',
  styleUrls: ['./company-form.component.css']
})
export class CompanyFormComponent implements OnInit {
  companyForm: FormGroup;
  isSubmitting = false;
  errorMessage = '';
  successMessage = '';

  constructor(private fb: FormBuilder, private companyService: CompanyService, private router: Router) {
    this.companyForm = this.fb.group({
      name: ['', Validators.required],
      exchange: ['', Validators.required],
      ticker: ['', Validators.required],
      isin: ['', Validators.required],
      website: ['']
    });
  }

  ngOnInit(): void {}

  onSubmit(): void {
    if (this.companyForm.valid) {
      this.isSubmitting = true;
      this.errorMessage = '';
      this.successMessage = '';
      const newCompany: Company = this.companyForm.value;
      this.companyService.createCompany(newCompany).subscribe({
        next: (createdCompany) => {
          this.successMessage = 'Company created successfully!';
          this.isSubmitting = false;
          this.companyForm.reset();
          this.router.navigate(['/company']);
        },
        error: (err) => {
          console.error('Error creating company:', err);
          this.errorMessage = 'Error creating company. Please try again later.' + err.message;
          this.isSubmitting = false;
        }
      });
    } else {
      this.errorMessage = 'Please fill in all required fields.';
    }
  }
}
