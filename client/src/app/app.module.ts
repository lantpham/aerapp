import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { FormsModule } from '@angular/forms';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { PropertiesListComponent } from './properties/properties-list/properties-list.component';
import { PropertiesDetailsComponent } from './properties/properties-details/properties-details.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    MemberListComponent,
    MemberCardComponent,
    HomeComponent,
    RegisterComponent,
    PropertiesListComponent,
    PropertiesDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
