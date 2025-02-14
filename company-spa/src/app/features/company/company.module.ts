import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyRoutingModule } from './company-routing.module';
import { CompanyGridComponent } from './components/company-grid/company-grid.component';
import { MaterialModule } from 'src/app/shared/material.module';
import { CompanyFormComponent } from './components/company-form/company-form.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CompanyGridComponent,
    CompanyFormComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CompanyRoutingModule,
    MaterialModule
  ],
  exports: [CompanyGridComponent]
})
export class CompanyModule { }
