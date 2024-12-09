using CryptoEffectClient.Algorithmes.Realisations;
using CryptoEffectClient.Reseaux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Challenges.Realisations._5_Transposition
{
    /// <summary>
    /// Challenge 4 : Déchiffrement <br/>
    /// Code : TRA4
    /// </summary>
    public class ChallengeTRA4 : IChallenge
    {
        public void Executer()
        {
            // On récupère l'instance de la connexion
            Connexion connexion = Connexion.Instance;

            // On crée une variable stockant le message actuel et la clef
            string message;
            string clef;

            // On crée une variable contenant une instance de l'algorithme de transposition
            AlgorithmeTransposition algorithme = new AlgorithmeTransposition();

            // Tant que l'on a pas atteint la fin, on continue de recevoir et d'envoyer des messages
            while ((message = connexion.RecevoirMessage()) != "FIN")
            {
                // On récupère la clef
                clef = connexion.RecevoirMessage();

                // On renvoie en message le message déchiffré en entier
                connexion.EnvoyerMessage(algorithme.Dechiffrer(message, clef));

                // On récupère de nouveau le message
                message = connexion.RecevoirMessage();

                // Si le message déchiffré est bon, on en demande un nouveau, sinon on coupe la connexion
                if (message != "OK")
                {
                    break;
                }
            }
        }
    }
}
