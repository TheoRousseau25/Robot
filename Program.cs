using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace test
{
    class Program
    {
        static void initialiserTableau(int [,] tab, int row, int col)
        {

            int i,j;
            Random aleatoire =  new Random();
            int entier, entier2;
            int x =0, y = 0;

            for(i=0; i < row; i++)
            {
                for(j=0; j < col; j++)
                {
                    tab[i, j]=0;
                }
            }

            tab[y, x]=2;

            for(i=0; i < row; i++){
                entier = aleatoire.Next(row);
                entier2 = aleatoire.Next(row);

                tab[entier, entier2]=1;
            }

        }

        static void afficherTableau(int[,] tab, int row, int col){

            int i,j;

            for(i=0; i < row; i++)
            {
                for(j=0; j < col; j++)
                {
                    if(tab[i, j]==2){
                        Console.Write(" R "); 
                    }

                    if(tab[i, j]==1){
                        Console.Write(" 1 ");
                    }

                    if(tab[i,j]==0){
                        Console.Write(" 0 "); 
                    }
                }

                 Console.Write("\n");       
            }
            Console.Write("\n");
        }

        static bool verifierTableau(int[,] tab, int row, int col)
        {
            bool test = true;
            int i, j;
            
            for(i=0; i < row; i++)
            {
                for(j=0; j < col; j++)
                {
                    if(tab[i, j]==0)
                    {
                        test = false;
                    }
                }
            }

            return test;

        }


        static void Main(string[] args)
        {
            string r, c;
            int row, col;

            do
            {
                Console.Write("Rentrez un nombres de lignes : ");
                r = Console.ReadLine();
                
            } while (!int.TryParse(r, out row));

            do
            {
                Console.Write("Rentrez un nombres de colonnes : ");
                c = Console.ReadLine();

            } while (!int.TryParse(c, out col));

            int[,] tab = new int[row, col];
            int x =0, y = 0;
            int etape = 0;

            List<List<int>> memoire = new List<List<int>>();
            List<int> listeY = new List<int>();
            List<int> listeX = new List<int>();

            memoire.Add(listeY);
            memoire.Add(listeX);

            initialiserTableau(tab, row, col);
            
            while(verifierTableau(tab, row, col) == false)
            {
                
                Console.Write(x + ", " + y + "\n");


                if (x < row-1 && tab[y, x+1] != 1)
                {   
                    Console.Write("condition 1\n");
                    if(tab[y, x+1] == 0)
                    {
                        tab[y, x + 1] = 2;
                        tab[y, x] = 1;
                        x +=1;
                    }

                    memoire[0].Add(y);
                    memoire[1].Add(x);
                }
                
                else if(y < col-1 && tab[y+1, x] != 1)
                {   
                    Console.Write("condition 2\n");
                    if(tab[y+1, x] == 0)
                    {
                        tab[y+1, x] = 2;
                        tab[y, x] = 1;
                        y +=1;
                    }

                    memoire[0].Add(y);
                    memoire[1].Add(x);
                }

                else if(x > 0 && tab[y, x-1] != 1)
                {
                    Console.Write("condition 3\n");
                    if(tab[y, x-1] == 0)
                    {
                        tab[y, x-1] = 2;
                        tab[y, x] = 1;
                        x -=1;
                    }

                    memoire[0].Add(y);
                    memoire[1].Add(x);
                }

                else if(y > 0 && tab[y-1, x] != 1)
                {
                    Console.Write("condition 4\n");
                    if(tab[y-1, x] == 0)
                    {
                        tab[y-1, x] = 2;
                        tab[y, x] = 1;
                        y -=1;
                    }

                    memoire[0].Add(y);
                    memoire[1].Add(x);
                }

                else
                {
                    Console.Write("condition 5\n");
                    tab[y, x] = 1;

                    memoire[0].RemoveAt(memoire[0].Count()-1);
                    memoire[1].RemoveAt(memoire[1].Count()-1);

                    y = memoire[0].Last();
                    x = memoire[1].Last();

                    tab[y, x] = 2;
                    etape++;

                }

                afficherTableau(tab, row, col);
                //Thread.Sleep(2000);

            }

            Console.WriteLine("Nombre d'étape : "+etape);

           
}}}
