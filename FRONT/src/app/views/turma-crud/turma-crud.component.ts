import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-turma-crud',
  templateUrl: './turma-crud.component.html',
  styleUrls: ['./turma-crud.component.css']
})
export class TurmaCrudComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToTurmaCreate(): void {
    this.router.navigate(['/turmas/criar'])
  }

}
