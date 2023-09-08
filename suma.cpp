#include<stdio.h>
#include<math.h>
#include<iostream>
#include<conio.h>

float x, y, temp;

void main() 
{
    printf("Por favor, ingrese el valor de x: ");
    scanf("%lf", &x);

    printf("Por favor, ingrese el valor de y: ");
    scanf("%lf", &y);
    x++; // Incremento de x en 1
    y--; // Decremento de y en 1

    printf("El valor de x es: %lf\n", x);
    printf("El valor de y es: %lf\n", y);

    return 0;
}
