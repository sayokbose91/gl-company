import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { 
    path: 'company', 
    loadChildren: () => import('./features/company/company.module').then(m => m.CompanyModule)
  },
  { path: '', redirectTo: 'company', pathMatch: 'full' },
  { path: '**', redirectTo: 'company' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
