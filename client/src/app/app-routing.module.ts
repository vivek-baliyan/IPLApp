import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddTeamComponent } from './add-team/add-team.component';
import { HomeComponent } from './home/home.component';
import { TeamsComponent } from './teams/teams.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'teams', component: TeamsComponent },
  { path: 'add-team', component: AddTeamComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
