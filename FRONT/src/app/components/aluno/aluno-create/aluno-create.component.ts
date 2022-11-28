import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Aluno } from 'src/app/models/Aluno';
import { AlunoService } from '../aluno.service';

@Component({
  selector: 'app-aluno-create',
  templateUrl: './aluno-create.component.html',
  styleUrls: ['./aluno-create.component.css']
})
export class AlunoCreateComponent implements OnInit {

    nome!: string
    cpf!: string
    rgm!: string
    email!: string
    telefone!: string
    nascimento!: string

    constructor(private alunoService: AlunoService,
      private router: Router) { }
    
    ngOnInit(): void {
    }

  createAluno(): void {
    let aluno: Aluno = {
      nome: this.nome,
      cpf: this.cpf,
      rgm: this.rgm,
      email: this.email,
      telefone: this.telefone,
      nascimento: this.nascimento
    }
    this.alunoService.create(aluno).subscribe(() => {
      this.alunoService.showMessage('Aluno criado!')
      this.router.navigate(['/alunos'])
    })
 
  }

  cancel(): void {
    this.router.navigate(['/alunos'])
  }

}


