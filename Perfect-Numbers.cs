using System;
class NumeroB
{
    static int chiffre = 1; //variable pour énumérer les nombres parfaits

    static void afficher(int nombre)
    {
        Console.Write("{0}) {1} = 1 ", chiffre, nombre);    //affiche 1) nombre(paramètre) =  1
        chiffre++;
        for (int i = 2; i < nombre; i++)    //à partir de deux on parcourre
        {
            if ((nombre % i) == 0)
                Console.Write("+ {0} ", i); //affiche + valeur(diviseur)
        }
        Console.WriteLine();    //saute de ligne            
    }
    static void nbParfait(int nombre)
    {
        int i, somme = 0;
        for (i = 1; i <= nombre; i++)
        {
            for (int j = i-1; j > 0; j--)   //boucle pour annalyser les diviseurs de i
            {
                if ((i % j) == 0)
                    somme += j; //si j est diviseur on l'ajoute à la somme                    
            }   //fin de la boucle j
            if (i == somme)
            {   //si la somme est egal à la chiffre annalysé, cette chiffre est un nombre parfait
                somme = 0;
                afficher(i);
            }
            somme = 0;
        }
    }

    static void Main(string[] args)
    {
        nbParfait(1000);
        Console.ReadLine();
    }
}
/*Execution:
1) 6 =  1 + 2 + 3
2) 28 =  1 + 2 + 4 + 7 + 14
3) 496 =  1 + 2 + 4 + 8 + 16 + 31 + 62 + 124 + 248
*/
