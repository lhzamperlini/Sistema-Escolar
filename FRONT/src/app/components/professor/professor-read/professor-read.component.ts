import { ProfessorService } from './../professor.service';
import { Component, OnInit } from '@angular/core';
import { Professor } from '../professor.model';

@Component({
  selector: 'app-professor-read',
  templateUrl: './professor-read.component.html',
  styleUrls: ['./professor-read.component.css']
})
export class ProfessorReadComponent implements OnInit {

  professores!: Professor[]
  displayedColumns = ['id', 'name', 'cpf', 'email', 'phone', 'action']
  
  constructor(private professorService: ProfessorService) { }

  ngOnInit(): void {
    this.professorService.read().subscribe(professores => {
      this.professores = professores
    })
  }

}
