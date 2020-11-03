import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentComponent } from './pages/student/student.component';

import { TableModule } from 'primeng/table';
import { HttpClientModule } from '@angular/common/http';
import { FormComponent } from './pages/student/form/form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModalModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    FormComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModalModule,
    TableModule,
    AppRoutingModule
  ],
  entryComponents: [
    FormComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
