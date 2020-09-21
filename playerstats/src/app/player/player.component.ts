import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Player } from '../models/player';
import { PlayerService } from './player.service';


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
  public modo = 'post';
  
  public players : Player[];
  openModal(template:TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }
  
  constructor(private fb: FormBuilder, private modalService: BsModalService,
    private playerService:PlayerService){
    this.criarForm();
  }

  ngOnInit() {
    this.carregarPlayers();
  }

   carregarPlayers(){
   this.playerService.getAll().subscribe((players: Player[])=>{
   this.players = players;
   },
   (erro:any) =>{
    console.error(erro)
   }
   );
  }

  criarForm(){
    this.playerForm= this.fb.group({
      id :[''],
      player: ['', Validators.required],
    });
  }

  salvarPlayer(player: Player){
    if (player.id === 0) this.modo = 'post';
    else{
      this.modo = 'put';
    }
   this.playerService[this.modo](player).subscribe((player:Player)=>{console.log(Player);
   this.carregarPlayers()},
   (erro:any)=>{console.log(erro)});
  }
  playerSubmit(){
    this.salvarPlayer(this.playerForm.value);
  };
  
  deletarPlayer(id: number){
    this.playerService.delete(id).subscribe((model)=>{console.log(model);
    this.carregarPlayers();},
    (erro:any)=>{
      console.log(erro);
    })
  }
  
  
  playerSelect(player:Player){
    this.playerSelecionado=player;
    this.playerForm.patchValue(player);
  }

  playerNovo(){
    this.playerSelecionado = new Player();
    this.playerForm.patchValue(this.playerSelecionado);
  }

  voltar(){
    this.playerSelecionado= null;
  }

}
