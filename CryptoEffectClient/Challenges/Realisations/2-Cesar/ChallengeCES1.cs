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
    /// Challenge 1 : Conversion char/int  <br/>
    /// Code : COM2
    /// </summary>
    public class ChallengeCES1 : IChallenge
    {
        public void Executer()
        {
            // On récupère l'instance de la connexion
            Connexion connexion = Connexion.Instance;

            // On crée une variable stockant le message actuel
            string message;

            // On crée une variable contenant une instance de l'algorithme de César
            AlgorithmeCesar algorithmeCesar = new AlgorithmeCesar();

            // Tant que l'on a pas atteint la fin, on continue de recevoir et d'envoyer des messages
            while ((message = connexion.RecevoirMessage()) != "FIN")
            {
                // On renvoie en message la position dans l'alphabet du caractère renvoyé
                connexion.EnvoyerMessage(Convert.ToString(algorithmeCesar.CharToInt(message[0])));

                // On récupère de nouveau le message
                message = connexion.RecevoirMessage();

                // Si la position est bonne, on demande un nouveau caractère, sinon on coupe la connexion
                if (message != "OK")
                {
                    break;
                }
            }
        }
    }
}
