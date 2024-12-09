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
    /// Challenge 2 : Ordre des colonnes <br/>
    /// Code : TRA2
    /// </summary>
    public class ChallengeTRA2 : IChallenge
    {
        public void Executer()
        {
            // On récupère l'instance de la connexion
            Connexion connexion = Connexion.Instance;

            // On crée une variable stockant la clef
            string clef;

            // On crée une variable contenant une instance de l'algorithme de transposition
            AlgorithmeTransposition algorithme = new AlgorithmeTransposition();

            // Tant que l'on a pas atteint la fin, on continue de recevoir et d'envoyer des messages
            while ((clef = connexion.RecevoirMessage()) != "FIN")
            {
                // On récupère la liste
                List<int> listeRetour = algorithme.OrdreDesColonnes(clef);

                // On la met en forme et on l'envoie
                connexion.EnvoyerMessage( String.Join(" ", listeRetour));


                // On récupère de nouveau le message
                clef = connexion.RecevoirMessage();

                // Si la hauteur du tableau est bonne, on demande un nouveau message, sinon on coupe la connexion
                if (clef != "OK")
                {
                    break;
                }
            }
        }

    }
}
