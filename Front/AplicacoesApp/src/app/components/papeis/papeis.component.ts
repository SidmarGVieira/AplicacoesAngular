import { Component, OnInit, TemplateRef } from '@angular/core';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

import { PapelService } from '../../services/papel.service';
import { Papel } from '../../models/Papel';
import { NgxSpinnerService } from 'ngx-spinner';

import { TituloComponent } from '../../shared/titulo/titulo.component';

@Component({
  selector: 'app-papeis',
  templateUrl: './papeis.component.html',
  styleUrls: ['./papeis.component.scss'],
})
export class PapeisComponent implements OnInit {
  public modalRef?: BsModalRef;
  public papeis: Papel[] = [];
  public papeisFiltrados: Papel[] = [];

  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.papeisFiltrados = this.filtroLista
      ? this.filtrarPapeis(this.filtroLista)
      : this.papeis;
  }

  public filtrarPapeis(filtrarPor: string): Papel[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.papeis.filter(
      (papel: Papel) =>
        papel.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        papel.descricao.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private papelService: PapelService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) {}

  public ngOnInit(): void {
    this.spinner.show();
    this.getPapeis();
  }

  public getPapeis(): void {
    this.papelService.getPapeis().subscribe({
     next: (_papeis: Papel[]) => {
        this.papeis = _papeis;
        this.papeisFiltrados = this.papeis;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os papeis', 'Erro');
      },
      //console.log(error),
      complete: () => this.spinner.hide()
  })
}

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Papel deletado com sucesso!', 'Deletado');
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
