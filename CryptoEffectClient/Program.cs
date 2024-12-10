using CryptoEffectClient.Algorithmes.FichiersBinaires;
using CryptoEffectClient.Algorithmes.Realisations;
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

            /* Challenge 8
            // On crée une variable stockant la clef et le numéro du tour
            string message;
            LecteurFichierBinaire lecteur = new LecteurFichierBinaire("save.txt");
            EnregistreurFichierBinaire enregistreur = new EnregistreurFichierBinaire("save.bak");
            AlgorithmeFeistel algo = new AlgorithmeFeistel();


            while ((message = lecteur.MorceauSuivant()) != null)
            {
                Console.WriteLine(message);
                enregistreur.EcrireMorceau(algo.Chiffrer(message, "QUARIENS"));
            }

            lecteur.Fermer();
            enregistreur.Fermer();*/
        }
    }
}