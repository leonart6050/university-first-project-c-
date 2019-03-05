using System;
/*Jorge Leonardo Trujillo Salas
  TRUJ12059003*/
class NumeroC
{
    //Méthode pour afficher en mode de matrice (rangées et colonnes)
     static void affiche(int[] age, int[] cafe, double[] taille, char[] sexe, int borne)
     {            
        Console.WriteLine("Personne  Sexe    Age     Cafe    Taille");
        for (int i = 0; i < borne; i++)
            {
            Console.WriteLine("{0,3}){1,9}{2,8}{3,8}{4,10:F2}", i+1, sexe[i], age[i], cafe[i], taille[i]);
            }           
     }
    //Méthode générique permetant de échanger
    static void Permuter <T>( ref T[] tableau, int i, int indMin)
    {
        T tempo = tableau[i];
        tableau[i] = tableau[indMin];
        tableau[indMin] = tempo;
    }
    //Méthode trier tableau, on utilise le méthode apprise en classe
    static void trier(ref int[] age, ref int[] cafe, ref double[] taille, ref char[] sexe, int borne)
    {
        for (int i = 0; i < borne - 1; i++)
        {
            int indMin = i;
            for (int j = i + 1; j < borne; j++)            
                if (age[j] < age[indMin])
                    indMin = j;                
            if (indMin != i)
            {
                Permuter(ref age, i, indMin);
                Permuter(ref cafe, i, indMin);
                Permuter(ref taille, i, indMin);
                Permuter(ref sexe, i, indMin);
            }  
        }
    }
    //Méthode pour compter la quantité de chaque sexe, reçoit en paramètre le type de sexe
    static int compterSexe(char[] tableau, char typeSexe,int borne)
    {
        int nombre = 0;
        for (int i = 0; i < borne; i++)
            if (tableau[i] == typeSexe) nombre++;
        return nombre;
    }
    //Méthode pour compter à partir de une chiffre spécifiquement
    static void compterSuper (int[] tableau, int chiffre , ref int quantite ,int borne)
    {
        for (int i = 1; i < borne; i++)
            if (tableau[i] >= chiffre) quantite++;
    }
    //Méthode pour déterminer la moyenne et minimum d'un tableau de taille en dépendent du sexe
    static void detTaille (double[] tableau, char[] sexe ,  out double somme, out double min, char typeSexe , int borne)
    {
        somme = min = 0.0;            
        for (int i = 0; i < borne; i++)
        {
            if (sexe[i] == typeSexe)
            {
                min = tableau[i];
                if (tableau[i] < min) min = tableau[i];
                somme += tableau[i];
            }                
        } 
    }
    //Méthode pour determiner le max et le min dun tableau d'entiers
    static void detMinMax (int[] tableau, out int indiceMin, out int indiceMax, int borne)
    {
        indiceMin = indiceMax = 0;
        double  mini = tableau[0], maxi = tableau[0];
        for (int i = 1; i < borne; i++)
        {
            if (tableau[i] < mini)
            {
                mini = tableau[i];
                indiceMin = i;
            }
            if (tableau[i] > maxi)
            {
                maxi = tableau[i];
                indiceMax = i;
            }            
        }       
    }
    //Redéfinition de la methode pour determiner le max et le min dun tableau de double
    static void detMinMax(double[] tableau, out int indiceMin, out int indiceMax, int borne)
    {
        indiceMin = indiceMax = 0;
        double mini = tableau[0], maxi = tableau[0];
        for (int i = 1; i < borne; i++)
        {
            if (tableau[i] < mini)
            {
                mini = tableau[i];
                indiceMin = i;
            }
            if (tableau[i] > maxi)
            {
                maxi = tableau[i];
                indiceMax = i;
            }
        }
    }

