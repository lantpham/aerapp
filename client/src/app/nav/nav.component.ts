import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: User = {}

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
  }
  login(){
  
   this.accountService.login(this.model).subscribe(response =>{
     this.router.navigateByUrl('/property')
   
   }, error =>{
     console.log ("error logged in");
   })
  }
  logout(){
    this.accountService.logout();
  }

}
