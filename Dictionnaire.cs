using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problème2018
{
    public class Dictionnaire
    {


        #region Attribut et Constructeurs 
        string[][] fichierMot;


        public Dictionnaire(string[][] fichier)
        {
            this.fichierMot = fichier;
        }
        #endregion

        #region Propriétés

        public string[][] FichierMot
        { get { return fichierMot; } }
        #endregion 

        #region Méthodes
        public string toString()
        {
            string stringDictionnaire = "les mots autorisés sont " + '\n';
            for(int i=0;i<fichierMot.Length;i++)
            {
                    for (int j = 0; j < fichierMot[i].Length; j++)
                    {
                    stringDictionnaire += fichierMot[i][j] + " ";
                    }
            }
            return stringDictionnaire;
        }


        /// <summary>
        /// la liste est triée par ordre alphabétique 
        /// on cherche le mot dans à la ligne qui correspond à la taille du mot dans <c>fichierMot</c> qui correspond à mot.Lenght-2 puisque
        /// les mots commencent à une longueur de 2
        /// On utilise la méthode Compare() qui compare de string vis à vis de l'ordre alphabétique 
        /// </summary>
        /// <param name="debut">indice  début du tableau dans le lequel on cherche le mot </param >
        /// <param name="fin">indice de  fin du tableau dans lequel on cherhce le mot</param>
        /// <param name="mot"></param>
        /// <returns>un booléen : True si le mot appartient à <c>fichierMot</c>, False sinon</returns>
        public bool RechDichoRecursif(int debut, int fin,string mot)
        {
            int milieu = (debut + fin) / 2;
            if (debut > fin) { return false; }
            else
            {
                if (String.Compare(mot, fichierMot[mot.Length - 2][milieu]) == 0) { return true; }
                else
                {
                    if (String.Compare(mot, fichierMot[mot.Length - 2][milieu]) < 0) { return RechDichoRecursif(debut, milieu - 1, mot); }
                    else { return RechDichoRecursif(milieu + 1, fin, mot); }
                }
            }
        }      
        #endregion



    }
}
