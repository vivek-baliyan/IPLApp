import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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

  constructor(private teams: TeamsService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.addTeamForm = this.fb.group({
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
        // this.router.navigateByUrl('/members');
        console.log(response);
      },
      error: (error) => {
        this.validationErrors = error;
      },
    });
  }
}
