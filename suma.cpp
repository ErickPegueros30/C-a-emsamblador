#include<stdio.h>
#include<math.h>
#include<iostream>
#include<conio.h>

float x26,suma, b,c,d;

void main() // Funcion principal
{
    //a=(3+5)*8-(10-4)/2;
    //b=8;
    //printf("\tValor de \n c = ");
    //scanf("%f",&c);
    //printf ("El valor de es: ", %a);
    /*if (1==1)
    {
        if (1==1)
            if (2==2)
                if (3==3)
                    if (4==4)
                        printf("1 == 2");
    }*/
     // Declarar variables para almacenar los números

    // Solicitar al usuario que ingrese el primer número
    printf("Ingrese el primer número: ");
    scanf("%lf", &x26);

    // Solicitar al usuario que ingrese el segundo número

    // Calcular la suma de los dos números
    suma=x26+1;

    // Mostrar el resultado
    printf("La suma de %.2lf \n", suma);

    suma++;

    printf("El resultado %.2lf \n",suma);

    return 0;
}
