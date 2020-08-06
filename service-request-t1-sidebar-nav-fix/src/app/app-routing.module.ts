import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardpageComponent } from './dashboardpage/dashboardpage.component';
import { ServiceformComponent } from './serviceform/serviceform.component';
import { DetailsComponent } from './serviceform/details.component';

const appRoutes: Routes = [
  { path: '', redirectTo: '/dashboardpage', pathMatch: 'full' },
  { path: 'dashboardpage', component: DashboardpageComponent },
  // { path: 'cards', component: CardsComponent },
  { path: 'serviceform', component: DetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
