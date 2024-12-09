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
    /// Challenge 4 : Création des clefs <br/>
    /// Code : FTL4
    /// </summary>
    public class ChallengeFTL4 : IChallenge
    {
        public void Executer()
        {
            // On récupère l'instance de la connexion
            Connexion connexion = Connexion.Instance;

            // On crée une variable stockant la clef et le numéro du tour
            string clef;
            string tour;

            // On crée une variable contenant une instance de l'algorithme de Feistel
            AlgorithmeFeistel algorithme = new AlgorithmeFeistel();

            // Tant que l'on a pas atteint la fin, on continue de recevoir et d'envoyer des messages
            while ((clef = connexion.RecevoirMessage()) != "FIN")
            {
                // On reçoit le tour
                tour = connexion.RecevoirMessage();

                // On envoie la clef partielle générée
                connexion.EnvoyerMessage(algorithme.CreationClef(clef,Convert.ToInt32(tour)));

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
