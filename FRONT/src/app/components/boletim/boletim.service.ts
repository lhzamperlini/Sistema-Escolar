import { Boletim } from 'src/app/models/Boletim';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { EMPTY, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BoletimService {

  baseUrl = "https://localhost:5001/api/boletim"

  constructor(private snackBar: MatSnackBar, private router: Router, private http: HttpClient) { }

  showMessage(msg: string, isError: boolean = false): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: isError ? ['msg-error'] : ['msg-sucess']
    })
  }

  create(boletim: Boletim): Observable<Boletim> {
    const url = `${this.baseUrl}/cadastrar`
    return this.http.post<Boletim>(url, boletim).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  read(): Observable<Boletim[]> {
    const url = `${this.baseUrl}/listar`
    return this.http.get<Boletim[]>(url).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  readById(id: string): Observable<Boletim> {
    const url = `${this.baseUrl}/buscarid/${id}`
    return this.http.get<Boletim>(url).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  update(boletim: Boletim): Observable<Boletim> {
    const url = `${this.baseUrl}/alterar`
    return this.http.patch<Boletim>(url, boletim).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  delete(id: number): Observable<Boletim> {
    const url = `${this.baseUrl}/deletar/${id}`;
    return this.http.delete<Boletim>(url).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  ErrorHandler(error : HttpErrorResponse) : Observable<any> {
    if (error.status == 400) {
      this.showMessage(`${error.error.errors.Nome}`, true)
      this.showMessage(`${error.error.errors.Cpf}`, true)
      console.log(error)
    } else if(error.status == 0) {
      this.showMessage('A API utilizada na aplicação aparenta não estar recebendo resquisiçoes', true)
    }
    return EMPTY
  }

}
