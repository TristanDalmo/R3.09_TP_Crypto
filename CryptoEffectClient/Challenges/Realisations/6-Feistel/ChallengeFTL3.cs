using CryptoEffectClient.Algorithmes.Realisations;
using CryptoEffectClient.Reseaux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Challenges.Realisations._6_Feistel
{
    /// <summary>
    /// Challenge 3 : Expansion Box <br/>
    /// Code : FTL3
    /// </summary>
    public class ChallengeFTL3 : IChallenge
    {
        public void Executer()
        {
            // On récupère l'instance de la connexion
            Connexion connexion = Connexion.Instance;

            // On crée une variable stockant le message
            string message;

            // On crée une variable contenant une instance de l'algorithme de Feistel
            AlgorithmeFeistel algorithme = new AlgorithmeFeistel();

            // Tant que l'on a pas atteint la fin, on continue de recevoir et d'envoyer des messages
            while ((message = connexion.RecevoirMessage()) != "FIN")
            {
                // On envoie la Expansion box de ce message
                connexion.EnvoyerMessage(algorithme.Ebox(message));

                // On récupère de nouveau le message
                message = connexion.RecevoirMessage();

                // Si le résultat est ok, on demande un nouveau message, sinon on coupe la connexion
                if (message != "OK")
                {
                    break;
                }
            }
        }


    }
}
