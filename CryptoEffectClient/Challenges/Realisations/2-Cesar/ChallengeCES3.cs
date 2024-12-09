using CryptoEffectClient.Algorithmes.Realisations;
using CryptoEffectClient.Reseaux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Challenges.Realisations.Cesar
{
    /// <summary>
    /// Challenge 3 : Chiffrement classique <br/>
    /// Code : CES3
    /// </summary>
    public class ChallengeCES3 : IChallenge
    {
        public void Executer()
        {
            // On récupère l'instance de la connexion
            Connexion connexion = Connexion.Instance;

            // On crée 2 variables stockant le message actuel et sa clef
            string message;
            string clef;

            // On crée une variable contenant une instance de l'algorithme de César
            AlgorithmeCesar algorithmeCesar = new AlgorithmeCesar();

            // Tant que l'on a pas atteint la fin, on continue de recevoir et d'envoyer des messages
            while ((message = connexion.RecevoirMessage()) != "FIN")
            {
                // On reçoit la clef qui suit
                clef = connexion.RecevoirMessage();

                // On renvoie en message le message chiffré
                connexion.EnvoyerMessage(
                    Convert.ToString(
                        algorithmeCesar.Chiffrer(message, clef)
                        )
                    );

                // On récupère de nouveau le message
                message = connexion.RecevoirMessage();

                // Si le chiffrage est bon, on demande un nouveau message à chiffrer, sinon on coupe la connexion
                if (message != "OK")
                {
                    break;
                }
            }
        }
    }
}
