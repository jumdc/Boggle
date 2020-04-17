using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problème2018
{
    public class Dé
    {
        #region Attributs
        string[] faces = new string[6];
        #endregion

        #region Constructeur 
        public Dé(string[]faces)
        {
            if (faces.Length == 6)
            { for (int i = 0; i < faces.Length; i++) { this.faces[i] = faces[i]; } }
            else { Console.WriteLine("Le dé n'a pas 6 faces. Changer de dé"); }
        }

        #endregion

        #region propriétés
        /// <summary>
        /// On a besoin d'accéder à face seulement en lecture pour pouvoir l'afficher par exemple
        /// </summary>
        public string[] Faces
        { get { return faces; }  }
        #endregion

        #region méthodes
        public string toString()
        {
            string stringDé = "le dé " + "a sur ses faces : " + '\n';
            for(int i =0; i < faces.Length; i++) { stringDé += faces[i] + '\n'; }
            return stringDé;
        }

        public void Lance(Random r)
        {
            int numFace;
            string faceTirée;
            numFace = r.Next(0, 5);
            faceTirée = faces[numFace];
            Console.WriteLine(faceTirée);

        }

        /// <summary>
        /// méthode qui permet de tirer une face au hasard dans un dé
        /// </summary>
        /// <param name="r"></param>
        /// <returns>une face du dé tiré au hasard (string)</returns>
        public string LanceS(Random r)
        {
            int numFace;
            string faceTirée;
            numFace = r.Next(0, 5);
            faceTirée = faces[numFace];
            return faceTirée;
        }
        #endregion


    }
}
