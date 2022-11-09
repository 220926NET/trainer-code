import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AngularWebStorageModule } from 'angular-web-storage';

import { DepositPokemonComponent } from './deposit-pokemon.component';

describe('DepositPokemonComponent', () => {
  let component: DepositPokemonComponent;
  let fixture: ComponentFixture<DepositPokemonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DepositPokemonComponent ],
      imports: [
        MatDialogModule,
        AngularWebStorageModule
      ],
      providers: [
        {
          provide: MatDialogRef,
          useValue: {}
        },
        {
          provide: MAT_DIALOG_DATA,
          useValue: {}
        }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DepositPokemonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
