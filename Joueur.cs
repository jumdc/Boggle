using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problème2018
{
    public class Joueur
    {
        string nom;
        int score;
        string[] motsTrouvés;

        #region Constructeurs et Propriétés

        /// <summary>
        /// On construit un tableau ( <c>motsTrouvés</c> ) 
        /// Si on a déjà un tableau de <c>motsTrouvés</c> on le recopie dans un nouveau que l'on complète par des cases vides 
        /// Sinon on le remplit que de cases vides 
        /// </summary>
        /// <param name="nom">nom du joueur </param>
        public Joueur(string nom)
        {
            this.nom = nom;
            score = 0;
            this.motsTrouvés = new string[100];
            for(int i=0; i<motsTrouvés.Length;i++)
            {
                motsTrouvés[i] = "vide";
            }
        }

        public Joueur(string nom, string[] motsTrouvés, int score)
        {
            this.nom = nom;
            this.score = score;
            this.motsTrouvés = new string[1000];
            for(int i =0; i < motsTrouvés.Length; i++) { this.motsTrouvés[i] = motsTrouvés[i]; }
            for(int j = motsTrouvés.Length; j < this.motsTrouvés.Length; j++) { this.motsTrouvés[j] = "vide"; }
        }
        

        public string Nom
        { get { return nom; } }

        /// <summary>
        /// on doit pouvoir accéder à motsTrouvés en lecture et en écriture : pour pouvoir lui modifier
        /// le score quand le joueur trouve des mots
        /// </summary>
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        /// <summary>
        /// on doit pouvoir accéder à motsTrouvés en lecture et en écriture : pour pouvoir lui ajouter les mots que le
        /// joueur trouve au fur et à mesure
        /// </summary>
        public string[] MotsTrouvés
        {
            get { return MotsTrouvés; }
            set{ MotsTrouvés = value; }
        }
        #endregion

        #region Méthodes

        /// <summary>
        /// </summary>
        /// <param name="mot">mot dont on veut tester la présence dans <c>motsTrouvés</c> </param>
        /// <returns>un booléen, True si il appartient False sinon</returns>
        public bool Contain(string mot)
        {
            bool result = true;
            for(int i=0; i<motsTrouvés.Length;i++)
            { if (motsTrouvés[i] == mot) { result = false; } }
            return result;
        }


        /// <summary>
        /// on cherche l'indice de la première case vide <c>vide</c>
        /// à la première place vide que l'on trouve  on arrete et on replit la case correspondante 
        /// </summary>
        /// <param name="mot">mot que l'on veut ajouter à <c>motsTrouvés</c></param>
        public void Add_Mot(string mot)
        {
            if (Contain(mot))
            {
                int place = 0;
                while(place == 0)
                {
                    for (int i = 0; i < motsTrouvés.Length; i++)
                    {
                        if (motsTrouvés[i] == "vide"){ place = i; }
                    }
                }  
                motsTrouvés[place] = mot;
            }
        }

        /// <summary>
        /// Génére une chaine de caractère qui décrit le joueur 
        /// </summary>
        /// <returns>une chaine de caractère</returns>
        public string toString()
        {
            string stringJoueur = null;
            stringJoueur += "le joueur : " + nom + " a un score de : " +  score + " Il a trouvé les mots : " + '\n';
            for(int i =0; i<motsTrouvés.Length;i++)
            {
                if (motsTrouvés[i] != "vide") { stringJoueur += motsTrouvés[i] + '\n'; }
            }
            return stringJoueur;
        }


        #endregion


    }
}
