using CryptoEffectClient.Algorithmes.Realisations;
using CryptoEffectClient.Reseaux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Challenges.Realisations.Binaire
{
    /// <summary>
    /// Challenge 5 : Déchiffrement Binaire <br/>
    /// Code : BIN5
    /// </summary>
    public class ChallengeBIN5 : IChallenge
    {
        public void Executer()
        {
            // On récupère l'instance de la connexion
            Connexion connexion = Connexion.Instance;

            // On crée une variable stockant le message actuel et la clef
            string message;
            string clef;

            // On crée une variable contenant une instance de l'algorithme binaire
            AlgorithmeBinaire algorithmeBinaire = new AlgorithmeBinaire();

            // Tant que l'on a pas atteint la fin, on continue de recevoir et d'envoyer des messages
            while ((message = connexion.RecevoirMessage()) != "FIN")
            {
                // On récupère la clef
                clef = connexion.RecevoirMessage();

                // On renvoie en message le message déchiffré en entier
                connexion.EnvoyerMessage(algorithmeBinaire.Dechiffrer(message, clef));

                // On récupère de nouveau le message
                message = connexion.RecevoirMessage();

                // Si le message chiffré est bon, on en demande un nouveau, sinon on coupe la connexion
                if (message != "OK")
                {
                    break;
                }
            }
        }
    }
}
