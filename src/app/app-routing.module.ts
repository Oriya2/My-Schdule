import { NgModule } from '@angular/core';
import { Routes, RouterModule, LoadChildren } from '@angular/router';
import { AboutComponent } from './components/about/about.component';
import { AddMeetingComponent } from './components/add-meeting/add-meeting.component';
import { AddPoffesionalComponent } from './components/add-poffesional/add-poffesional.component';
import { EdidProComponent } from './components/edid-pro/edid-pro.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeeaderComponent } from './components/heeader/heeader.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { PersonalAreaComponent } from './components/personal-area/personal-area.component';
import { RegisterComponent } from './components/register/register.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { ViewProfileComponent } from './components/view-profile/view-profile.component';
import { EditDitailsComponent } from './components/edit-ditails/edit-ditails.component';
import { CalendarComponent } from './components/calendar/calendar.component';
import { Children } from 'preact/compat';

const routes: Routes = [


  {
    path: 'myHeader', component: HeeaderComponent, children: [
      { path: 'myRegister', component: RegisterComponent, },
      { path: 'myEdit', component: EditDitailsComponent }
      , { path: 'myFooter', component: FooterComponent },
      { path: "myLogin", component: LoginComponent },
      { path: "myAbout", component: AboutComponent },
      { path: "myHome", component: HomeComponent },
      { path: "myPersonalArea", component: PersonalAreaComponent},
      { path: "myAddPoffesional", component: AddPoffesionalComponent },
      { path: "myViewProfile/:tz", component: ViewProfileComponent },
      { path: "myAddMeeting/:tz", component: AddMeetingComponent },
      { path: "myResetPassword", component: ResetPasswordComponent },
      { path: "myEdidProComponent", component: EdidProComponent },
      {path: "myCalender", component: CalendarComponent},
      {path: "myEdidPro", component: EdidProComponent },
    ]
  },
  { path: "myFooterComponent", component: FooterComponent }



];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
