import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'

@Component({
  selector: 'app-professor-crud',
  templateUrl: './professor-crud.component.html',
  styleUrls: ['./professor-crud.component.css']
})
export class ProfessorCrudComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToProfessorCreate(): void {
    this.router.navigate(['/professores/create'])
  }

}
