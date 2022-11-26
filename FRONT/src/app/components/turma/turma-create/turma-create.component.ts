import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Turma } from 'src/app/models/Turma';
import { TurmaService } from './../turma.service';

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

    constructor(private turmaService: TurmaService,
      private router: Router) { }
    
    ngOnInit(): void {
    }

  criarTurma(): void {
    console.log(this.horario)
    let turma: Turma = {
      codigoTurma: this.codigoTurma,
      professorCpf:  this.professorCpf,
      disciplina: this.disciplina,
      horario: this.horario,
      valor: this.valor
    }
    console.log(turma)
    this.turmaService.create(turma).subscribe(() => {
      this.turmaService.showMessage('Turma criada!')
      this.router.navigate(['/turmas'])
    })
  }

}
