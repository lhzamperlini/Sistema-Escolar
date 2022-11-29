import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-boletim-crud',
  templateUrl: './boletim-crud.component.html',
  styleUrls: ['./boletim-crud.component.css']
})
export class BoletimCrudComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToBoletimCreate(): void {
    this.router.navigate(['/boletins/create'])
  }

}
