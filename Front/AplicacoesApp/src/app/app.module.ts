import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule} from 'ngx-bootstrap/tooltip';
import { BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PapeisComponent } from './components/papeis/papeis.component';
import { MovimentosComponent } from './components/movimentos/movimentos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { TituloComponent } from './shared/titulo/titulo.component';
import { NavComponent } from './shared/nav/nav.component';

import { PapelService } from './services/papel.service';
import { PapelDetalheComponent } from './components/papeis/papel-detalhe/papel-detalhe.component';
import { PapelListaComponent } from './components/papeis/papel-lista/papel-lista.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { MovimentoDetalheComponent } from './components/movimentos/movimento-detalhe/movimento-detalhe.component';
import { MovimentoListaComponent } from './components/movimentos/movimento-lista/movimento-lista.component';
@NgModule({
  declarations: [
    AppComponent,
    PapeisComponent,
    MovimentosComponent,
    DashboardComponent,
    PerfilComponent,
    NavComponent,
    TituloComponent,
    PapelDetalheComponent,
    PapelListaComponent,
    UserComponent,
    LoginComponent,
    RegistrationComponent,
    MovimentoDetalheComponent,
    MovimentoListaComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar:true
    }),
    NgxSpinnerModule

    //BsModalService,
    //BsModalRef

  ],
  providers: [
    PapelService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
