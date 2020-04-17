using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problème2018
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestContain_False()
        {
            string[] motsTrouvés = { "loto", "victoire" };
            int score = 4;
            Joueur toto = new Joueur("toto", motsTrouvés, score);
            Assert.AreEqual(false, toto.Contain("victoire"));
        }
        [TestMethod]
        public void TestContain_True()
        {
            string[] motsTrouvés = { "loto", "victoire" };
            int score = 4;
            Joueur toto = new Joueur("toto", motsTrouvés, score);
            Assert.AreEqual(true, toto.Contain("patate"));
        }
        [TestMethod]
        public void TestAdd_Mot_Vrai()
        {
            string[] motsTrouvés = { "loto", "victoire" };
            int score = 4;
            Joueur toto = new Joueur("toto", motsTrouvés, score);
            toto.Add_Mot("patate");
            Assert.AreEqual(false, toto.Contain("patate"));
        }
        [TestMethod]
        public void Test_RechDicho_Vrai()
        {
            string[][] tab = new string[2][];
            tab[0] = new string[6] { "AA", "AH", "AI", "AN", "AS", "AU" };
            tab[1] = new string[6] { "AAS", "ACE", "ADA", "ADO", "AGA", "AGE" };
            Dictionnaire mots = new Dictionnaire(tab);
            string motTrouvé = "AA";
            Assert.AreEqual(true, mots.RechDichoRecursif(0, tab[0].Length, motTrouvé));
        }
        [TestMethod]
        public void Test_RechDicho_Faux()
        {
            string[][] tab = new string[2][];
            tab[0] = new string[6] { "AA", "AH", "AI", "AN", "AS", "AU" };
            tab[1] = new string[6] { "AAS", "ACE", "ADA", "ADO", "AGA", "AGE" };
            Dictionnaire mots = new Dictionnaire(tab);
            string motTrouvé = "AR";
            bool appartientDic = mots.RechDichoRecursif(0, tab[0].Length, motTrouvé);
            Assert.AreEqual(false, appartientDic);
        }
        [TestMethod]
        public void TestRechPlateau_Vrai()
        {
            string[,] plateau = new string[4, 4] { { "M", "E", "R", "T" }, { "D", "A", "S", "T" }, { "O", "P", "I", "H" }, { "C", "L", "A", "G" } };
            char[] mot = new char[3] { 'O', 'P','L'};
            Dé[] déDuPlateau = Program.OuvertureFichierDés();
            Plateau plat = new Plateau(déDuPlateau, plateau);
            Assert.AreEqual(true, plat.TestPlateauRec(mot, 0, 0, 0 ));
        }
        [TestMethod]
        public void TestRechPlateau_Faux()
        {
            string[,] plateau = new string[4, 4] { { "M", "E", "R", "T" }, { "D", "A", "S", "T" }, { "O", "P", "I", "H" }, { "C", "L", "A", "G" } };
            char[] mot = new char[3] { 'L', 'O', 'I' };
            Dé[] déDuPlateau = Program.OuvertureFichierDés();
            Plateau plat = new Plateau(déDuPlateau, plateau);
            Assert.AreEqual(false, plat.TestPlateauRec(mot, 0, 0, 0));
        }

        [TestMethod]
        public void TestPointsGagnés()
        {
            Assert.AreEqual(11, Program.PointsGagnés("paquerette"));
        }

        
    }
}
