import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovimentoListaComponent } from './movimento-lista.component';

describe('MovimentoListaComponent', () => {
  let component: MovimentoListaComponent;
  let fixture: ComponentFixture<MovimentoListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovimentoListaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovimentoListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
