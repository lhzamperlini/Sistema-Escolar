import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'

@Component({
  selector: 'app-aluno-crud',
  templateUrl: './aluno-crud.component.html',
  styleUrls: ['./aluno-crud.component.css']
})
export class AlunoCrudComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToAlunoCreate(): void {
    this.router.navigate(['/alunos/create'])
  }

}
