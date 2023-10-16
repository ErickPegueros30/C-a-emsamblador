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
MOV AX, i
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor1
MOV AX, i
PUSH AX
POP AX
; Asignacion k
MOV k, AX
; For: 2
MOV AX, 0
PUSH AX
POP AX
; Asignacion j
MOV j, AX
InicioFor2:
MOV AX, j
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor2
INC j
JMP InicioFor2
INC j
JMP InicioFor2
INC j
JMP InicioFor2
INC j
JMP InicioFor2
INC j
JMP InicioFor2
INC j
JMP InicioFor2
INC j
JMP InicioFor2
INC j
JMP InicioFor2
INC j
JMP InicioFor2
INC j
JMP InicioFor2
INC j
JMP InicioFor2
FinFor2:
INC i
JMP InicioFor1
POP AX
; Asignacion k
MOV k, AX
; For: 3
POP AX
; Asignacion j
MOV j, AX
MOV AX, j
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor3
FinFor3:
INC i
JMP InicioFor1
POP AX
; Asignacion k
MOV k, AX
; For: 4
POP AX
; Asignacion j
MOV j, AX
MOV AX, j
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor4
FinFor4:
INC i
JMP InicioFor1
POP AX
; Asignacion k
MOV k, AX
; For: 5
POP AX
; Asignacion j
MOV j, AX
MOV AX, j
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor5
FinFor5:
INC i
JMP InicioFor1
POP AX
; Asignacion k
MOV k, AX
; For: 6
POP AX
; Asignacion j
MOV j, AX
MOV AX, j
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor6
FinFor6:
INC i
JMP InicioFor1
POP AX
; Asignacion k
MOV k, AX
; For: 7
POP AX
; Asignacion j
MOV j, AX
MOV AX, j
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor7
FinFor7:
INC i
JMP InicioFor1
POP AX
; Asignacion k
MOV k, AX
; For: 8
POP AX
; Asignacion j
MOV j, AX
MOV AX, j
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor8
FinFor8:
INC i
JMP InicioFor1
POP AX
; Asignacion k
MOV k, AX
; For: 9
POP AX
; Asignacion j
MOV j, AX
MOV AX, j
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor9
FinFor9:
INC i
JMP InicioFor1
POP AX
; Asignacion k
MOV k, AX
; For: 10
POP AX
; Asignacion j
MOV j, AX
MOV AX, j
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor10
FinFor10:
INC i
JMP InicioFor1
POP AX
; Asignacion k
MOV k, AX
; For: 11
POP AX
; Asignacion j
MOV j, AX
MOV AX, j
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor11
FinFor11:
INC i
JMP InicioFor1
POP AX
; Asignacion k
MOV k, AX
; For: 12
POP AX
; Asignacion j
MOV j, AX
MOV AX, j
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor12
FinFor12:
INC i
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
