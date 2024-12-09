using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Algorithmes.Realisations
{
    /// <summary>
    /// Algorithme double de César
    /// </summary>
    public class AlgorithmeCesarDouble : IAlgorithme
    {
        public string Chiffrer(string message, string cle)
        {
            string messageChiffre = "";

            // Conversion vers un type int
            Convert.ToInt32("125");

            // Conversion vers un type long
            Convert.ToInt64("1255144784171781741");

            // Pour chaque paire de caractères du message, on la chiffrera avec la méthode ChiffrementPairChars.
            for (int i=0; i< message.Length; i+=2)
            {
                messageChiffre += ChiffrementPairChars(message[i], message[i + 1], Convert.ToInt32(cle));
            }

            return messageChiffre;
        }

        public string Dechiffrer(string message, string cle)
        {
            string messageDechiffre = "";

            // Pour chaque paire de caractères du message, on la déchiffrera avec la méthode ChiffrementPairChars.
            // La clef sera passée en valeur négative pour "chiffrer dans le sens inverse", ce qui reviendra à déchiffrer dans notre cas
            for (int i = 0; i < message.Length; i += 2)
            {
                messageDechiffre += ChiffrementPairChars(message[i], message[i + 1], - Convert.ToInt32(cle));
            }

            return messageDechiffre;
        }

        /// <summary>
        /// Méthode permetttant de transformer une paire de caractères en un nombre <br/>
        /// (correspondant à leur position dans la liste des paires de caractères possibles)
        /// </summary>
        /// <param name="c1">Premier caractère de la paire</param>
        /// <param name="c2">Second caractère de la paire</param>
        /// <returns>Renvoie leur position dans la liste des paires possibles</returns>
        public int CharsToInt(char c1, char c2)
        {
            // Retourne la valeur de c1 * base (26) + la valeur de c2
            return ((int)Convert.ToByte(Char.ToLower(c1)) - 97)
                * 26 + (int)Convert.ToByte(Char.ToLower(c2)) - 97;
        }

        /// <summary>
        /// Méthode permettant de chiffrer une paire de caractère <br/>
        /// (de transposer sa position d'une valeur initiale à une autre à l'aide de la clef)
        /// </summary>
        /// <param name="c1">Premier caractère de la paire</param>
        /// <param name="c2">Second caractère de la paire</param>
        /// <param name="clef">Clef de chiffrement</param>
        /// <returns>Retourne la paire de caractères chiffrée</returns>
        public string ChiffrementPairChars(char c1, char c2, int clef)
        {
            // Chiffrement de la paire
            int paireChiffree = (CharsToInt(c1, c2) + clef ) % 676;

            // Si la paire chiffrée est inférieure à 0, on lui rajoutera 676
            if (paireChiffree < 0)
            { paireChiffree += 676; }

            // On assigne les 2 valeurs de retour ensuite à partir de la paire chiffrée
            // La valeur du second caractère de la paire prendra la valeur de la paire modulo 26 pour enlever le premier élément
            char car2Retour = Convert.ToChar((byte)((paireChiffree%26) + 97));
            // La valeur du permier sera donc la valeur de la paire chiffrée - celle du caractère 2, le tout divisé par 26 pour avoir la position du caractère actuel dans l'alphabet
            char car1Retour = Convert.ToChar((byte)((paireChiffree - (paireChiffree% 26))/26 + 97));

            // Gestion des majuscules 
            if (Char.IsUpper(c1))
            {
                car1Retour = Char.ToUpper(car1Retour);
            }
            if (Char.IsUpper(c2))
            {
                car2Retour = Char.ToUpper(car2Retour);
            }

            // On retourne le résultat 
            return car1Retour + "" + car2Retour;

        }
    }
}
