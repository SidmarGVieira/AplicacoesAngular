import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PapeisComponent } from './components/papeis/papeis.component';
import { MovimentosComponent } from './components/movimentos/movimentos.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

const routes: Routes = [
  {path: 'papeis', component: PapeisComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'movimentos', component: MovimentosComponent},
  {path: 'perfil', component: PerfilComponent},
  {path: '', redirectTo: 'dashboard', pathMatch : 'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch : 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
