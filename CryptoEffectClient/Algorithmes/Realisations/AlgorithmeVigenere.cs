using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Algorithmes.Realisations
{
    /// <summary>
    /// Algorithme de Vigenère
    /// </summary>
    public class AlgorithmeVigenere : AlgorithmeCesar
    {
        /* Justification d'une implémentation de l'algorithme de César :
         * 
          L'algorithme de Vigenère utilisera les mêmes méthodes que celui de César pour ce qui est du chiffrement
        d'un caractère. La seule différence sera qu'on utilise une clef sous forme d'un nombre pour César et qu'en
        Vigenère, la clef sera un tableau de caractères. Mais pour chiffrer un caractère, on en revient au même ici :
        il faut aditionner au caractère actuel la valeur du caractère actuel de la clef, ce qui revient donc à passer
        en paramètre la clef sous forme d'un entier. 

        Le chiffrement sera donc le même caractère par caractère, seule la méthode Chiffrer(message,clef) sera différente

        Pour le déchiffrement, il faut un peu plus de théorie :
        Le tableau de Vigenère aura une structure simple : il est un tableau de 26*26 dans lequel chaque cellule
        est la somme de sa ligne et de sa colonne. Nous n'avons donc pas besoin de créer un tel tableau,
        juste de l'utiliser de façon abstraite dans le code que nous créerons, pour économiser de la mémoire.
        
        Donc finalement, le déchiffrement est le même qu'en César : il suffit de chiffrer un caractère mais avec
        une clef négative en paramètres.

        On remarque donc que l'algorithme est finalement le même qu'en César (cf code de base en commentaire de
        cette classe) et qu'il est plus pratique de simplement hériter de l'algorithme de César 
         
         */

        public string Chiffrer(string message, string cle)
        {
            // Définition d'un tableau contenant la clef 
            string clefTableau = cle;
            while (message.Length > clefTableau.Length)
            {
                clefTableau += cle;
            }

            // Une fois la clef adaptée à la bonne taille, on peut lancer le chiffrage
            string retour = "";
            
            for (int i=0; i<message.Length; i++)
            {
                retour += ChiffrerChar(message[i], CharToInt(clefTableau[i]));
            }

            return retour;

        }

        public string Dechiffrer(string message, string cle)
        {
            // Définition d'un tableau contenant la clef 
            string clefTableau = cle;
            while (message.Length > clefTableau.Length)
            {
                clefTableau += cle;
            }

            // Une fois la clef adaptée à la bonne taille, on peut lancer le chiffrage
            string retour = "";

            for (int i = 0; i < message.Length; i++)
            {
                retour += ChiffrerChar(message[i], - CharToInt(clefTableau[i]));
            }

            return retour;

        }

        /*

        /// <summary>
        /// Renvoie la position du caractère dans l'alpabet (par exemple a ou A renverra 0, b ou B renverra 1, ...)
        /// </summary>
        /// <param name="c">Caractère à traduire</param>
        /// <returns>Retourne la position de la lettre dans l'alphabet</returns>
        public int CharToInt(char c)
        {
            // L'alphabet en minuscule en ASCII va de 97 à 122
            // On le convertit en byte pour avoir la position dans l'alphabet ASCII et on lui retire 97 pour que a soit à la position 0
            return (int)Convert.ToByte(Char.ToLower(c)) - 97;
        }

        /// <summary>
        /// Méthode permettant de chiffrer une lettre à l'aide de l'algorithme de Vigenère
        /// </summary>
        /// <param name="caractereMessage">Caractère à chiffrer</param>
        /// <param name="caractereClef">Caractère clef</param>
        /// <returns>Retourne le caractère chiffré</returns>
        public char ChiffrerLettre(char caractereMessage, char caractereClef)
        {
            // On stocke une variable de retour
            char retour = caractereMessage;

            // On fait la transformation si le caractère à chiffrer est une lettre
            if (char.IsLetter(retour))
            {
                // On transformera les caractères en valeur integer qui correspondent à 
                // leur position dans l'alphabet, on utilisera des lettres minuscules

                // On stocke la position du caractère "retour" dans l'alphabet
                int positionCMessage = CharToInt(caractereMessage);

                // On stocke la position du caractère de la clef dans l'alphabet
                int positionCClef = CharToInt(caractereClef);

                // On fait la transposition pour la position du message
                positionCMessage = (positionCMessage + positionCClef) % 26;
                // Si la lettre chiffrée est inférieure à 0, on lui rajoutera 25
                if (positionCMessage < 0)
                { positionCMessage += 26; }

                // On le retransforme en caractère ensuite
                retour = Convert.ToChar((int)(positionCMessage + 97));

                // Si c'était une lettre majuscule, on la remettra en majuscule
                if (char.IsUpper(caractereMessage))
                    retour = char.ToUpper(retour);
            }

            return retour;
        }

        /// <summary>
        /// Méthode permettant de déchiffrer une lettre à l'aide de l'algorithme de Vigenère
        /// </summary>
        /// <param name="caractereMessage">Caractère à déchiffrer</param>
        /// <param name="caractereClef">Caractère clef</param>
        /// <returns>Retourne le caractère déchiffré</returns>
        public char DechiffrerLettre(char caractereMessage, char caractereClef)
        {
            // On stocke une variable de retour
            char retour = caractereMessage;

            // On fait la transformation si le caractère à chiffrer est une lettre
            if (char.IsLetter(retour))
            {
                // Le tableau de Vigenère aura une structure simple :
                // il est un tableau de 26*26 dans lequel chaque cellule
                // est la somme de sa ligne et de sa colonne.
                // Nous n'avons donc pas besoin de créer un tel tableau,
                // juste de l'utiliser de façon abstraite dans le code que
                // nous créerons, pour économiser de la mémoire.

                // On transformera les caractères en valeur integer qui correspondent à 
                // leur position dans l'alphabet, on utilisera des lettres minuscules

                // On stocke la position du caractère "retour" dans l'alphabet
                int positionCMessage = CharToInt(caractereMessage);

                // On stocke la position du caractère de la clef dans l'alphabet
                int positionCClef = CharToInt(caractereClef);

                // Dans le tableau de Vigenère, la position du caractère déchiffré
                // se trouve à la colonne correspondant à la clef, sur la ligne associée
                // au caractère chiffré.
                
                // Le calcul est donc le suivant : position de retour = position du caractère chiffré - position de la clef
                positionCMessage = (positionCMessage - positionCClef) % 26;
                // Si la lettre chiffrée est inférieure à 0, on lui rajoutera 25
                if (positionCMessage < 0)
                { positionCMessage += 26; }

                // On le retransforme en caractère ensuite
                retour = Convert.ToChar((int)(positionCMessage + 97));

                // Si c'était une lettre majuscule, on la remettra en majuscule
                if (char.IsUpper(caractereMessage))
                    retour = char.ToUpper(retour);
            }

            return retour;
        }
        */
    }
}
