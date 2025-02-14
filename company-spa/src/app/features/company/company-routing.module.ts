import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyFormComponent } from './components/company-form/company-form.component';
import { CompanyGridComponent } from './components/company-grid/company-grid.component';

const routes: Routes = [
  { path: '', component: CompanyGridComponent }, 
  { path: 'new', component: CompanyFormComponent } 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
