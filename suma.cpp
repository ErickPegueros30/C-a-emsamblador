#include<stdio.h>
#include<math.h>
#include<iostream>

char  a;
int   b,i,j;
float c;

void main() // Funcion principal
{
    c = 20;
    i = 0;
    printf("C = ");
    scanf ("%f", &c);
    a = (char)((char)(c) + (float)(b));

    if (c>=1)
    {
        printf("Hola");
        if (c==2)
        {
            printf(" a todos");
        }
        else if (c==3)
        {
            printf(" a nadie");

            for (i=0; i<10; i++)
            {
                printf(" Hola");
                for (j=0; j<2; j++)
                {
                    printf(" Adios");
                }
            }   
        }
        else if (c==4)
        {
            do 
            {
                printf(" \n Hola");
                i++;                
            } while (i < 10);

        }
        else
        {
            while (i<10)
            {
                printf("\n¿Como estas?");
                i++;
            }
        }
    }
    else
    {
        printf("mundo\n");
    }
}
