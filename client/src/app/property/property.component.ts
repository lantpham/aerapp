import { Component, Input, OnInit } from '@angular/core';
import { Property } from '../_models/property';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.css']
})
export class PropertyComponent implements OnInit {
  propertiesForCurrentUser: Property[]=[
    {'id':1, 'address':"1234 somewhere", 'acquisitionValue':125000, 'city':"Austin",'state':"TX" ,'zip':"78723", 'acquisitionDate': null},
    {'id':2, 'address':"3452 somewhere", 'acquisitionValue':125000, 'city':"Austin", 'state':"TX" ,'zip':"78723", 'acquisitionDate': null}
  ];
  constructor() { }

  ngOnInit(): void {
  }

}
