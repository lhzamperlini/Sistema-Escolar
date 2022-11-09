import { Professor } from './../professor.model';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfessorService } from './../professor.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-professor-update',
  templateUrl: './professor-update.component.html',
  styleUrls: ['./professor-update.component.css']
})
export class ProfessorUpdateComponent implements OnInit {

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

  updateProfessor(): void {
    this.professorService.update(this.professor).subscribe(() => {
      this.professorService.showMessage('Professor alterado com sucesso')
      this.router.navigate(['/professores']);
    })
  }

  cancel(): void {
    this.router.navigate(['/professores']);
  }

}
