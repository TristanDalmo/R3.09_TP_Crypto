using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Reseaux
{
    /// <summary>
    /// Connexion réseau (Pattern : Singleton)
    /// </summary>
    public class Connexion
    {
        #region Pattern du Singleton
        //Instance du singleton
        private static Connexion instance;

        /// <summary>
        /// Getter de l'instance du singleton
        /// </summary>
        public static Connexion Instance {
            get
            {
                if (instance == null)
                    instance = new Connexion();
                return instance;
            }
        }

        /// <summary>
        /// Constructeur privé du singleton
        /// </summary>
        private Connexion()
        {
            //Créer le client TCP à partir d'une adresse IP et de son port (ici, on prend en localhost sur le port 1234)
            this.client = new TcpClient("127.0.0.1", 1234);

            //Créer les flux (in et out)
            this.fluxEntrant = new StreamReader(this.client.GetStream());
            this.fluxSortant = new StreamWriter(this.client.GetStream())
            {
                // Permet d'automatiquement flush à chaque appel de StreamWriter
                AutoFlush = true
            };
        }
        #endregion

        #region Attributs
        /// <summary>
        /// Client TCP
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// Le flux entrant depuis le serveur
        /// </summary>
        private StreamReader fluxEntrant;

        /// <summary>
        /// Le flux sortant vers le serveur
        /// </summary>
        private StreamWriter fluxSortant;
        #endregion

        #region Recevoir et envoyer un message au serveur
        /// <summary>
        /// Envoyer un message au serveur
        /// </summary>
        /// <param name="message">Message à envoyer</param>
        public void EnvoyerMessage(string message)
        {
            Console.WriteLine(">> " + message);
            this.fluxSortant.WriteLine(message);
        }

        /// <summary>
        /// Recevoir un message du serveur
        /// </summary>
        /// <returns>Le message du serveur</returns>
        public string RecevoirMessage()
        {
            String message = this.fluxEntrant.ReadLine();
            Console.WriteLine("<< " + message);
            return message;
        }
        #endregion

        #region Fermer la connexion (NE PAS MODIFIER CETTE METHODE)
        public void FermerConnexion()
        {
            if (this.fluxEntrant != null) this.fluxEntrant.Close();
            if (this.fluxSortant != null) this.fluxSortant.Close();
            if (this.client != null) this.client.Close();
        }
        #endregion

    }
}
