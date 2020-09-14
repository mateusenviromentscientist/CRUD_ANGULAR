import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'perfil',
  template: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  @Input() titulo : string;
  constructor() { }

  ngOnInit() {
  }

}
