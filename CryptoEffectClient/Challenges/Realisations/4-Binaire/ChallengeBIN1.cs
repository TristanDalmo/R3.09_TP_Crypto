using CryptoEffectClient.Algorithmes;
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
    /// Challenge 1 : Hexadécimal vers binaire <br/>
    /// Code : BIN1
    /// </summary>
    public class ChallengeBIN1 : IChallenge
    {
        public void Executer()
        {
            // On récupère l'instance de la connexion
            Connexion connexion = Connexion.Instance;

            // On crée une variable stockant le message actuel 
            string message;

            // On crée une variable contenant une instance de l'algorithme binaire
            AlgorithmeBinaire algorithmeBinaire = new AlgorithmeBinaire();

            // Tant que l'on a pas atteint la fin, on continue de recevoir et d'envoyer des messages
            while ((message = connexion.RecevoirMessage()) != "FIN")
            {
                // On renvoie en message le caractère traduit en binaire
                connexion.EnvoyerMessage(algorithmeBinaire.HexToBin(message));

                // On récupère de nouveau le message
                message = connexion.RecevoirMessage();

                // Si le caractère traduit est bon, on demande un nouveau caractère, sinon on coupe la connexion
                if (message != "OK")
                {
                    break;
                }
            }
        }
    }
}
