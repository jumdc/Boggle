using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problème2018
{
    public class Plateau
    {
        #region Attributs et Propriétés
        Dé[] désDeLaPartie;
        string[,] facesVisibles;
         
        public Dé[] DésDeLaPartie
        { get { return désDeLaPartie; } }

        public string[,] FacesVisibles
        { get { return facesVisibles; } }


        #endregion 

        #region Constructeurs

        public Plateau(Dé[] désPartie, string[,]faces)
        {
            this.désDeLaPartie = désPartie;
            this.facesVisibles = faces;
        }



        public Plateau(Dé[]désPartie,  Random r )
        {
            if (désPartie.Length == 16) { this.désDeLaPartie = désPartie; }
            this.facesVisibles = new string[4, 4];
            int compteur = 0;
            for (int i = 0; i < facesVisibles.GetLength(0); i++)
            {
                for (int j = 0; j < facesVisibles.GetLength(1); j++)
                {
                    this.facesVisibles[i, j] = désPartie[compteur].LanceS(r); //On remplit faces visibles à l'aide de la méthode LanceS qui tire une face au hasard du dé correspondant
                    compteur++; 

                }
            }
        }
        #endregion


        #region Méthodes

        /// <summary>
        /// 
        /// </summary>
        /// <returns>un string qui décrit l'objet </returns>
        public string toString()
        {
            string stringPlateau = "Les Dés composants le plateau sont : " + '\n';
            for(int i =0; i<désDeLaPartie.Length-1;i++)
            {
                stringPlateau += désDeLaPartie[i].toString() + '\n';               
            }
            stringPlateau += "le plateau est composé de : " + '\n';

            for(int i =0;i<facesVisibles.GetLength(0);i++)
            {
                for(int j = 0; j<facesVisibles.GetLength(1);j++)
                {
                    stringPlateau += facesVisibles[i, j] + "  " ;
                }
                stringPlateau += '\n';
            }
            return stringPlateau;
        }

        /// Résumé de <c>AffciherPlteau</c>
        /// <summary>
        /// Méthode qui crée une chaine de caractère juste pour le plateau de jeu 
        /// </summary>
        /// <returns>un string qui décrit le plateau de jeu </returns>
        public string AfficherPlateau() 
        {
            
            string stringPlateau="";
            for (int i = 0; i < facesVisibles.GetLength(0); i++)
            {
                for (int j = 0; j < facesVisibles.GetLength(1); j++)
                {
                    stringPlateau += facesVisibles[i, j] + "  ";
                }
                stringPlateau += '\n';
            }
            return stringPlateau;
        }

        /// <TestPlateauRec>
        /// <summary>Première boucle : dans laquelle on cherche  toutes les apparitions de la première lettre du mot 
        /// à chaque première lettre trouvée on test si la deuxième lettre peut être atteinte en satisfaisant les conditions ennoncées 
        /// Si on trouve la lettre on augmente l'indice (pour chercher la lettre suivante) 
        /// et on modifie la colonne et la ligne dans les paramètres qui correspondent à la où a été trouvé la lettre</summary>
        /// <param name="mot"></param>
        /// <param name="indice"> caractérise les lettres du mot que l'on cherche</param >
        /// <param name="ligne">à laquelle on cherche la lettre qui correspond au num indice dans le mot</param >
        /// <param name="colonne"> à laquelle on cherche la lettre qui correspond au num indice dans le mot </param>
        /// 
        /// <returns>un booléen : true si le mot est présent, false sinon </returns>
        public bool TestPlateauRec(char[] mot, int indice, int ligne, int colonne)
        {
            if (indice > mot.Length) { return false; }
            if (mot[mot.Length - 1].ToString() == facesVisibles[ligne, colonne]) { return true; }
            if (indice == 0)
            {
                for (int i = 0 ; i < 4; i++) //ligne =0
                {
                    for (int j = 0 ; j < 4; j++) //colonne =0
                    {
                        if (mot[indice].ToString() == facesVisibles[i, j]) { return TestPlateauRec(mot, indice + 1, i, j); }

                    }
                }
                { return false; }

            }
            else
            {
                //Test horizontal 
                if (colonne > 0)
                {
                    if (mot[indice].ToString() == facesVisibles[ligne, colonne - 1]) { return (TestPlateauRec(mot, indice + 1, ligne, colonne - 1)); }
                }
                if (colonne < 3)
                {
                    if (mot[indice].ToString() == facesVisibles[ligne, colonne + 1]) { return TestPlateauRec(mot, indice + 1, ligne, colonne + 1); }
                }
                //Test vertical 
                if (ligne > 0)
                {
                    if (mot[indice].ToString() == facesVisibles[ligne - 1, colonne]) { return (TestPlateauRec(mot, indice + 1, ligne - 1, colonne)); }
                }
                if (ligne < 3)
                {
                    if (mot[indice].ToString() == facesVisibles[ligne + 1, colonne]) { return (TestPlateauRec(mot, indice + 1, ligne + 1, colonne)); }
                }
                //Test diagonales
                //diagonale en bas à droite 
                if (colonne < 3 && ligne < 3)
                {
                    if (mot[indice].ToString() == facesVisibles[ligne + 1, colonne + 1]) {  return TestPlateauRec(mot, indice + 1, ligne + 1, colonne + 1); }
                }
                //diagonale en bas à gauche 
                if (colonne > 0 && ligne < 3)
                {
                    if (mot[indice].ToString() == facesVisibles[ligne + 1, colonne - 1]) { return TestPlateauRec(mot, indice + 1, ligne + 1, colonne - 1); }
                }
                //diagonale en haut à gauche
                if (colonne > 0 && ligne > 0)
                {
                    if (mot[indice].ToString() == facesVisibles[ligne - 1, colonne - 1]) { return TestPlateauRec(mot, indice + 1, ligne - 1, colonne - 1); }
                }
                //diagonale en haut à droite
                if (colonne < 3 && ligne > 0)
                {
                    if (mot[indice].ToString() == facesVisibles[ligne - 1, colonne + 1]) { return TestPlateauRec(mot, indice + 1, ligne - 1, colonne - 1); }
                }
                return false;
            }
        }
        #endregion


    }
}
