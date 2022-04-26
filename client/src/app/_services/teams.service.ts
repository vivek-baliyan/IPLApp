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
  getTeam(id: string) {
    return this.http.get<Team>(this.baseUrl + `teams/${id}`);
  }
  saveTeam(team: Team) {
    return this.http.post(this.baseUrl + 'teams', team);
  }
  updateTeam(team: Team) {
    return this.http.put(this.baseUrl + 'teams', team);
  }
  deleteTeam(id: number) {
    return this.http.delete(this.baseUrl + `teams/${id}`);
  }
  deletePhoto(photoId: number) {
    return this.http.delete(this.baseUrl + `teams/delete-photo/${photoId}`, {});
  }
}
