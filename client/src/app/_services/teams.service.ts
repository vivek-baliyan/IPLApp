import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Team } from '../_models/Team';

@Injectable({
  providedIn: 'root',
})
export class TeamsService {
  baseUri = 'https://localhost:7063/api/';

  constructor(private http: HttpClient) {}

  getTeams() {
    return this.http.get<Team[]>(this.baseUri + 'teams');
  }
}
