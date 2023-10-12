; Autor: Guillermo Fernandez Romero
; Fecha: 3-Mayo-2023
include 'emu8086.inc'
org 100h
; For: 1
MOV AX, 0
PUSH AX
POP AX
; Asignacion i
MOV i, AX
InicioFor1:
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP BX, AX
JAE FinFor1
INC i
POP AX
; Asignacion k
MOV k, AX
JMP InicioFor1
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP BX, AX
JAE FinFor1
INC i
POP AX
; Asignacion k
MOV k, AX
JMP InicioFor1
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP BX, AX
JAE FinFor1
INC i
POP AX
; Asignacion k
MOV k, AX
JMP InicioFor1
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP BX, AX
JAE FinFor1
INC i
POP AX
; Asignacion k
MOV k, AX
JMP InicioFor1
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP BX, AX
JAE FinFor1
INC i
POP AX
; Asignacion k
MOV k, AX
JMP InicioFor1
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP BX, AX
JAE FinFor1
INC i
POP AX
; Asignacion k
MOV k, AX
JMP InicioFor1
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP BX, AX
JAE FinFor1
INC i
POP AX
; Asignacion k
MOV k, AX
JMP InicioFor1
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP BX, AX
JAE FinFor1
INC i
POP AX
; Asignacion k
MOV k, AX
JMP InicioFor1
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP BX, AX
JAE FinFor1
INC i
POP AX
; Asignacion k
MOV k, AX
JMP InicioFor1
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP BX, AX
JAE FinFor1
INC i
POP AX
; Asignacion k
MOV k, AX
JMP InicioFor1
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP BX, AX
JAE FinFor1
INC i
POP AX
; Asignacion k
MOV k, AX
JMP InicioFor1
FinFor1:
int 20h
RET
define_scan_num
define_print_num
define_print_num_uns
; V a r i a b l e s
altura dw 0h
i dw 0h
j dw 0h
k dw 0h
END