    static void Main(string[] args)
    {
        int[] age = { 20, 51, 49, 55, 36, 68, 25, 30, 50, 23 },
                       nbCafe = { 3, 4, 0, 1, 2, 0, 7, 2, 1, 4 };
        double[] taille = { 1.78, 1.90, 1.87, 1.73, 1.88, 1.64, 1.86, 1.78, 1.58, 1.78 };
        char[] sexe = { 'F', 'F', 'M', 'F', 'M', 'F', 'F', 'F', 'F', 'M' };
        int nbPers = age.Length;
        int chiffre = 0, indMin, indMax;
        double tailleMoy = 0, min = double.MaxValue;
        //affiche les tableaux
        affiche(age,nbCafe,taille,sexe,nbPers);
        //compter et afficher les hommes et les femmes
        int hommes = compterSexe(sexe, 'M', nbPers );
        int femmes = compterSexe(sexe, 'F', nbPers);
        Console.WriteLine("Nombre d'Hommes: {0}, Nombre de Femmes: {1}", hommes, femmes);
        //compter les personnes qui ont > de 35 ans
        compterSuper(age, 35, ref chiffre, nbPers);
        Console.WriteLine("Personnes qui ont 35 ans ou plus: {0}", chiffre);
        //compter les personnes qui boivent > de 4 tasses de café
        chiffre = 0;
        compterSuper(nbCafe, 4, ref chiffre, nbPers);
        Console.WriteLine("Personnes qui consomment 4 tasses de café ou plus par jour: {0}", chiffre);
        //determiner les tailles minimales de hommes et femmes
        detTaille(taille, sexe, out tailleMoy, out min, 'M', nbPers);
        Console.WriteLine("Taille minimale des hommes est {0}, et taille moyenne est {1:F2}", min, tailleMoy / hommes);
        detTaille(taille, sexe, out tailleMoy, out min, 'F', nbPers);
        Console.WriteLine("Taille minimale des femmes est {0}, et taille moyenne est {1:F2}", min, tailleMoy / femmes);
        //triage et affichage du tableau
        trier(ref age, ref nbCafe, ref taille, ref sexe, nbPers);
        affiche(age, nbCafe, taille, sexe, nbPers);

        detMinMax(nbCafe, out indMin, out indMax, nbPers);
        Console.WriteLine("Personne qui consomme le plus de tasses de café par jour:\nSexe: {0} Age: {1} Cafe: {2} Taille: {3:F2}",sexe[indMax], age[indMax], nbCafe[indMax], taille[indMax] );
        Console.WriteLine("Personne qui consomme le moins de tasses de café par jour:\nSexe: {0} Age: {1} Cafe: {2} Taille: {3:F2}", sexe[indMin], age[indMin], nbCafe[indMin], taille[indMin]);

        detMinMax(taille, out indMin, out indMax, nbPers);
        Console.WriteLine("Personne qui est la plus grande en taille:\nSexe: {0} Age: {1} Cafe: {2} Taille: {3:F2}", sexe[indMax], age[indMax], nbCafe[indMax], taille[indMax]);
        Console.WriteLine("Personne qui est la plus petite en taille:\nSexe: {0} Age: {1} Cafe: {2} Taille: {3:F2}", sexe[indMin], age[indMin], nbCafe[indMin], taille[indMin]);

        Console.ReadLine();
    }
}

/*Execution:
Personne  Sexe    Age     Cafe    Taille
  1)        F      20       3      1.78
  2)        F      51       4      1.90
  3)        M      49       0      1.87
  4)        F      55       1      1.73
  5)        M      36       2      1.88
  6)        F      68       0      1.64
  7)        F      25       7      1.86
  8)        F      30       2      1.78
  9)        F      50       1      1.58
 10)        M      23       4      1.78
Nombre d'Hommes: 3, Nombre de Femmes: 7
Personnes qui ont 35 ans ou plus: 6
Personnes qui consomment 4 tasses de café ou plus par jour: 3
Taille minimale des hommes est 1.78, et taille moyenne est 1.84
Taille minimale des femmes est 1.58, et taille moyenne est 1.75
Personne  Sexe    Age     Cafe    Taille
  1)        F      20       3      1.78
  2)        M      23       4      1.78
  3)        F      25       7      1.86
  4)        F      30       2      1.78
  5)        M      36       2      1.88
  6)        M      49       0      1.87
  7)        F      50       1      1.58
  8)        F      51       4      1.90
  9)        F      55       1      1.73
 10)        F      68       0      1.64
Personne qui consomme le plus de tasses de café par jour:
Sexe: F Age: 25 Cafe: 7 Taille: 1.86
Personne qui consomme le moins de tasses de café par jour:
Sexe: M Age: 49 Cafe: 0 Taille: 1.87
Personne qui est la plus grande en taille:
Sexe: F Age: 51 Cafe: 4 Taille: 1.90
Personne qui est la plus petite en taille:
Sexe: F Age: 50 Cafe: 1 Taille: 1.58
 */