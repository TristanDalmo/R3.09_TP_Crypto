using CryptoEffectClient.Challenges;
using CryptoEffectClient.Reseaux;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialisation de la connexion au serveur
            Connexion connexion = Connexion.Instance;

            // Création du challenge
            FabriqueChallenge fabrique = new FabriqueChallenge();
            IChallenge challenge = fabrique.Creer(connexion.RecevoirMessage());

            // Exécution du challenge
            challenge.Executer();

            // Fermeture de la connexion
            connexion.FermerConnexion();
        }
    }
}