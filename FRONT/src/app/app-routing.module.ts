import { ProfessorDeleteComponent } from './components/professor/professor-delete/professor-delete.component';
import { ProfessorUpdateComponent } from './components/professor/professor-update/professor-update.component';
import { ProfessorCreateComponent } from './components/professor/professor-create/professor-create.component';
import { TurmaCreateComponent } from './components/turma/turma-create/turma-create.component';
import { TurmaReadComponent } from './components/turma/turma-read/turma-read.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './views/home/home.component';
import { ProfessorCrudComponent } from './views/professor-crud/professor-crud.component';
import { TurmaCrudComponent } from './views/turma-crud/turma-crud.component';

const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "professores",
    component: ProfessorCrudComponent
  },
  {
    path: "professores/create",
    component: ProfessorCreateComponent
  },
  {
    path: "professores/update/:id",
    component: ProfessorUpdateComponent
  },
  {
    path: "professores/delete/:id",
    component: ProfessorDeleteComponent
  },
  {
    path: "turmas",
    component: TurmaCrudComponent
  },
  {
    path: "turmas/criar",
    component: TurmaCreateComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
