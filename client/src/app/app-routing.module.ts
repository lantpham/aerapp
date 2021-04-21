import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { PropertiesDetailsComponent } from './properties/properties-details/properties-details.component';
import { PropertiesListComponent } from './properties/properties-list/properties-list.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'members', component: MemberListComponent},
  {path: 'properties', component: PropertiesListComponent},
  {path: 'properties/:id', component: PropertiesDetailsComponent},
  {path: '**', component: HomeComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
