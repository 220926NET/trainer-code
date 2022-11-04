import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing'
import { CardsAPIService } from './cards-api.service';
import { environment } from '../environments/environment';
import { FlashCard } from 'src/models/flashcard';
describe('TestService', () => {
  let service: CardsAPIService;
  let httpMockController : HttpTestingController;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
      ]
    });
    httpMockController = TestBed.inject(HttpTestingController);
    service = TestBed.inject(CardsAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  //one way to verify your http calls are working
  it('should send GET request for getAllCards', () =>{
    const mockedRes : FlashCard[] = [
      {
        id: 1,
        question : 'sample q',
        answer : 'test a',
        correctlyAnswered : false
      },
      {
        id : 2,
        question : 'sample q',
        answer : 'test a',
        correctlyAnswered : false
      }
    ];

    service.getAllCards().subscribe((res) => {
      expect(res).toBeTruthy();
      expect(res.length).toEqual(2);
      expect(res).toEqual(mockedRes);
    });

    //Setting up our Assert portion of test
    //we are expecting a http request to our api url
    //and expecting the request to be using GET method
    const req = httpMockController.expectOne(environment.flashcardsAPI);
    expect(req.request.method).toBe('GET');

    //respond to the fake request with a fake response
    req.flush(mockedRes);

    //after everything is over, make sure there is no other http requests it's still waiting for
    httpMockController.verify();
  });

  it('should send POST request for addCard', () => {
    const cardToAdd : FlashCard = {
      question : 'test q',
      answer : 'test a',
      correctlyAnswered : false
    };
    service.addCard(cardToAdd).subscribe((res) => {
      expect(res).toBeNull();
    });

    const req = httpMockController.expectOne(environment.flashcardsAPI);
    expect(req.request.method).toBe('POST');

    //respond to the fake request with a fake response
    req.flush(null);

    //after everything is over, make sure there is no other http requests it's still waiting for
    httpMockController.verify();
  })
});
