using CryptoEffectClient.Algorithmes.Realisations.Transposition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Algorithmes.Realisations
{
    /// <summary>
    /// Algorithme de transposition
    /// </summary>
    public class AlgorithmeTransposition : IAlgorithme
    {
        public string Chiffrer(string message, string cle)
        {
            int hauteur = HauteurTableau(message, cle);
            List<int> ordreColonnes = OrdreDesColonnes(cle);

            // Initialisation du tableau
            char?[,] tableau = new char?[cle.Length, hauteur];
            int posLongueur = 0;
            int posHauteur = 0;

            // Remplissage du tableau
            foreach(char c in message)
            {
                tableau[posLongueur, posHauteur] = c;
                posLongueur++;
                if (posLongueur == cle.Length )
                {
                    posLongueur = 0;
                    posHauteur++;
                }
            }

            // Remplissage des caractères vides de la dernière ligne
            for (int i = 0; i < cle.Length; i++)
            {
                if (tableau[i, hauteur - 1] == null)
                    tableau[i, hauteur - 1] = 'x';
            }

            // Lecture du tableau dans la variable de retour 
            string retour = "";

            for (int i = 0; i < ordreColonnes.Count; i++)
            {
                for (int j = 0; j < hauteur; j++)
                {
                    retour += tableau[ordreColonnes[i], j];
                }
            }

            return retour;
        }

        public string Dechiffrer(string message, string cle)
        {
            int hauteur = HauteurTableau(message, cle);
            List<int> ordreColonnes = OrdreDesColonnes(cle);

            // Initialisation du tableau
            char[,] tableau = new char[cle.Length, hauteur];


            // Remplissage du tableau
            int posMessage = 0;
            for (int i = 0; i < ordreColonnes.Count; i++)
            {
                for (int j = 0; j < hauteur; j++)
                {
                    tableau[ordreColonnes[i], j] += message[posMessage];
                    posMessage++;
                }
            }

            // Lecture du tableau dans la variable de retour 
            string retour = "";
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < cle.Length; j++)
                {
                    retour += tableau[j,i];
                }
            }

            return retour;

        }

        /// <summary>
        /// Détermine la hauteur du tableau nécessaire pour stocker le message
        /// </summary>
        /// <param name="message">Message à stocker</param>
        /// <param name="clef">Clef à utiliser pour le tableau</param>
        /// <returns>Hauteur du tableau nécessaire pour stocker le message</returns>
        public int HauteurTableau(string message, string clef)
        {
            // La longueur du tableau sera la clef, on cherche donc juste
            // combien de lignes il faudra pour faire tenir le message complet

            // On fait la division en arondissant à l'excès
            return (int) Math.Ceiling(((decimal)message.Length / (decimal)clef.Length));
        }


        /// <summary>
        /// Détermine l'ordre de lecture de colonnes selon la clef fournie
        /// </summary>
        /// <param name="clef">Clef utilisée</param>
        /// <returns>Ordre de lecture des colonnes</returns>
        public List<int> OrdreDesColonnes(string clef)
        {
            // Liste des couples pour cette clef
            Couple[] couples = new Couple[clef.Length];
            for (int i = 0; i < clef.Length; i++)
            {
                couples[i] = new Couple(clef[i],i);
            }

            // Tri par insertion de la clef
            for (int i = 0; i < couples.Length; i++)
            {
                for (int j = i; j < couples.Length; j++)
                {
                    // Si i vient avant j, on les inverse
                    // Et de même, s'ils sont le même caractère, on compare leur position et on inverse si i a une plus grande position que j
                    if ((couples[i].CompareTo(couples[j]) < 0) || ((couples[i].CompareTo(couples[j]) == 0) && (couples[i].Position > couples[j].Position)))
                    {
                        Couple temp = couples[i];  
                        couples[i] = couples[j];
                        couples[j] = temp;
                    }
                }
            }

            // On récupère ensuite la valeur de retour (l'ordre de lecture)
            List<int> retour = new List<int>();
            for (int i = 0; i < couples.Length;i++)
            {
                retour.Add(couples[i].Position);
            }

            return retour;
            

        }
    }
}
