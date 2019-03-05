using System;
/*Jorge Leonardo Trujillo Salas
  TRUJ12059003*/
class NumeroA
{
    static void Main(string[] args)
    {
        const int immeuble = 7;
        int i = 1, compPriv = 0, compComme = 0;
        char type;
        double taxFonc, sommePrivee = 0, evalMunicip = 0, minEval = double.MaxValue;
        //Boucle pour traiter 7 immeubles
        do
        {
            Console.WriteLine("Entrez le type de l'immeuble # {0}", i);
            type= Console.ReadLine().ToUpper()[0];  //on transforme en majuscule la première lettre saisie
            if (type == 'C' || type == 'P')
            {
                i++;    //i affiche le numero de l'immeuble
                Console.WriteLine("Entrez le montant de l’évaluation municipale");
                evalMunicip = double.Parse(System.Console.ReadLine());
                Console.WriteLine("Entrez l’année de construction");
                int anne = int.Parse(System.Console.ReadLine());
                if (type == 'C')
                {   //s'il est de type commerce
                    compComme++;
                    taxFonc = evalMunicip * 0.0325;
                    Console.WriteLine("\nC’est une résidence commercial construite en {0} dont\nl’évaluation municipale est de {1:F2}$ et la\ntaxe foncière est de {2:F2}$\n", anne, evalMunicip, taxFonc);
                }
                else
                {   //s'il est de type privé
                    compPriv++;
                    sommePrivee += evalMunicip; //on ajoute à la somme des résidences privées
                    taxFonc = evalMunicip * 0.015;
                    Console.WriteLine("\nC’est une résidence privée construite en {0} dont\nl’évaluation municipale est de {1:F2}$ et la\ntaxe foncière est de {2:F2}$\n", anne, evalMunicip, taxFonc);
                }        
            }
            else    //si la lettre saisie ne pas 'P' ou 'C', on ne le compte pas et on demande de saisir de nouveau
                Console.WriteLine("{0} n'est pas un bon choix, sélectionnez le type entre 'C' et 'P'",type);
        if (minEval > evalMunicip)  //on verifie le valeur minimum
        {
            minEval = evalMunicip;
        }
    } while (i <= immeuble);
    Console.WriteLine("Nombre de résidences privées traitées: {0}\n", compPriv);
    Console.WriteLine("Le prix moyen évalué par la ville (avant taxes) des résidences privées: {0:F2}\n", sommePrivee/ compPriv);
    Console.WriteLine("Le prix le plus faible évalué: {0:F2}\n",minEval);
    Console.ReadLine();
    }
}


/*Execution:
Entrez le type de l'immeuble # 1
c
Entrez le montant de l'évaluation municipale
654321.00
Entrez l'année de construction
2000

C'est une résidence commercial construite en 2000 dont
l'évaluation municipale est de 654321.00$ et la
taxe foncière est de 21265.43$

Entrez le type de l'immeuble # 2
Z
Z n'est pas un bon choix, sélectionnez le type entre 'C' et 'P'
Entrez le type de l'immeuble # 2
P
Entrez le montant de l'évaluation municipale
345678.90
Entrez l'année de construction
1950

C'est une résidence privée construite en 1950 dont
l'évaluation municipale est de 345678.90$ et la
taxe foncière est de 5185.18$

Entrez le type de l'immeuble # 3
C
Entrez le montant de l'évaluation municipale
850000.75
Entrez l'année de construction
1989

C'est une résidence commercial construite en 1989 dont
l'évaluation municipale est de 850000.75$ et la
taxe foncière est de 27625.02$

Entrez le type de l'immeuble # 4
P
Entrez le montant de l'évaluation municipale
600000.00
Entrez l'année de construction
2012

C'est une résidence privée construite en 2012 dont
l'évaluation municipale est de 600000.00$ et la
taxe foncière est de 9000.00$

Entrez le type de l'immeuble # 5
P
Entrez le montant de l'évaluation municipale
512600.00
Entrez l'année de construction
1986

C'est une résidence privée construite en 1986 dont
l'évaluation municipale est de 512600.00$ et la
taxe foncière est de 7689.00$

Entrez le type de l'immeuble # 6
P
Entrez le montant de l'évaluation municipale
545200.00
Entrez l'année de construction
1968

C'est une résidence privée construite en 1968 dont
l'évaluation municipale est de 545200.00$ et la
taxe foncière est de 8178.00$

Entrez le type de l'immeuble # 7
P
Entrez le montant de l'évaluation municipale
456876.00
Entrez l'année de construction
2008

C'est une résidence privée construite en 2008 dont
l'évaluation municipale est de 456876.00$ et la
taxe foncière est de 6853.14$

Nombre de résidences privées traitées: 5

Le prix moyen évalué par la ville (avant taxes) des résidences privées: 492070.98

Le prix le plus faible évalué: 345678.90
*/