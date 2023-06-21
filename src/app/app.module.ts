
import { BrowserModule } from '@angular/platform-browser';
import { FullCalendarModule } from '@fullcalendar/angular'; // must go before plugins
import dayGridPlugin from '@fullcalendar/daygrid'; // a plugin!
import interactionPlugin from '@fullcalendar/interaction'; // a plugin!
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeeaderComponent } from './components/heeader/heeader.component';
import { FooterComponent } from './components/footer/footer.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { AboutComponent } from './components/about/about.component';
import { HomeComponent } from './components/home/home.component';
import { ViewProfileComponent } from './components/view-profile/view-profile.component';
import { PersonalAreaComponent } from './components/personal-area/personal-area.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { UsersService } from './services/users.service';
import { ProfessionalsService } from './services/professionals.service';
import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AddPoffesionalComponent } from './components/add-poffesional/add-poffesional.component';
import { AddMeetingComponent } from './components/add-meeting/add-meeting.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { EdidProComponent } from './components/edid-pro/edid-pro.component';
import { EditDitailsComponent } from './components/edit-ditails/edit-ditails.component';
import { CalendarComponent } from './components/calendar/calendar.component';

FullCalendarModule.registerPlugins([ // register FullCalendar plugins
  dayGridPlugin,
  interactionPlugin
]);

@NgModule({
  declarations: [
    AppComponent,
    HeeaderComponent,
    FooterComponent,
    RegisterComponent,
    LoginComponent,
    AboutComponent,
    HomeComponent,
    ViewProfileComponent,
    PersonalAreaComponent,
    AddPoffesionalComponent,
    AddMeetingComponent,
    ResetPasswordComponent,
    EdidProComponent,
    EditDitailsComponent,
    CalendarComponent,
 
      ],
      
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MDBBootstrapModule.forRoot(),
    FormsModule,
    RouterModule,
    HttpClientModule,
    AppRoutingModule,
    CommonModule,
    NgbModule,
    ReactiveFormsModule,
    FullCalendarModule // register FullCalendar with you app
    
  ],
  providers: [UsersService, ProfessionalsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
