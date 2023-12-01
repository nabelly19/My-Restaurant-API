import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientAppStoreComponent } from './client-app-store.component';

describe('ClientAppStoreComponent', () => {
  let component: ClientAppStoreComponent;
  let fixture: ComponentFixture<ClientAppStoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientAppStoreComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ClientAppStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
