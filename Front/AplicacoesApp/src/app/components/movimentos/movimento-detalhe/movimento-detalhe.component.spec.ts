import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovimentoDetalheComponent } from './movimento-detalhe.component';

describe('MovimentoDetalheComponent', () => {
  let component: MovimentoDetalheComponent;
  let fixture: ComponentFixture<MovimentoDetalheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovimentoDetalheComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovimentoDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
