import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'dashboard',
  template: `
   <p>
  		dashboard Works!
   </p>
  `,
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
