import { Component, OnInit } from '@angular/core';
import { Stat } from '../models/stat';

@Component({
  selector: 'stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent implements OnInit {
  
  public dados = 'estatísticas dos ganhadores da bola de ouro';
  public estatSelecionada : Stat;
  public estatisticas = [
    {id:1,stats:'72 gols e 30 assistencias',nacionalidade:'argentino'},
    {id:2,stats:'53 gols e 20 assistencias',nacionalidade:'portugues'},
    {id:3,stats:'15 gols e 3 assistencias',nacionalidade:'croata'},
    {id:4,stats:'20 gols e 10 assistencias',nacionalidade:'frances'},
    {id:5,stats:'20 gols e 10 assistencias',nacionalidade:'brasileiro'},
  ];

  estatisticaSelecionada(stat:Stat){
    this.estatSelecionada = stat;
    
  }

  voltar(){
    this.estatSelecionada= null;
  }
  constructor() { }

  ngOnInit() {
  }

}
