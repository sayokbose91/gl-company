import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Company } from 'src/app/core/models/company.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private apiUrl = environment.apiUrl;
  private token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjM2MzI4OTU2OTcsImlzcyI6IkdsYXNzTGV3aXMiLCJhdWQiOiJHbGFzc0xld2lzQ2xpZW50In0.NM_UHoJMt5NHhA1lu6aitAUmPOXyAAuRHadtkiVjC4g';

  constructor(private http: HttpClient) {}

  getCompanies(): Observable<Company[]> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });
    return this.http.get<Company[]>(this.apiUrl, { headers });
  }

  createCompany(company: Company): Observable<Company> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });
    return this.http.post<Company>(this.apiUrl, company, {headers});
  }
}
