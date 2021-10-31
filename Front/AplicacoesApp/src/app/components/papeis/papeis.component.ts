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
  ngOnInit(): void {}
}
