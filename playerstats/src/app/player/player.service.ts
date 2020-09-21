import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Player } from '../models/player';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

constructor(private http: HttpClient) { }
  baseUrl = `${environment.MainUrl} + v1/`;

 getAll(): Observable<Player[]>{
   return this.http.get<Player[]>(`${environment.MainUrl}`);
 }

 getById(id: number):Observable<Player>{
   return this.http.get<Player>(`${environment.MainUrl}/${id}`);
 }
 post(player:Player){
   return this.http.post(`${environment.MainUrl}`, player);
 }

 put (player:Player){
   return this.http.put(`${environment.MainUrl}/${player.id}`, player);
 }
 delete(id: number){
  return this.http.delete(`${environment.MainUrl}/${id}`);
};
}
