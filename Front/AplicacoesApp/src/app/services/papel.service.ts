import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Papel } from '../models/Papel';

@Injectable()
// { providedIn: 'root' }
export class PapelService {
  baseURL = 'https://localhost:5001/api/papel';
  constructor(private http: HttpClient) {}

  public getPapeis(): Observable<Papel[]> {
    return this.http.get<Papel[]>(this.baseURL);
  }

  public getPapeisByNome(nome: string): Observable<Papel[]> {
    return this.http.get<Papel[]>(`${this.baseURL}/${nome}/nome`);
  }
  public getPapelById(id:number): Observable<Papel> {
    return this.http.get<Papel>(`${this.baseURL}/${id}`);
  }
}
