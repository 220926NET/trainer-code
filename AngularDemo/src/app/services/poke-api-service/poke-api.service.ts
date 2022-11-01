import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PokeTrainer } from 'src/app/models/poketrainer';
import { Pokemon } from 'src/app/models/pokemon';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PokeApiService {

  constructor(private http: HttpClient) {}

  url : string = environment.api;

  login(user : PokeTrainer) : Observable<PokeTrainer>{
    return this.http.post(this.url + 'auth/login', user) as Observable<PokeTrainer>;
  }

  register(user : PokeTrainer) : Observable<PokeTrainer>{
    return this.http.post(this.url + 'auth/register', user) as Observable<PokeTrainer>;
  }

  getPokemonByTrainerId(trainerId : number) : Observable<Pokemon[]> {
    return this.http.get(this.url + `pokemon?trainerId=${trainerId}`) as Observable<Pokemon[]>;
  }

  withdrawPokemon(pokemonId : number) : Observable<Pokemon> {
    return this.http.delete(this.url + `pokemon/${pokemonId}`) as Observable<Pokemon>;
  }

  depositPokemon(pokemon : Pokemon) : Observable<Pokemon> {
    return this.http.post(this.url + 'pokemon', pokemon) as Observable<Pokemon>;
  }
}
