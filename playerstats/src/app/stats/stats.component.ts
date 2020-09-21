import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Stats } from '../models/Stat';
import { StatService } from './stats.service';

@Component({
  selector: 'stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
 export class StatsComponent implements OnInit {
  
  public modalRef: BsModalRef;
  public titulo = 'Stats';
  public statSelecionada = Stats;
  public statForm: FormGroup;
  
  public Stats : Stats[];

  constructor(
    private fb: FormBuilder,private modalService: BsModalService,
    private statService: StatService) {
      this.StatsForm();
    }

    openModal(tempalte:TemplateRef<any>){
      this.modalRef = this.modalService.show(tempalte);
    }

  

  ngOnInit() {
    this.carregarStat();
  }

  StatsForm(){
    this.statForm= this.fb.group({
      id :[''],
      estatistica:['', Validators.required],
      clube: ['', Validators.required],
      ano : ['', Validators.required]
    });
  }

  salvarStats(stats: Stats){
    this.statService.put(stats.id, stats).subscribe((stats : Stats)=>{console.log(Stats)},
    (erro:any)=>{console.log(erro)});
   }
   playerSubmit(){
     this.salvarStats(this.statForm.value);
   };
   

  statSubmit(){
    console.log(this.statForm.value);
  }

  statSelect(stats: Stats){
    this.statSelecionada = Stats;
    this.statForm.patchValue(stats);
  }

  carregarStat(){
    this.statService.getAll().subscribe((stats:Stats[])=>{this.Stats = stats},
    (erro: any)=>{console.error(erro)})
  }

}
