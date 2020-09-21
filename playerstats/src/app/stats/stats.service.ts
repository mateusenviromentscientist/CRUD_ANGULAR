import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Stats } from '../models/Stat';

@Injectable({
  providedIn: 'root'
})
export class StatService {

constructor(private http: HttpClient) { }
  baseUrl = `${environment.MainUrl} + v1/`;

 getAll(): Observable<Stats[]>{
   return this.http.get<Stats[]>(`${environment.MainUrl}`);
 }

 getById(id: number):Observable<Stats>{
   return this.http.get<Stats>(`${environment.MainUrl}/${id}`);
 }
 post(stats:Stats){
   return this.http.post(`${environment.MainUrl}`, stats);
 }

 put (id: number, stats:Stats){
   return this.http.put(`${environment.MainUrl}/${id}`, stats);
 }
 delete(id: number){
  return this.http.delete(`${environment.MainUrl}/${id}`);
};
}
