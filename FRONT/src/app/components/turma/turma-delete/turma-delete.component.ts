import { Component, OnInit } from '@angular/core';
import { TurmaService } from '../turma.service';
import { Turma } from 'src/app/models/Turma';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-turma-delete',
  templateUrl: './turma-delete.component.html',
  styleUrls: ['./turma-delete.component.css']
})
export class TurmaDeleteComponent implements OnInit {

  turma!: Turma
  constructor(
    private turmaService: TurmaService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')!
    this.turmaService.readById(id).subscribe(turma => {
      this.turma = turma
      console.log(turma)
    })
  }

  deleteTurma(): void {
    this.turmaService.delete(this.turma.id!).subscribe(() => {
      this.turmaService.showMessage('Turma Excluida com sucesso!')
      this.router.navigate(['/turmas'])
    })
  }

  cancel(): void {
    this.router.navigate(['/turmas'])
  }
}
