import { Router } from '@angular/router';
import { TurmaService } from './../../turma/turma.service';
import { AlunoService } from './../../aluno/aluno.service';
import { BoletimService } from './../boletim.service';
import { Component, OnInit } from '@angular/core';
import { Turma } from 'src/app/models/Turma';
import { Aluno } from 'src/app/models/Aluno';
import { Boletim } from 'src/app/models/Boletim';

@Component({
  selector: 'app-boletim-create',
  templateUrl: './boletim-create.component.html',
  styleUrls: ['./boletim-create.component.css']
})
export class BoletimCreateComponent implements OnInit {

  turmas!: Turma[]
  alunos!: Aluno[]
  codigoTurma!: number
  alunoCpf!: string
  notaUm!: string
  notaDois!: string
  notaTres!: string
  media!: string
 
  constructor(private boletimService: BoletimService, private alunoService: AlunoService,
    private turmaService: TurmaService, private router: Router) { }

    ngOnInit(): void {
      this.alunoService.read().subscribe(alunos => {
        this.alunos = alunos
      })
      this.turmaService.read().subscribe(turmas => {
        this.turmas = turmas
      })
    }
  
  createBoletim(): void {
    let boletim: Boletim = {
      codigoTurma: this.codigoTurma,
      alunoCpf: this.alunoCpf,
      notaUm: this.notaUm,
      notaDois: this.notaDois,
      notaTres: this.notaTres,
      media: this.media
    }
    this.boletimService.create(boletim).subscribe(() => {
      this.boletimService.showMessage('Boletim Criado')
      this.router.navigate(['/boletins'])
    })
  }

  cancel(): void {
    this.router.navigate(['/boletins'])
  }

}
