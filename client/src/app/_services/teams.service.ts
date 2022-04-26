import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Team } from '../_models/Team';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TeamsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getTeams() {
    return this.http.get<Team[]>(this.baseUrl + 'teams');
  }

  saveTeam(team: Team) {
    return this.http.post(this.baseUrl + 'teams/save', team);
  }

  deletePhoto(photoId: number) {
    return this.http.delete(this.baseUrl + 'teams/delete-photo/' + photoId, {});
  }
}
