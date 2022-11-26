import { error } from '@angular/compiler/src/util';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable, throwError } from 'rxjs';
import { Turma } from 'src/app/models/Turma';
import { catchError, map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})

export class TurmaService {
    baseUrl = "https://localhost:5001/api/turma"

    constructor(private snackBar: MatSnackBar,
        private http: HttpClient) { }

        ErrorHandler(error : HttpErrorResponse) : Observable<any> {
            this.showMessage(`Ocorreu um erro! ${error.message}`, true)
            return EMPTY
          }
    
        showMessage(msg: string, isError: boolean = false): void {
        this.snackBar.open(msg, 'X', {
          duration: 3000,
          horizontalPosition: "right",
          verticalPosition: "top",
          panelClass: isError ? ['msg-error'] : ['msg-sucess']
        })
      }
    
      create(turma: Turma): Observable<Turma> {
        const url = `${this.baseUrl}/cadastrar`
        return this.http.post<Turma>(url, turma).pipe(
          map(obj => obj),
          catchError(e => this.ErrorHandler(e))
        );
      }

      read(): Observable<Turma[]> {
        const url = `${this.baseUrl}/listar`
        return this.http.get<Turma[]>(url).pipe(
          map(obj => obj),
          catchError(e => this.ErrorHandler(e))
        );
      }

      readById(id: string): Observable<Turma> {
        const url = `${this.baseUrl}/buscar/${id}`
        return this.http.get<Turma>(url).pipe(
          map(obj => obj),
          catchError(e => this.ErrorHandler(e))
        );
      }

      update(turma: Turma): Observable<Turma> {
        const url = `${this.baseUrl}/alterar`
        return this.http.patch<Turma>(url, turma).pipe(
          map(obj => obj),
          catchError(e => this.ErrorHandler(e))
        );
      }

      delete(id: number): Observable<Turma> {
        const url = `${this.baseUrl}/deletar/${id}`;
        return this.http.delete<Turma>(url).pipe(
          map(obj => obj),
          catchError(e => this.ErrorHandler(e))
        );
      }

}