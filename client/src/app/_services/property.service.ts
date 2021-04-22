import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Property } from '../_models/property';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  baseUrl = environment.apiUrl;
  constructor(private http:HttpClient) { }
  createProperty(model:Property){
    return this.http.post(this.baseUrl + 'properties/create', model).pipe(
      map((resp: Property) => {
        const prop = resp;
        if(prop){
          console.log(prop);
        } 
        return prop;
      }
    ));
  }
  getProperties(){
    return this.http.get(this.baseUrl + "properties").pipe(
      map((resp: Property[]) =>{
        const prop = resp;
        if(prop){
          console.log(prop);
        }
        return prop;
      }
       ));
  }
}
