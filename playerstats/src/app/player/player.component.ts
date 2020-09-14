import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {

  public titulo = 'jogadores ganhadores da bola de ouro';
  
  public players = [
   {id:1,jogador:'Messi',clube:'Barcelona'},
   {id:2,jogador:'CR7',clube:'Real Madrid'},
   {id:3,jogador:'Modric',clube:'Real Madrid'},
   {id:4,jogador:'Zidane',clube:'Real Madrid'},
   {id:5,jogador:'Ronaldo',clube:'Internazonale'},
  ];
  constructor() { }

  ngOnInit() {
  }

}
