import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PlayerComponent } from './player/player.component';
import { StatsComponent } from './stats/stats.component';
import { PerfilComponent } from './perfil/perfil.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NavComponent } from './nav/nav.component';
import { TituloComponent} from './titulo/titulo.component';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';



@NgModule({
  declarations: [																				
    AppComponent,
      PlayerComponent,
      StatsComponent,
      PerfilComponent,
      DashboardComponent,
      NavComponent,
      TituloComponent,
  ],

  imports:[
   BrowserModule,
   AppRoutingModule,
   BsDropdownModule.forRoot(),
   BrowserAnimationsModule,
   FormsModule,
   ReactiveFormsModule,
   ModalModule.forRoot(),
   HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
