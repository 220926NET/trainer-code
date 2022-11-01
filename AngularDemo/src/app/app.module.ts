import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AngularWebStorageModule } from 'angular-web-storage';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PokemonViewComponent, WithdrawDialogue } from './pokemon-view/pokemon-view.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './navbar/navbar.component';
import { ProfileComponent } from './profile/profile.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { DepositPokemonComponent } from './deposit-pokemon/deposit-pokemon.component'

@NgModule({
  declarations: [
    AppComponent,
    PokemonViewComponent,
    LoginComponent,
    NavbarComponent,
    ProfileComponent,
    WithdrawDialogue,
    DepositPokemonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    AngularWebStorageModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule,
    MatDialogModule,
    MatFormFieldModule,
    FormsModule,
    MatInputModule
  ],
  providers: [],
  // exports: [
    //put stuff here that you want to make available to other modules that are importing this module
  //   PokemonViewComponent
  // ],
  bootstrap: [AppComponent]
})
export class AppModule { }
