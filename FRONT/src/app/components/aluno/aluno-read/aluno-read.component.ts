import { Component, OnInit } from '@angular/core';
import { Aluno } from 'src/app/models/Aluno';
import { AlunoService } from '../aluno.service';

@Component({
  selector: 'app-aluno-read',
  templateUrl: './aluno-read.component.html',
  styleUrls: ['./aluno-read.component.css']
})
export class AlunoReadComponent implements OnInit {

  alunos!: Aluno[]
  displayedColumns = ['id', 'nome', 'cpf', 'rgm', 'email', 'telefone', 'nascimento', 'notaUm', 'notaDois', 'notaTres', 'media', 'action']
  
  constructor(private alunoService: AlunoService) { }

  ngOnInit(): void {
    this.alunoService.read().subscribe(alunos => {
      this.alunos = alunos
    })
    console.log(`Alunos: ${this.alunos}`)
  }

}

