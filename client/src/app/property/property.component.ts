import { Component, Input, OnInit } from '@angular/core';
import { Property } from '../_models/property';
import { PropertyService } from '../_services/property.service';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.css']
})
export class PropertyComponent implements OnInit {
  propertiesForCurrentUser: Property[] =[];
  constructor(private propertyService: PropertyService) { }

  ngOnInit(): void {
    this.getProperties();
  }
  getProperties(){
    //this.propertiesForUser = this.propertyService.getProperties();
    this.propertyService.getProperties()
    .subscribe(
      (data) => {
        for(let p of data){
          this.propertiesForCurrentUser.push(p);
        }
      }
    )
 
  }
}
