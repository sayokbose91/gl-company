import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material.module';
import { AppMenuComponent } from './app-menu/app-menu.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [AppMenuComponent],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule
  ],
  exports: [AppMenuComponent]
})
export class SharedModule { }
