import { Professor } from './../components/professor/professor.model';
export interface Turma {
    id?: number
    codigoTurma: number
    professorCpf: string
    disciplina: string
    horario: Date
    valor: number
    professorId: string
    prefessor?: Professor
}