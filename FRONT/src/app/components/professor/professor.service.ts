import { error } from '@angular/compiler/src/util';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable, throwError } from 'rxjs';
import { Professor } from './professor.model';

import { catchError, map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {

  baseUrl = "https://localhost:5001/api/professor"

  constructor(private snackBar: MatSnackBar,
    private http: HttpClient) { }

  showMessage(msg: string, isError: boolean = false): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: isError ? ['msg-error'] : ['msg-sucess']
    })
  }

  create(professor: Professor): Observable<Professor> {
    const url = `${this.baseUrl}/cadastrar`
    return this.http.post<Professor>(url, professor).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  read(): Observable<Professor[]> {
    const url = `${this.baseUrl}/listar`
    return this.http.get<Professor[]>(url).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  readById(id: string): Observable<Professor> {
    const url = `${this.baseUrl}/buscarid/${id}`
    return this.http.get<Professor>(url).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  update(professor: Professor): Observable<Professor> {
    const url = `${this.baseUrl}/alterar`
    return this.http.patch<Professor>(url, professor).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  delete(id: number): Observable<Professor> {
    const url = `${this.baseUrl}/deletar/${id}`;
    return this.http.delete<Professor>(url).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  ErrorHandler(error : HttpErrorResponse) : Observable<any> {
    if (error.status == 400) {
      this.showMessage(`${error.error}`, true)
      console.log(error)
    } else if(error.status == 0) {
      this.showMessage('A API utilizada na aplicação aparenta não estar recebendo resquisiçoes', true)
    }
    return EMPTY
  }
}