import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogModule } from '@angular/material/dialog';
import { AngularWebStorageModule } from 'angular-web-storage';

import { PokemonViewComponent } from './pokemon-view.component';

describe('PokemonViewComponent', () => {
  let component: PokemonViewComponent;
  let fixture: ComponentFixture<PokemonViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PokemonViewComponent ],
      imports: [
        HttpClientTestingModule,
        AngularWebStorageModule,
        MatDialogModule
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PokemonViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
