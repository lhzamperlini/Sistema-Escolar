import { Router, ActivatedRoute } from '@angular/router';
import { ProfessorService } from './../professor.service';
import { Professor } from './../professor.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-professor-delete',
  templateUrl: './professor-delete.component.html',
  styleUrls: ['./professor-delete.component.css']
})
export class ProfessorDeleteComponent implements OnInit {

  professor!: Professor;

  constructor(
    private professorService: ProfessorService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')!
    this.professorService.readById(id).subscribe(professor => {
      this.professor = professor
    })
  }

  deleteProfessor(): void {
    this.professorService.delete(this.professor.id!).subscribe(() => {
      this.professorService.showMessage('Professor Excluido com sucesso!')
      this.router.navigate(['/professores'])
    })
  }

  cancel(): void {
    this.router.navigate(['/professores'])
  }
}
