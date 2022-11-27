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
import { AlunoCrudComponent } from './views/aluno-crud/aluno-crud.component';
import { AlunoUpdateComponent } from './components/aluno/aluno-update/aluno-update.component';
import { AlunoReadComponent } from './components/aluno/aluno-read/aluno-read.component';
import { AlunoDeleteComponent } from './components/aluno/aluno-delete/aluno-delete.component';
import { AlunoCreateComponent } from './components/aluno/aluno-create/aluno-create.component';

const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "alunos",
    component: AlunoCrudComponent
  },
  {
    path: "alunos",
    component: AlunoCreateComponent
  },
  {
    path: "alunos",
    component: AlunoUpdateComponent
  },
  {
    path: "alunos",
    component: AlunoReadComponent
  },
  {
    path: "alunos",
    component: AlunoDeleteComponent
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
