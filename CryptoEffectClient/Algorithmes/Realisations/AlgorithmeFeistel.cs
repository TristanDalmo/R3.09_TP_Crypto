using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace CryptoEffectClient.Algorithmes.Realisations
{
    /// <summary>
    /// Algorithme de Feistel
    /// </summary>
    public class AlgorithmeFeistel : IAlgorithme
    {
        private string[] sbox;

        public string Chiffrer(string message, string cle)
        {
            throw new NotImplementedException();
        }

        public string Dechiffrer(string message, string cle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Constructeur de la classe initialisant l'attribut sbox
        /// </summary>
        public AlgorithmeFeistel()
        {
            string[] sbox = new string[32];

            try
            {
                sbox = File.ReadAllLines("Ressources/sbox.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la lecture de sbox.txt : \n" + e.Message);
            }


            // Initialisera l’attribut sbox en lisant le fichier Sbox.txt et en convertissant chacune  des chaines hexadécimales(”0x...”) en binaire à l’aide d’une méthode codée lors de la section Opérations Binaires.
            AlgorithmeBinaire algoBin = new AlgorithmeBinaire();

            string[] sboxBin = new string[256];
            int pos = 0;

            for (int i = 0 ; i < sbox.Length; i++) 
            {
                for (int j=0; j < sbox[i].Length; j+=9)
                {
                    sboxBin[pos] += algoBin.HexToBin(sbox[i].Substring(j, 8));
                    pos++;
                }
            }

            this.sbox = sboxBin;
            
        }


        public string Pbox(string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode de substitution du message (On cherchera dans le tableau de clefs l'équivalent d'un message binaire fourni en paramètre)
        /// </summary>
        /// <param name="message">Message à transformer</param>
        /// <returns>Retourne l'image du message par la SBox (représentation binaire sur 32 bits)</returns>
        public string Sbox(string message)
        {
            string retour = "";

            AlgorithmeBinaire algoBin = new AlgorithmeBinaire();
            retour = this.sbox[algoBin.BinToInt(message)];

            return retour;
        }

        public string Ebox(string message)
        {
            throw new NotImplementedException();
        }


        public string Add(string nb1,string nb2)
        {
            throw new NotImplementedException();
        }

        public string CreationClef(string clef, int numTour)
        {
            throw new NotImplementedException();
        }

        public string F(string message, string clef)
        {
            throw new NotImplementedException();
        }

        public string TourDeChiffrement(string message, string clef, int numTour)
        {
            throw new NotImplementedException();
        }

        public string TourDeDechiffrement(string message, string clef, int numTour)
        {
            throw new NotImplementedException();
        }


    }
}
