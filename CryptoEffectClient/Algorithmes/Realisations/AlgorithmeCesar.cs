using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Algorithmes.Realisations
{
    /// <summary>
    /// Algorithme de César
    /// </summary>
    public class AlgorithmeCesar : IAlgorithme
    {
        public string Chiffrer(string message, string cle)
        {
            string messageChiffre = "";

            // Pour chaque caractère du message, on le chiffrera avec la méthode ChiffrerChar.
            foreach (char c in message)
            {
                messageChiffre += ChiffrerChar(c, Convert.ToInt32(cle));
            }

            return messageChiffre;
        }

        public string Dechiffrer(string message, string cle)
        {
            string messageDechiffre = "";

            // Pour chaque caractère du message, on le déchiffrera avec la méthode ChiffrerChar.
            // La clef sera passée en valeur négative pour "chiffrer dans le sens inverse", ce qui reviendra à déchiffrer dans notre cas
            foreach (char c in message)
            {
                messageDechiffre += ChiffrerChar(c, -Convert.ToInt32(cle));
            }

            return messageDechiffre;
        }

        /// <summary>
        /// Renvoie la position du caractère dans l'alpabet (par exemple a ou A renverra 0, b ou B renverra 1, ...)
        /// </summary>
        /// <param name="c">Caractère à traduire</param>
        /// <returns>Retourne la position de la lettre dans l'alphabet</returns>
        public int CharToInt(char c)
        {
            // L'alphabet en minuscule en ASCII va de 97 à 122
            // On le convertit en byte pour avoir la position dans l'alphabet ASCII et on lui retire 97 pour que a soit à la position 0
            return (int) Convert.ToByte(Char.ToLower(c)) - 97;
        }

        /// <summary>
        /// Chiffre un caractère à l'aide d'une clef donnée en paramètre
        /// </summary>
        /// <param name="c">Caractère à chiffrer</param>
        /// <param name="clef">Clef de l'algorithme</param>
        /// <returns>Retourne le caractère chiffré</returns>
        public char ChiffrerChar(char c, int clef)
        {
            char retour = c;

            // On vérifie que c est bien une lettre, sinon on ne la modifie pas
            if (Char.IsLetter(c))
            {
                // On traduit le caractère entré en paramètre en nombre
                int caractere = CharToInt(c);

                // On ajoute à ce caractère la valeur de la clef modulo le nombre de lettres de l'alphabet.
                caractere = (caractere + clef) % 26;
                // Si la lettre chiffrée est inférieure à 0, on lui rajoutera 25
                if (caractere < 0 )
                { caractere += 26; }

                // On convertit le char de retour en lui ajoutant les 97 retirés plus tôt
                retour = Convert.ToChar((byte)(caractere + 97));

                // On vérifie s'il est une lettre en minuscule ou non, si oui, on lui ajoute 40 (écart entre les 2 alphabets dans l'alphabet ASCII)
                if (Char.IsUpper(c))
                { retour = Char.ToUpper(retour); }

            }

            // On renvoie la valeur de char 
            return retour;
        }
    }
}
