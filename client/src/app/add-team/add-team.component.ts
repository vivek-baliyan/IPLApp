import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Team } from '../_models/Team';
import { TeamsService } from '../_services/teams.service';

@Component({
  selector: 'app-add-team',
  templateUrl: './add-team.component.html',
  styleUrls: ['./add-team.component.css'],
})
export class AddTeamComponent implements OnInit {
  @Output() cancelTeam = new EventEmitter();
  addTeamForm: FormGroup;
  maxDate: Date;
  validationErrors: string[] = [];
  team: Team;
  isEditMode = false;

  constructor(
    private teams: TeamsService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.route.data.subscribe((data) => {
      this.isEditMode = false;
      if (data.team) {
        this.team = data.team;
        this.addTeamForm.patchValue(data.team);
        this.isEditMode = true;
      }
    });
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  }

  initializeForm() {
    this.addTeamForm = this.fb.group({
      id: [0],
      teamName: ['', Validators.required],
      shortName: ['', Validators.required],
      owner: ['', Validators.required],
      venue: ['', Validators.required],
      coach: ['', Validators.required],
      captain: ['', Validators.required],
    });
  }

  saveTeam() {
    this.teams.saveTeam(this.addTeamForm.value).subscribe({
      next: (response) => {
        this.router.navigateByUrl('/teams');
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  updateTeam() {
    this.teams.updateTeam(this.addTeamForm.value).subscribe({
      next: (response) => {
        this.router.navigateByUrl('/teams');
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  deleteTeam(id: number) {
    this.teams.deleteTeam(id).subscribe({
      next: (response) => {
        this.router.navigateByUrl('/teams');
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
