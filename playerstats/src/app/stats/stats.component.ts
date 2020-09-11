import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent implements OnInit {

  dados = 'estatísticas dos ganhadores da bola de ouro';

  public estatisticas = [
    {stats:'72 gols e 30 assistencias'},
    {stats:'53 gols e 20 assistencias'},
    {stats:'15 gols e 3 assistencias'},
    {stats:'20 gols e 10 assistencias'},
    {stats:'20 gols e 10 assistencias'},
  ];

  constructor() { }

  ngOnInit() {
  }

}
