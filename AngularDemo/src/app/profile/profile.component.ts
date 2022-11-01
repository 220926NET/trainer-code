import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DepositPokemonComponent } from '../deposit-pokemon/deposit-pokemon.component';
import { PokeTrainer } from '../models/poketrainer';
import { Pokemon } from '../models/pokemon';
import { AuthService } from '../services/auth-service/auth.service';
import { PokeApiService } from '../services/poke-api-service/poke-api.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  constructor(private auth : AuthService, public dialog:MatDialog, private api : PokeApiService) { }

  @Output() pokeCreated = new EventEmitter<Pokemon>();
  pokemonToCreate : Pokemon = {
    level: 0,
    trainerId: 0,
    name: '',
    disposition: '',
    type: '',
    nickName: ''
  };
  currentUser : PokeTrainer = {
    name: ''
  }

  depositPokemon() : void {
    let dialogRef : MatDialogRef<DepositPokemonComponent>  = this.dialog.open(DepositPokemonComponent, {
      data: this.pokemonToCreate
    });
    dialogRef.afterClosed().subscribe((data) => {
      if(data) {
        this.pokemonToCreate = data;
        if(data.name && data.level > 0) {
          this.api.depositPokemon(data).subscribe((res) => {
            this.pokemonToCreate = {
              level: 0,
              trainerId: 0,
              name: '',
              disposition: '',
              type: '',
              nickName: ''
            };
            this.pokeCreated.emit(res);
          });
        }
      }
    })
  }

  ngOnInit(): void {
    this.currentUser = this.auth.getCurrentUser();
    this.pokemonToCreate.trainerId = this.currentUser?.id ?? 0;
  }

}
