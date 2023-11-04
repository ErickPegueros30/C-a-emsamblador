; Autor: Erick Jaimes Pegueros
;sábado, 4 de noviembre de 2023 12:14:11 p. m.
include 'emu8086.inc'
org 100h
MOV AX, 3
PUSH AX
MOV AX, 5
PUSH AX
POP BX
POP AX
ADD AX, BX
PUSH AX
MOV AX, 8
PUSH AX
POP BX
POP AX
MUL  BX
PUSH AX
MOV AX, 10
PUSH AX
MOV AX, 4
PUSH AX
POP BX
POP AX
SUB AX, BX
PUSH AX
MOV AX, 2
PUSH AX
POP BX
POP AX
DIV  BX
PUSH AX
POP BX
POP AX
SUB AX, BX
PUSH AX
POP AX
; Asignacion k
MOV k, AX
print ''
printn '' 
print 'Altura: '
call scan_num
mov altura,cx
printn ''
print ''
printn '' 
print 'for:'
printn '' 
print ''
; For: 1
MOV AX, 1
PUSH AX
POP AX
; Asignacion i
MOV i, AX
InicioFor1:
MOV AX, i
PUSH AX
MOV AX, altura
PUSH AX
POP BX
POP AX
CMP AX, BX
JA FinFor1
; For: 2
MOV AX, 250
PUSH AX
POP AX
; Asignacion j
MOV j, AX
InicioFor2:
MOV AX, j
PUSH AX
MOV AX, 250
PUSH AX
MOV AX, i
PUSH AX
POP BX
POP AX
ADD AX, BX
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinFor2
; if: 1
MOV AX, j
PUSH AX
MOV AX, 2
PUSH AX
POP BX
POP AX
DIV  BX
PUSH DX
MOV AX, 0
PUSH AX
POP BX
POP AX
CMP AX, BX
JNE Else1
print '-'
JMP If1
; else: 2
Else1:
print '+'
If1:
INC j
JMP InicioFor2
FinFor2:
print ''
printn '' 
print ''
INC i
JMP InicioFor1
FinFor1:
print ''
printn '' 
print 'while:'
printn '' 
print ''
MOV AX, 1
PUSH AX
POP AX
; Asignacion i
MOV i, AX
; While: 1
InicioWhile1:
MOV AX, i
PUSH AX
MOV AX, altura
PUSH AX
POP BX
POP AX
CMP AX, BX
JA FinWhile1
MOV AX, 250
PUSH AX
POP AX
; Asignacion j
MOV j, AX
; While: 2
InicioWhile2:
MOV AX, j
PUSH AX
MOV AX, 250
PUSH AX
MOV AX, i
PUSH AX
POP BX
POP AX
ADD AX, BX
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinWhile2
; if: 16
MOV AX, j
PUSH AX
MOV AX, 2
PUSH AX
POP BX
POP AX
DIV  BX
PUSH DX
MOV AX, 0
PUSH AX
POP BX
POP AX
CMP AX, BX
JNE Else16
print '-'
JMP If16
; else: 17
Else16:
print '+'
If16:
POP AX
; Incremento j
MOV AX,j
INC AX
MOV j, AX
JMP InicioWhile2
FinWhile2:
POP AX
; Incremento i
MOV AX,i
INC AX
MOV i, AX
print ''
printn '' 
print ''
JMP InicioWhile1
FinWhile1:
print ''
printn '' 
print 'do:'
printn '' 
print ''
MOV AX, 1
PUSH AX
POP AX
; Asignacion i
MOV i, AX
; Do: 1
InicioDo1:
MOV AX, 250
PUSH AX
POP AX
; Asignacion j
MOV j, AX
; Do: 2
InicioDo2:
; if: 31
MOV AX, j
PUSH AX
MOV AX, 2
PUSH AX
POP BX
POP AX
DIV  BX
PUSH DX
MOV AX, 0
PUSH AX
POP BX
POP AX
CMP AX, BX
JNE Else31
print '-'
JMP If31
; else: 32
Else31:
print '+'
If31:
POP AX
; Incremento j
MOV AX,j
INC AX
MOV j, AX
MOV AX, j
PUSH AX
MOV AX, 250
PUSH AX
MOV AX, i
PUSH AX
POP BX
POP AX
ADD AX, BX
PUSH AX
POP BX
POP AX
CMP AX, BX
JAE FinDo2
JMP InicioDo2
FinDo2:
POP AX
; Incremento i
MOV AX,i
INC AX
MOV i, AX
print ''
printn '' 
print ''
MOV AX, i
PUSH AX
MOV AX, altura
PUSH AX
POP BX
POP AX
CMP AX, BX
JA FinDo1
JMP InicioDo1
FinDo1:
INT 20h
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
