import { TestBed } from '@angular/core/testing';
import { AngularWebStorageModule, LocalStorageService } from 'angular-web-storage';
import { AuthService } from './auth.service';

describe('AuthService', () => {
  let service: AuthService;
  let localService : LocalStorageService;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [AngularWebStorageModule]
    });
    service = TestBed.inject(AuthService);
    localService = TestBed.inject(LocalStorageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get currentUser', () => {
    //Arrange
    //i'm setting up the spy to act in behalf of actual LocalStorageService
    spyOn(localService, 'get').and.returnValue({
      id: 1,
      name: 'Test User'
    });

    //Act
    const currentUser = service.getCurrentUser();

    //"Assert"
    expect(localService.get).toHaveBeenCalled();
    expect(currentUser).toBeTruthy();
    expect(currentUser.id).toEqual(1);
  })
});
