import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PapelDetalheComponent } from './papel-detalhe.component';

describe('PapelDetalheComponent', () => {
  let component: PapelDetalheComponent;
  let fixture: ComponentFixture<PapelDetalheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PapelDetalheComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PapelDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
