import { Professor } from './../professor.model';
import { Router } from '@angular/router';
import { ProfessorService } from './../professor.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-professor-create',
  templateUrl: './professor-create.component.html',
  styleUrls: ['./professor-create.component.css']
})
export class ProfessorCreateComponent implements OnInit {

  professor: Professor = {
    nome: '',
    cpf: '',
    email: '',
    telefone: ''
  }

  constructor(private professorService: ProfessorService,
    private router: Router) { }

  ngOnInit(): void {
  }

  createProfessor(): void {
    this.professorService.create(this.professor).subscribe(() => {
      this.professorService.showMessage('Professor criado!')
      this.router.navigate(['/professores'])
    })
  }

  cancel(): void {
    this.router.navigate(['/professores'])
  }


}
