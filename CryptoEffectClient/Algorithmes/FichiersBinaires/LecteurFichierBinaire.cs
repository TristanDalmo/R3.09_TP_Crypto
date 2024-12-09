using System;
using System.IO;

namespace CryptoEffectClient.Algorithmes.FichiersBinaires
{
    /// <summary>
    /// Lecteur de fichier binaire
    /// </summary>
    public class LecteurFichierBinaire
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
        public LecteurFichierBinaire(string nom)
        {
            this.nom = nom;
            this.stream = new FileStream(@"Resources\"+this.nom, FileMode.Open, FileAccess.Read);
        }

        /// <summary>
        /// Renvoie morceau de 64 bits suivants sous forme d'une chaine de caractères
        /// </summary>
        /// <returns>Une chaine de 64 caractères (0 ou 1) </returns>
        public string MorceauSuivant()
        {
            string res = null;
            byte[] block = new byte[8];
            if(stream != null && stream.Read(block, 0, 8)>0)
            {
                res = "";
                for(int i=0;i<8;i++)
                {
                    res += Convert.ToString(block[i], 2).PadLeft(8, '0');
                }
            }
            return res;
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
