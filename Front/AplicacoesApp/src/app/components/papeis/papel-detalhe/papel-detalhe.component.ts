import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-papel-detalhe',
  templateUrl: './papel-detalhe.component.html',
  styleUrls: ['./papel-detalhe.component.scss']
})
export class PapelDetalheComponent implements OnInit {

  form!: FormGroup;
  constructor(private fb: FormBuilder) { }

  get f(): any{
    return this.form.controls;
  }


  ngOnInit(): void {
    this.validation();
  }

  public validation():void{
    this.form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(5)]],
      descricao: ['', [Validators.required, Validators.minLength(20), Validators.maxLength(120)]]
    })
  }

  public resetForm():void {
    this.form.reset();
  }
}
