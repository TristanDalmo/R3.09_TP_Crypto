﻿using CryptoEffectClient.Algorithmes.Realisations;
using CryptoEffectClient.Reseaux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Challenges.Realisations.Vigenere
{
    /// <summary>
    /// Challenge 3 : Déchiffrement caractère <br/>
    /// Code : VIG3
    /// </summary>
    public class ChallengeVIG3 : IChallenge
    {
        public void Executer()
        {
            // On récupère l'instance de la connexion
            Connexion connexion = Connexion.Instance;

            // On crée une variable stockant le message actuel et une autre pour stocker la clef
            string message;
            string clef;

            // On crée une variable contenant une instance de l'algorithme de Vigenère
            AlgorithmeVigenere algorithmeVigenere = new AlgorithmeVigenere();

            // Tant que l'on a pas atteint la fin, on continue de recevoir et d'envoyer des messages
            while ((message = connexion.RecevoirMessage()) != "FIN")
            {
                // On reçoit la clef
                clef = connexion.RecevoirMessage();

                // On renvoie en message le caractère déchiffré par Vigenère
                connexion.EnvoyerMessage(Convert.ToString(algorithmeVigenere.ChiffrerChar(message[0], -algorithmeVigenere.CharToInt(clef[0]))));

                // On récupère de nouveau le message
                message = connexion.RecevoirMessage();

                // Si le caractère déchiffré est bon, on demande un nouveau caractère, sinon on coupe la connexion
                if (message != "OK")
                {
                    break;
                }
            }
        }
    }
}
