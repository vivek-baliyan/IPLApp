import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';

import { TeamsComponent } from './teams/teams.component';
import { NavComponent } from './nav/nav.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { AddTeamComponent } from './add-team/add-team.component';
import { TextInputsComponent } from './_forms/text-inputs/text-inputs.component';
import { PhotoEditorComponent } from './photo-editor/photo-editor.component';
import { FileUploadModule } from 'ng2-file-upload';
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faArrowLeftLong, faTrashCan, faCircle } from '@fortawesome/free-solid-svg-icons';

@NgModule({
  declarations: [
    AppComponent,
    TeamsComponent,
    NavComponent,
    HomeComponent,
    AddTeamComponent,
    TextInputsComponent,
    PhotoEditorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    CarouselModule.forRoot(),
    FileUploadModule,
    FontAwesomeModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor(private library: FaIconLibrary){
    library.addIcons(faArrowLeftLong);
    library.addIcons(faTrashCan);
    library.addIcons(faCircle);
  }
}
