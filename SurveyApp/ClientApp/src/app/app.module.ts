import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { FormComponent } from './form/form/form.component';
import { ResponseComponent } from './response/response.component';
import { DataService } from './data.service';
import { AdministratorComponent } from './administrator/administrator.component';
import { FacultyComponent } from './faculty/faculty.component';
import { EditFormComponent } from './form/edit-form/edit-form.component';
import { QuestionaireItemComponent } from './form/questionaire-item/questionaire-item.component';
import { QuestionaireListComponent } from './form/questionaire-list/questionaire-list.component';
import { SurveyPageComponent } from './survey-page/survey-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    FormComponent,
    ResponseComponent,
    AdministratorComponent,
    FacultyComponent,
    SurveyPageComponent,
    EditFormComponent,
    QuestionaireItemComponent,
    QuestionaireListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'questionaire', component: QuestionaireListComponent },
      { path: 'questionaire/:id', component: QuestionaireItemComponent },
      { path: 'form', component: FormComponent },
      { path: 'form/:id', component: EditFormComponent },
      {path: 'survey/:id', component: SurveyPageComponent},
      { path: 'administrator', component: AdministratorComponent },
      { path: 'faculty', component: FacultyComponent },
      { path: 'counter', component: CounterComponent },
      /*{ path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },*/
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    DataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
