using System;
using System.IO;

namespace CryptoEffectClient.Algorithmes.FichiersBinaires
{
    /// <summary>
    /// Enregistreur de fichier binaire
    /// </summary>
    public class EnregistreurFichierBinaire
    {
        /// <summary>
        /// Nom du fichier
        /// </summary>
        private string nom;
        private FileStream stream;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Nom du fichier</param>
        public EnregistreurFichierBinaire(string nom)
        {
            this.nom = nom;
            this.stream = File.Create(@"Ressources\" + this.nom);
        }

        /// <summary>
        /// Ecrit dans le fichier un bloc de 64bits (donné sous forme d'une chaine de caractères)
        /// </summary>
        /// <param name="binaryString">Une chaine de 64 caractères (0 ou 1) à ajouter au fichier</param>
        public void EcrireMorceau(string binaryString)
        {
            int numOfBytes = binaryString.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; i++)
            {
                this.stream.WriteByte(Convert.ToByte(binaryString.Substring(8 * i, 8), 2));
            }
        }

        /// <summary>
        /// Ferme le fichier
        /// </summary>
        public void Fermer()
        {
            stream.Close();
            stream = null;
        }
    }
}
