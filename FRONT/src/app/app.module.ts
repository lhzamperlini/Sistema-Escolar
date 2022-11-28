
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule }from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';

import { HeaderComponent } from './components/template/header/header.component';
import { HomeComponent } from './views/home/home.component';
import { NavComponent } from './components/template/nav/nav.component';
import { FooterComponent } from './components/template/footer/footer.component';

import { ProfessorCrudComponent } from './views/professor-crud/professor-crud.component';
import { ProfessorCreateComponent } from './components/professor/professor-create/professor-create.component';
import { ProfessorReadComponent } from './components/professor/professor-read/professor-read.component';
import { ProfessorUpdateComponent } from './components/professor/professor-update/professor-update.component';
import { ProfessorDeleteComponent } from './components/professor/professor-delete/professor-delete.component';
import { TurmaCreateComponent } from './components/turma/turma-create/turma-create.component';
import { TurmaReadComponent } from './components/turma/turma-read/turma-read.component';
import { TurmaUpdateComponent } from './components/turma/turma-update/turma-update.component';
import { TurmaDeleteComponent } from './components/turma/turma-delete/turma-delete.component';
import { TurmaCrudComponent } from './views/turma-crud/turma-crud.component';
import { AlunoCreateComponent } from './components/aluno/aluno-create/aluno-create.component';
import { AlunoDeleteComponent } from './components/aluno/aluno-delete/aluno-delete.component';
import { AlunoCrudComponent } from './views/aluno-crud/aluno-crud.component';
import { AlunoReadComponent } from "./components/aluno/aluno-read/aluno-read.component"; 
import { AlunoUpdateComponent } from './components/aluno/aluno-update/aluno-update.component';



@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        FooterComponent,
        NavComponent,
        HomeComponent,
        ProfessorCrudComponent,
        ProfessorCreateComponent,
        ProfessorReadComponent,
        //ProfessorRead2Component,
        ProfessorUpdateComponent,
        ProfessorDeleteComponent,
        TurmaReadComponent,
        TurmaCreateComponent,
        TurmaReadComponent,
        TurmaUpdateComponent,
        TurmaDeleteComponent,
        TurmaCrudComponent,
        AlunoCreateComponent,
        AlunoDeleteComponent,
        AlunoCrudComponent,
        AlunoReadComponent,
        AlunoUpdateComponent,
    ],
    providers: [],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        MatToolbarModule,
        MatSidenavModule,
        MatListModule,
        MatCardModule,
        MatButtonModule,
        MatSnackBarModule,
        HttpClientModule,
        FormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatTableModule,
        MatPaginatorModule,
        MatSortModule,
        MatSelectModule
    ]
})
export class AppModule { }
