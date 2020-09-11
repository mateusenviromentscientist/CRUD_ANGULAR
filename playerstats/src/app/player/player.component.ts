import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {

  titulo = 'jogadores ganhadores da bola de ouro';
  
  public players = [
   {jogador:'Messi'},
   {jogador:'CR7'},
   {jogador:'Modric'},
   {jogador:'Zidane'},
   {jogador:'Ronaldo'},
  ];
  constructor() { }

  ngOnInit() {
  }

}
