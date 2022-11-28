import { Professor } from './../../professor/professor.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Turma } from 'src/app/models/Turma';
import { TurmaService } from './../turma.service';
import { ProfessorService } from '../../professor/professor.service';

@Component({
  selector: 'app-turma-create',
  templateUrl: './turma-create.component.html',
  styleUrls: ['./turma-create.component.css']
})
export class TurmaCreateComponent implements OnInit {

  codigoTurma!: number
  professorCpf!: string
  disciplina!: string
  horario!: Date
  valor!: number
  professores!: Professor[];
  professorId!: string;

  constructor(private turmaService: TurmaService, private professorService: ProfessorService,
    private router: Router) { }

  ngOnInit(): void {
    this.professorService.read().subscribe(professores => {
      this.professores = professores
    })
  }

  criarTurma(): void {
    console.log(this.horario)
    let turma: Turma = {
      codigoTurma: this.codigoTurma,
      professorCpf: this.professorCpf,
      disciplina: this.disciplina,
      horario: this.horario,
      valor: this.valor,
      professorId: this.professorId
    }
    this.turmaService.create(turma).subscribe(() => {
      this.turmaService.showMessage('Turma criada!')
      this.router.navigate(['/turmas'])
    })
  }

  cancel(): void {
    this.router.navigate(['/turmas'])
  }

}
