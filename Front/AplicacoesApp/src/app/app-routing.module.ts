import { PapelDetalheComponent } from './components/papeis/papel-detalhe/papel-detalhe.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PapeisComponent } from './components/papeis/papeis.component';
import { MovimentosComponent } from './components/movimentos/movimentos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PapelListaComponent } from './components/papeis/papel-lista/papel-lista.component';

import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';

const routes: Routes = [
  {
    path: 'user',
    component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent },
    ],
  },
  { path: 'user/perfil', component: PerfilComponent },
  { path: 'papeis', redirectTo: 'papeis/lista' },
  {
    path: 'papeis',
    component: PapeisComponent,
    children: [
      { path: 'detalhe/:id', component: PapelDetalheComponent },
      { path: 'detalhe', component: PapelDetalheComponent },
      { path: 'lista', component: PapelListaComponent },
    ],
  },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'movimentos', component: MovimentosComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
