﻿using CryptoEffectClient.Algorithmes.Realisations;
using CryptoEffectClient.Reseaux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Challenges.Realisations._6_Feistel
{
    /// <summary>
    /// Challenge 6 : Création des clefs <br/>
    /// Code : FTL6
    /// </summary>
    public class ChallengeFTL6 : IChallenge
    {
        public void Executer()
        {
            // On récupère l'instance de la connexion
            Connexion connexion = Connexion.Instance;

            // On crée une variable stockant la clef et le numéro du tour
            string clef;
            string message;

            // On crée une variable contenant une instance de l'algorithme de Feistel
            AlgorithmeFeistel algorithme = new AlgorithmeFeistel();

            // Tant que l'on a pas atteint la fin, on continue de recevoir et d'envoyer des messages
            while ((message = connexion.RecevoirMessage()) != "FIN")
            {
                // On reçoit le clé
                clef = connexion.RecevoirMessage();

                // On chiffre le message avec la clé
                connexion.EnvoyerMessage(algorithme.Chiffrer(message, clef));

                // On récupère de nouveau le message
                clef = connexion.RecevoirMessage();

                // Si le résultat est ok, on demande un nouveau message, sinon on coupe la connexion
                if (clef != "OK")
                {
                    break;
                }
            }
        }
    }
}