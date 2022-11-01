import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HarnessLoader } from '@angular/cdk/testing';
import { TestbedHarnessEnvironment } from '@angular/cdk/testing/testbed'
import { AuthService } from '../services/auth-service/auth.service';
import { PokeApiService } from '../services/poke-api-service/poke-api.service';
import { MatButtonHarness } from '@angular/material/button/testing';
import { MatDialogModule } from '@angular/material/dialog';

import { ProfileComponent } from './profile.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';


describe('ProfileComponent', () => {
  let component: ProfileComponent;
  let fixture: ComponentFixture<ProfileComponent>;
  let loader: HarnessLoader;
  let authService : AuthService;
  let apiService : PokeApiService;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfileComponent ],
      imports: [ 
        MatDialogModule,
        HttpClientTestingModule
      ]
    })
    .compileComponents();

    authService = TestBed.inject(AuthService);
    apiService = TestBed.inject(PokeApiService);

    spyOn(authService, 'getCurrentUser').and.returnValue({id: 1, name: 'Test Trainer'})
    fixture = TestBed.createComponent(ProfileComponent);
    loader = TestbedHarnessEnvironment.loader(fixture);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call deposit pokemon', async () => {
    spyOn(component, 'depositPokemon').and.returnValue(undefined);
    const btn = await loader.getHarness(MatButtonHarness);
    await btn.click();
    expect(component.depositPokemon).toHaveBeenCalled();
  });

  it('should have Test Trainer name', () => {
    expect(component.currentUser).toBeTruthy();
    expect(component.currentUser.name).toEqual('Test Trainer');
  })

  it('should display Test Trainer as name', async () => {
    await fixture.whenStable().then(() => {
      const elem : HTMLElement = fixture.nativeElement;
      fixture.detectChanges();
      expect(elem.querySelector('.profile-card > div > h3')?.innerHTML).toEqual('Test Trainer');
    })
  });
});
