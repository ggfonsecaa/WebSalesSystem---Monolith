import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubtenantComponent } from './subtenant.component';

describe('SubtenantComponent', () => {
  let component: SubtenantComponent;
  let fixture: ComponentFixture<SubtenantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SubtenantComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SubtenantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
