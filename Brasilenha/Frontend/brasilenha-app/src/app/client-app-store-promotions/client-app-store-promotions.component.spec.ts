import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientAppStorePromotionsComponent } from './client-app-store-promotions.component';

describe('ClientAppStorePromotionsComponent', () => {
  let component: ClientAppStorePromotionsComponent;
  let fixture: ComponentFixture<ClientAppStorePromotionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientAppStorePromotionsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ClientAppStorePromotionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
