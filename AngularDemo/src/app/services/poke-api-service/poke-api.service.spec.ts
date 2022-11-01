import { TestBed } from '@angular/core/testing';
import { PokeApiService } from './poke-api.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('PokeApiService', () => {
  let service: PokeApiService;
  let httpCtrllr : HttpTestingController;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    httpCtrllr = TestBed.inject(HttpTestingController);
    service = TestBed.inject(PokeApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get pokemons by trainerId', () => {
    const testTrainerId = 1;
    const pokesToReturn = [{
      id: 1,
      name: 'Pikachu',
      level: 5,
      trainerId: 1
    },
    {
      id: 2,
      name: 'Snorlax',
      level: 13,
      trainerId: 1
    }];
    
    service.getPokemonByTrainerId(testTrainerId).subscribe((res) => {
      expect(res.length).toBe(2);
      expect(res).toEqual(pokesToReturn);
    })

    const req = httpCtrllr.expectOne('https://localhost:7278/pokemon?trainerId=1');
    expect(req.request.method).toBe("GET");
    req.flush(pokesToReturn);
    httpCtrllr.verify();
  })
});
