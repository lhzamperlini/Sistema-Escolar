
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { AlunoService } from '../aluno.service';
import { Aluno } from 'src/app/models/Aluno';

@Component({
  selector: 'app-aluno-update',
  templateUrl: './aluno-update.component.html',
  styleUrls: ['./aluno-update.component.css']
})
export class AlunoUpdateComponent implements OnInit {

  aluno!: Aluno;

  constructor(
    private alunoService: AlunoService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')!
    this.alunoService.readById(id).subscribe(aluno => {
      this.aluno = aluno
    })
  }

  updateAluno(): void {
    this.alunoService.update(this.aluno).subscribe(() => {
      this.alunoService.showMessage('Aluno alterado com sucesso')
      this.router.navigate(['/alunos']);
    })
  }

  cancel(): void {
    this.router.navigate(['/alunos']);
  }

}


