import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { Team } from '../_models/Team';
import { TeamsService } from '../_services/teams.service';

@Injectable({
  providedIn: 'root'
})
export class AddTeamResolver implements Resolve<Team> {
  constructor(private teams: TeamsService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Team> {
    return this.teams.getTeam(route.paramMap.get('id'));
  }

  // resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
  //   return of(true);
  // }
}
