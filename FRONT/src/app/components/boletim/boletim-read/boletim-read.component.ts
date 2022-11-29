import { BoletimService } from './../boletim.service';
import { Component, OnInit } from '@angular/core';
import { Boletim } from 'src/app/models/Boletim';

@Component({
  selector: 'app-boletim-read',
  templateUrl: './boletim-read.component.html',
  styleUrls: ['./boletim-read.component.css']
})
export class BoletimReadComponent implements OnInit {

  boletins!: Boletim[]
  displayedColumns = ['id', 'codigoTurma', 'cpfAluno', 'disciplina', 'notaUm', 'notaDois', 'notaTres', 'media']

  constructor(private boletimService: BoletimService) { }

  ngOnInit(): void {
    this.boletimService.read().subscribe(boletins => {
      this.boletins = boletins
    })
  }

}
