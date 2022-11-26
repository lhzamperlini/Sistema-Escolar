import { ConditionalExpr } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Turma } from 'src/app/models/Turma';
import { TurmaService } from './../turma.service';

@Component({
  selector: 'app-turma-read',
  templateUrl: './turma-read.component.html',
  styleUrls: ['./turma-read.component.css']
})
export class TurmaReadComponent implements OnInit {

  turmas!: Turma[]
  displayedColumns = ['id', 'codigoTurma', 'professor', 'disciplina', 'horario', 'valor' ,'action']

  constructor(private turmaService: TurmaService) { }

  ngOnInit(): void {
    this.turmaService.read().subscribe(turmas => {
      this.turmas = turmas
    })
    console.log(`Turmas: ${this.turmas}`)
  }

}
