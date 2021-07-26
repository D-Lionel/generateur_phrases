using System;
using System.Collections.Generic;

namespace generateur_phrases
{
    class Program
    {

        static string ObtenirElementAleatoire(string[] t)
        {
            Random rand = new Random();
            int i = rand.Next(t.Length);

            return t[i];
        } 

        static void Main(string[] args)
        {
            var sujets = new string[] { "Un lapin",
                "Une grand-mère",
                "Un chat",
                "Un chien",
                "Un espion",
                "Un garde du corps",
                "Un cowboy",
                "Un dragon",
            };

            var verbes = new string[]
            {
                "mange",
                "écrase",
                "détruit",
                "observe",
                "attrape",
                "nettoie",
                "se bat avec",
                "s'accroche à",
            };

            var complements = new string[]
            {
                "un arbre",
                "un livre",
                "la lune",
                "le soleil",
                "un serpent",
                "le ciel",
                "une piscine",
                "une souris",
            };

           
            const int NB_PHRASES = 100;
            var phrasesUniques = new List<string>();
            int doublonsEvites = 0;

            while (phrasesUniques.Count < NB_PHRASES)
            {
                var sujet = ObtenirElementAleatoire(sujets);
                var verbe = ObtenirElementAleatoire(verbes);
                var complement = ObtenirElementAleatoire(complements);
                var phrase = sujet + " " + verbe + " " + complement;

                phrase = phrase.Replace("à le", "au"); //Pour éviter des incohérences comme "il regarde à le soleil"

                //Vérifie qu'on enregistre pas 2 fois la même phrase générée
                if (!phrasesUniques.Contains(phrase))
                {
                    phrasesUniques.Add(phrase);

                }
                else
                {
                    doublonsEvites++;
                }
            }

            //Afficher les phrases formées
            foreach (var phrase in phrasesUniques)
            {
                Console.WriteLine(phrase);
            }
            Console.WriteLine();
            Console.WriteLine("Doublons évités : " + doublonsEvites);
        }
    }
}
