import { Component, OnInit } from '@angular/core';
import { Property } from 'src/app/_models/property';
import { PropertyService } from 'src/app/_services/property.service';

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.css']
})
export class PropertyDetailsComponent implements OnInit {
model: Property = {'id':0, 'acquisitionDate': null, 'acquisitionValue': 0, 'address':"", 'city': "", 'state':"",'zip':""}
  constructor(private propertyService: PropertyService) { }

  ngOnInit(): void {
  }
  createNewProperty(){
    this.propertyService.createProperty(this.model).subscribe(
      response=>{
        console.log("create property")
      }, error=>{console.log("error create property")}
    );
  }

}
