import { TeamLogo } from './TeamLogo';

export class Team {
  id: number;
  teamName: string;
  shortName: string;
  owner: string;
  venue: string;
  coach: string;
  captain: string;
  year: number;
  logo: TeamLogo;
}
