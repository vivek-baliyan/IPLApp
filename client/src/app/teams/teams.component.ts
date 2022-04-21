import { Component, OnInit } from '@angular/core';
import { Team } from '../_models/Team';
import { TeamsService } from '../_services/teams.service';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css'],
})
export class TeamsComponent implements OnInit {
  teams: Team[];

  constructor(private teamsService: TeamsService) {}

  ngOnInit(): void {
    this.getTeams();
  }

  getTeams() {
    this.teamsService.getTeams().subscribe((response) => {
      this.teams = response;
    });
  }
}
