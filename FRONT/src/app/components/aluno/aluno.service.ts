import { error } from '@angular/compiler/src/util';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators'
import { Aluno } from 'src/app/models/Aluno';

@Injectable({
  providedIn: 'root'
})
export class AlunoService {

  baseUrl = "https://localhost:5001/api/aluno"

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

  create(aluno: Aluno): Observable<Aluno> {
    const url = `${this.baseUrl}/cadastrar`
    return this.http.post<Aluno>(url, aluno).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  read(): Observable<Aluno[]> {
    const url = `${this.baseUrl}/listar`
    return this.http.get<Aluno[]>(url).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  readById(id: string): Observable<Aluno> {
    const url = `${this.baseUrl}/buscarid/${id}`
    return this.http.get<Aluno>(url).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  update(aluno: Aluno): Observable<Aluno> {
    const url = `${this.baseUrl}/alterar`
    return this.http.patch<Aluno>(url, aluno).pipe(
      map(obj => obj),
      catchError(e => this.ErrorHandler(e))
    );
  }

  delete(id: number): Observable<Aluno> {
    const url = `${this.baseUrl}/deletar/${id}`;
    return this.http.delete<Aluno>(url).pipe(
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