using CryptoEffectClient.Reseaux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Challenges.Realisations.Communication
{
    /// <summary>
    /// Challenge 2 : Première discussion <br/>
    /// Code : COM2
    /// </summary>
    public class ChallengeCOM2 : IChallenge
    {
        public void Executer()
        {
            // On récupère l'instance de la connexion
            Connexion connexion = Connexion.Instance;

            // On crée une variable stockant le message actuel
            string message;

            // Tant que l'on a pas atteint la fin, on continue de recevoir et d'envoyer des messages
            while ((message = connexion.RecevoirMessage()) != "FIN")
            {
                // On renvoie en message le double de la valeur envoyée par le serveur
                connexion.EnvoyerMessage(Convert.ToString(Convert.ToInt32(message) * 2));

                // On récupère de nouveau le message
                message = connexion.RecevoirMessage();

                // Si le calcul est bon, on demande un nouveau nombre, sinon on coupe la connexion
                if (message != "OK")
                {
                    break;
                }
            }



        }
    }
}
