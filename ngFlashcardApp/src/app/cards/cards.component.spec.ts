import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Observable, from } from 'rxjs';
import { FlashCard } from 'src/models/flashcard';
import { CardsAPIService } from '../cards-api.service';
import { CardsComponent } from './cards.component';

describe('CardsComponent', () => {
  let component: CardsComponent;
  let fixture: ComponentFixture<CardsComponent>;
  let apiService : CardsAPIService;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardsComponent ],
      imports : [ HttpClientTestingModule]
    })
    .compileComponents();

    apiService = TestBed.inject(CardsAPIService);
    fixture = TestBed.createComponent(CardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should get all cards', () => {
    const mockedRes : any[] = [
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
    spyOn(apiService, 'getAllCards').and.returnValue(
      // from(mockedRes) as Observable<any[]>
      new Observable( observer => {
          observer.next(mockedRes);
          observer.complete();
        })
    );
    fixture = TestBed.createComponent(CardsComponent);
    //this gets you the ts class
    component = fixture.componentInstance;
    fixture.detectChanges();

    expect(component.allCards).toBeTruthy();
    expect(component.allCards.length).toBe(2);
  })
});
