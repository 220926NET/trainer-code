import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AuthService } from '../auth-service/auth.service';
import { AuthGuardService } from './auth-guard.service';

describe('AuthGuardService', () => {
  let authGuardService: AuthGuardService;
  // let authService : AuthService;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule]
    });
    authGuardService = TestBed.inject(AuthGuardService);
    // authService = TestBed.inject(AuthService);
  });

  it('should be created', () => {
    expect(authGuardService).toBeTruthy();
  });
});
