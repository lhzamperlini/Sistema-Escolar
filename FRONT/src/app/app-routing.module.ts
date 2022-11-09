import { ProfessorDeleteComponent } from './components/professor/professor-delete/professor-delete.component';
import { ProfessorUpdateComponent } from './components/professor/professor-update/professor-update.component';
import { ProfessorCreateComponent } from './components/professor/professor-create/professor-create.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './views/home/home.component';
import { ProfessorCrudComponent } from './views/professor-crud/professor-crud.component';

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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
