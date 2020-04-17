using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problème2018
{
    public class Program
    {
        
    /// <summary>
    /// Compte le nombre de points gagnés en fonction de la longueur du mot 
    /// </summary>
    /// <param name="motTrouvé">mot à paritr duquel on veut déduire le score</param>
    /// <returns>retourne le score</returns>
        public static int PointsGagnés(string motTrouvé)
        {
            int score = 0;
            if (motTrouvé.Length == 3) { score = 2; }
            if (motTrouvé.Length == 4) { score = 3; }
            if (motTrouvé.Length == 5) { score = 4; }
            if (motTrouvé.Length == 6) { score = 5; }
            if (motTrouvé.Length > 6) { score = 11; }
            return score;

        }

        /// <summary>
        /// Lit le fichier placé en paramètre et renvoie un tableau de tableau 
        /// </summary>
        /// <param name="filename"></param>
        /// <remarks>le fichier contient 14 lignes (on prend pas la ligne qui indique la longueur des mots), on crée un tableau de tableau avec 14 lignes. 
        /// Dans une ligne tous les mots on la même longueur </remarks>
        /// <remarks> dans chaque du tableau chaque mot est stocké sous forme de tableau </remarks>
        /// <returns> un tableau de tableau avec les mots possibles</returns>
        public static string[][] OuvertureFichier(string filename)
        {
            
            string[][] fichierMot = new string[14][];
            StreamReader sFichier = null;
            try
            {
                char[] t0 = { ' ' };
                sFichier = new StreamReader(filename);
                string line;
                int compteur = 0;
                while ((line = sFichier.ReadLine()) != null)
                {
                   if (line.Length > 3)
                   {
                    string[] tab = null;
                    tab = line.Split(t0);
                    fichierMot[compteur] = tab;
                    compteur++;
                   }
                }
                
            }
            catch (IOException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { if (sFichier != null) { sFichier.Close(); } }
            return fichierMot;

        }

   
        /// <summary>
        /// On crée un tableau de type dé qui stocke chaque dé
        /// </summary>
        /// <returns>un tableau de type dé</returns>
        public static Dé[] OuvertureFichierDés()
        {
            Dé[] tableauDeDes = new Dé[16]; 
            try  
            {
                StreamReader sr = new StreamReader("Des.txt");
                string ligne = "";
                int i = 0;
                while (sr.EndOfStream == false)
                {
                    ligne = sr.ReadLine(); //split?
                    string[] face = ligne.Split(';');
                    Dé De1 = new Dé(face);
                    tableauDeDes[i] = De1; 

                    i++;
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString());}
            return tableauDeDes;
        }


        static void Main(string[] args)
        {

            #region Initialisation du jeu 

            string[][] dictionnaire = OuvertureFichier("MotsPossibles.txt");
            Dictionnaire motsPossibles = new Dictionnaire(dictionnaire);

            Dé[] déDuPlateau = OuvertureFichierDés();
            Random r = new Random();

            Console.WriteLine("Quel est le nom du premier joueur ? ");
            string prénomJoueur1 = Console.ReadLine();
            Console.WriteLine("Quel est le nom du deuxième joueur ? ");
            string prénomJoueur2 = Console.ReadLine();
            Joueur joueur1 = new Joueur(prénomJoueur1);
            Joueur joueur2 = new Joueur(prénomJoueur2);

            Console.WriteLine("Combien de temps souhaitez vous que la partie dure en minutes  ? ");
            int dureePartie = Convert.ToInt32(Console.ReadLine());
            DateTime debut = DateTime.Now; //Heure du début de la partie, à partir delaquelle on calcul le temps de la partie
            Console.WriteLine(debut);
            TimeSpan duree = new TimeSpan(0,dureePartie,0);
            Console.WriteLine(duree);

           
            int compteurNbTours = 0; //Compteur qui compte le nombre de tours : quand il est pair ou nul c'est le joueur 1 qui joue et quand il est impair c'est le joueur 2
                                     //il permet de faire jouer les joueurs chacun leur tour
            #endregion

            #region Jeu pendant le temps imparti 
            do
            {
                
                TimeSpan intervalleTour = new TimeSpan(0, 1, 0);
                if (compteurNbTours % 2 == 0 || compteurNbTours == 0)  
                {
                    Console.WriteLine("C'est au tour de " + joueur1.Nom + " de jouer");
                    Console.WriteLine(joueur1.toString());
                    DateTime debutJ1 = DateTime.Now; //Heure à partir de laquelle le joueur 1 commence son tour 

                    Plateau plateauPartie = new Plateau(déDuPlateau, r);
                    Console.Write(plateauPartie.AfficherPlateau());

                    while (DateTime.Now.Subtract(debutJ1)< intervalleTour)
                    {
                        Console.WriteLine("Saisir un mot trouvé : ");
                        string motTrouvé = Console.ReadLine().ToUpper();
                        if (motTrouvé.Length > 2) 
                        {
                            if(motsPossibles.RechDichoRecursif(0, motsPossibles.FichierMot[motTrouvé.Length - 2].Length, motTrouvé))
                            {
                                if(joueur1.Contain(motTrouvé))
                                {
                                    char[] motChar = motTrouvé.ToCharArray();
                                    if (plateauPartie.TestPlateauRec(motChar, 0, 0, 0))
                                    {
                                        joueur1.Score += PointsGagnés(motTrouvé);
                                        joueur1.Add_Mot(motTrouvé);
                                        Console.WriteLine("Le score de " + joueur1.Nom + " est maintenant de " + joueur1.Score);
                                    }
                                    else { Console.WriteLine("Le mot n'appartient pas au plateau"); }

                                }
                                else { Console.WriteLine("Vous avez déjà trouvé ce mot "); }

                            }
                            else { Console.WriteLine("Le mot n'appartient pas au dictionnaire"); }
                        }
                        else { Console.WriteLine("Le mot est trop court"); }
                        Console.WriteLine("Temps écoulé " + DateTime.Now.Subtract(debutJ1));
                    }
                    compteurNbTours++;
                }

                else
                {
                    Console.WriteLine("C'est au tour de " + joueur2.Nom + " de jouer");
                    Console.WriteLine(joueur2.toString());
                    DateTime debutJ2 = DateTime.Now;

                    Plateau plateauPartie = new Plateau(déDuPlateau, r);
                    Console.Write(plateauPartie.AfficherPlateau());

                    while (DateTime.Now.Subtract(debutJ2) < intervalleTour)
                    {
                        Console.WriteLine("Saisir un mot trouvé : ");
                        string motTrouvé = Console.ReadLine().ToUpper();
                        if(motTrouvé.Length > 2)
                        {
                            if (motsPossibles.RechDichoRecursif(0, motsPossibles.FichierMot[motTrouvé.Length - 2].Length, motTrouvé))
                            {
                                if (joueur1.Contain(motTrouvé))
                                {
                                    char[] motChar = motTrouvé.ToCharArray();
                                    if (plateauPartie.TestPlateauRec(motChar, 0, 0, 0))
                                    {
                                        joueur2.Score += PointsGagnés(motTrouvé);
                                        joueur2.Add_Mot(motTrouvé);
                                        Console.WriteLine("Le score de " + joueur2.Nom + " est maintenant de " + joueur2.Score);
                                    }
                                    else { Console.WriteLine("Le mot n'appartient pas au plateau"); }

                                }
                                else { Console.WriteLine("Vous avez déjà trouvé ce mot "); }

                            }
                            else { Console.WriteLine("Le mot n'appartient pas au dictionnaire"); }
                        }
                        else { Console.WriteLine("Le mot est trop court"); }
                        Console.WriteLine("Temps écoulé " + DateTime.Now.Subtract(debutJ2));

                    }
                    compteurNbTours++;
                }

            } while (DateTime.Now.Subtract(debut)< duree);
            #endregion

            #region Fin du Jeu 
            Console.WriteLine("C'est la fin de la partie");
            if(joueur1.Score> joueur2.Score) { Console.WriteLine(joueur1.Nom + " a gagné "); }
            if (joueur2.Score > joueur1.Score) { Console.WriteLine(joueur2.Nom + " a gagné "); }
            if(joueur1.Score==joueur2.Score) { Console.WriteLine("Les deux joueurs sont ex aequo"); }
            #endregion 
           

            Console.ReadKey();
        }//fin main

    } //fin classe programme

}//fin namespace
