import { Component, OnInit } from '@angular/core';
import { TurmaService } from '../turma.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Turma } from 'src/app/models/Turma';

@Component({
  selector: 'app-turma-update',
  templateUrl: './turma-update.component.html',
  styleUrls: ['./turma-update.component.css']
})
export class TurmaUpdateComponent implements OnInit {

  turma!: Turma;

  constructor(
    private turmaService: TurmaService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')!
    this.turmaService.readById(id).subscribe(turma => {
      this.turma = turma
    })
  }

  updateTurma(): void {
    this.turmaService.update(this.turma).subscribe(() => {
      this.turmaService.showMessage('Turma alterada com sucesso')
      this.router.navigate(['/turmas']);
    })
  }

  cancel(): void {
    this.router.navigate(['/turmas']);
  }

}
