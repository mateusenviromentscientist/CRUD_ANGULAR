import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

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
   BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
