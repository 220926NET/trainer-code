import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '../services/auth-service/auth.service';
import { PokeApiService } from '../services/poke-api-service/poke-api.service';
import { PokeTrainer } from '../models/poketrainer';
import { Pokemon } from '../models/pokemon';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-pokemon-view',
  templateUrl: './pokemon-view.component.html',
  styleUrls: ['./pokemon-view.component.css']
})
export class PokemonViewComponent implements OnInit, OnDestroy {

  constructor(private auth: AuthService, private api:PokeApiService, public dialog: MatDialog) { }

  currentUser : PokeTrainer = {
    name : ''
  };

  pokemons : Pokemon[] = [{name: '', level: 0, trainerId: 0}]

  withdraw(pokeId : number | undefined) {
    if(pokeId) {
      let dialog : MatDialogRef<WithdrawDialogue> = this.dialog.open(WithdrawDialogue, {
        width: '250px'
      })
      dialog.afterClosed().subscribe((result) => {
        if(result){
          this.api.withdrawPokemon(pokeId).subscribe((res) => {
            alert('here is your pokemon! ' + JSON.stringify(res));
            this.updatePokemon();
          })
        }
      })
    }
  }

  updatePokemon() : void {
    if(this.currentUser?.id) {
      this.api.getPokemonByTrainerId(this.currentUser.id).subscribe((res) => {
        this.pokemons = res;
      })
    }
  }

  ngOnInit(): void {
    //get data, do some other initial set up behavior
    //get pokemon data according to the current user
    this.currentUser = this.auth.getCurrentUser();
    this.updatePokemon();
  }

  ngOnDestroy() : void {
    //clean up code here
  }

}

@Component({
  selector: 'withdraw-dialogue',
  templateUrl: 'withdrawdialogue.component.html',
})
export class WithdrawDialogue {
  constructor(public dialogRef: MatDialogRef<WithdrawDialogue>) {}

  onClick(answer : string): void {
    this.dialogRef.close(answer === 'yes' ? true : false);
  }
}