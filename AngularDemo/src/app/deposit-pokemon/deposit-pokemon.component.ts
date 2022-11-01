import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Pokemon } from '../models/pokemon';
import { PokeTrainer } from '../models/poketrainer';
import { AuthService } from '../services/auth-service/auth.service';


@Component({
  selector: 'app-deposit-pokemon',
  templateUrl: './deposit-pokemon.component.html',
  styleUrls: ['./deposit-pokemon.component.css']
})
export class DepositPokemonComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DepositPokemonComponent>, private auth : AuthService, @Inject(MAT_DIALOG_DATA) public data: Pokemon) { }


  pokemonForm = new FormGroup({
    name: new FormControl(this.data.name, [Validators.required]),
    nickName: new FormControl(this.data.nickName),
    level: new FormControl(this.data.level, [Validators.required, Validators.min(1), Validators.max(99)]),
    type: new FormControl(this.data.type),
    disposition: new FormControl(this.data.disposition)
  });

  onClick(res : string) {
      this.data.level = this.pokemonForm.controls.level.value ?? 0;
      this.data.name = this.pokemonForm.controls.name.value ?? '';
      this.data.nickName = this.pokemonForm.controls.nickName.value ?? '';
      this.data.disposition = this.pokemonForm.controls.disposition.value ?? '';
      this.data.type = this.pokemonForm.controls.type.value ?? '';
      this.dialogRef.close(this.data);
  }
  
  currentUser : PokeTrainer = {
    name: ''
  }
  
  ngOnInit(): void {
  }

}
