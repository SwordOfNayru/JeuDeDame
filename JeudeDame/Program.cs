using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeudeDame
{
    public class Jeudedame
    {
        //Variable de class
        //public static Font font = new Font("Arial", 20);
        public static int[] restant = new int[2] { 20, 20 }; //int[0] == pion restant pour les noirs int[1] == pion restant pour les blancs
        private static int[,] plateau = new int[10, 10];
        /*
        0 = case vide
        1 = Blanc
        2 = Noir
        3 = Reine Blanche
        4 = Reine Noir
        */
        public static string[] menu = new string[] { "Jouez", "Option", "Quitter" };
        public static string noma = "a";   // sert a initialiser les pseudos des 2 joueurs
        public static string nomb = "b";
        public static ConsoleColor[] couleurCase = new ConsoleColor[] //Stock des couleur utilisé pour les cases
        {
            ConsoleColor.Gray, //Case Blanche
            ConsoleColor.Black, //Case Noir
            ConsoleColor.DarkBlue, //Curseur case
            ConsoleColor.DarkGreen, //Case selectionner
            ConsoleColor.DarkRed //Case selectionnable
        };
        public static ConsoleColor[] couleurPion = new ConsoleColor[] //Stock les couleurs des pions
        {
            ConsoleColor.DarkGray, //Pion noir
            ConsoleColor.White //Pions Blanc
        };
        public static char[] CharPion = new char[2] { '☻', '♠'};
        public static int[] CurseurPos = new int[2] { 0, 0 };

    //MAIN
        public static void Main()
        {
            Console.SetWindowSize(50, 50);
            int choix = -1;
            Console.WriteLine("Entrez le nom du joueur A :");
            noma = Clavier.LireChaine();
            Console.WriteLine("Entrez le nom du joueur B :");
            nomb = Clavier.LireChaine();

            PlateauInit();
            
            do
            {
                Console.Clear();
                choix = Menu.MenuChoix(menu, "Jeu de Dame", 20);
                switch (choix)
                {
                    case 1: /*Jeu() fonction pas encore faite TO:DO*/; break;
                    case 2: /*Option()*/; break;
                    case 3: goto End;
                }
            } while (true);
        End:
            Console.Clear();
            Console.WriteLine("Merci d'avoir joué");
        }

        //Fonction d'initialisation
        public static void PlateauInit() //Permet d'initialisé le plateau
        {
            int i, j;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 4; j++) //Remplie pour les blancs
                {
                    Console.WriteLine("i%2 = {0} ; j%2 = {0}", i % 2, j % 2);
                    if ((i % 2) == (j % 2))
                    {
                        plateau[i, j] = 0;
                    }
                    else
                    {
                        plateau[i, j] = 1;
                    }
                }
                for (; j < 6; j++)
                {
                    plateau[i, j] = 0;
                }
                for (; j < 10; j++)
                {
                    if ((i % 2) == (j % 2))
                    {
                        plateau[i, j] = 0;
                    }
                    else
                    {
                        plateau[i, j] = 2;
                    }
                }
            }
        }
        //Fonction de vérification
        public static bool VerifCase(int i, int j) // renvoie un vrai ou un fauxsi une case est occupée ou non 
        {
            bool verif = true;
            if (plateau[i, j] == 0)
            {
                verif = false;
            }
            else
            {
                verif = true;
            }
            return verif;
        }
        public static void VerifPionsRestant()  //Rentre dans le tableau restant le nb de pion restant
        {
            int B = 0, N = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    switch (plateau[i, j])
                    {
                        case 1: B++; break;
                        case 3: B++; break;
                        case 2: N++; break;
                        case 4: N++; break;
                        default: break;
                    }
                }
            }
            restant = new int[2] { B, N };
        }
        public static bool VerifFinParti()
        {
            bool verif;
            if (restant[0] == 0 || restant[1] == 0)
            {
                verif = false;
            }
            else
            {
                verif = true;
            }
            return verif;
        }


        //Fonction d'affichage
        public static void AffichagePlateau()
        {

        }
        //Fonction de jeu
        public static void Jeu()
        {
            bool Quitter = true;
            ConsoleKeyInfo toucheUtilisateur;
            while (VerifFinParti() && Quitter)
            {
                do
                {
                    toucheUtilisateur = Console.ReadKey(true);
                } while (); //A Completer avec une fonction de vérification pour plus de clarter
            }
        }
    }

}
