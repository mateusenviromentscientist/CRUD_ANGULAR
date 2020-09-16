import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Player } from '../models/player';


@Component({
  selector: 'player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  
  public modalRef:BsModalRef;
  public playerForm : FormGroup;
  public titulo = 'jogadores ganhadores da bola de ouro';
  public playerSelecionado: Player;
  public textSimple:string;
  
  public players = [
   {id:1,jogador:'Messi',clube:'Barcelona'},
   {id:2,jogador:'CR7',clube:'Real Madrid'},
   {id:3,jogador:'Modric',clube:'Real Madrid'},
   {id:4,jogador:'Zidane',clube:'Real Madrid'},
   {id:5,jogador:'Ronaldo',clube:'Internazonale'},
  ];

  
  openModal(template:TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }
  
  constructor(private fb: FormBuilder, private modalService: BsModalService){
    this.criarForm();
  }

  ngOnInit() {
  }

  criarForm(){
    this.playerForm= this.fb.group({
      jogador: ['', Validators.required],
      clube: ['', Validators.required]
    });
  }
  
  playerSubmit(){
    console.log(this.playerForm.value);
  }
  
  playerSelect(player:Player){
    this.playerSelecionado=player;
    this.playerForm.patchValue(player);
  }

  voltar(){
    this.playerSelecionado= null;
  }

}
