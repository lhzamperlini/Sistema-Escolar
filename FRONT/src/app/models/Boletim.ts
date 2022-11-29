import { Professor } from "../components/professor/professor.model";
import { Turma } from "./Turma"
import { Aluno } from "./Aluno"

export interface Boletim {
    id?: number
    codigoTurma: number
    turma?: Turma
    alunoCpf: string
    aluno?: Aluno
    notaUm: string
    notaDois: string
    notaTres: string
    media: string
}