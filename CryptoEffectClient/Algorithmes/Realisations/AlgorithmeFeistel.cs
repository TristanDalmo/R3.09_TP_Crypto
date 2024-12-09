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

            this.sbox = sbox;
            
        }

        /// <summary>
        /// function pBox qui inverse les positions selon une certaines façon
        /// </summary>
        /// <param name="message">message à changer les positions</param>
        /// <returns>message avec les caractères inversé</returns>
        public string Pbox(string message)
        {
            string messageSortie = "";
            List<int> pos = [15,6,19,20,28,11,27,16,0,14,22,25,4,17,30,9,1,7,23,13,31,26,2,8,18,12,29,5,21,10,3,24];
            foreach (int i in pos)
            {
                messageSortie+= message[i];
            }
            return messageSortie;

        }

        /// <summary>
        /// Méthode de substitution du message
        /// </summary>
        /// <param name="message">Message à transformer</param>
        /// <returns>Retourne l'image du message par la SBox (représentation binaire sur 32 bits)</returns>
        public string Sbox(string message)
        {
            string retour = "";

            AlgorithmeBinaire algoBin = new AlgorithmeBinaire();
            string messageBin = algoBin.IntToBin(Convert.ToUInt32(message));

            retour += algoBin.Xor(retour, sbox[0]);

            return retour;
        }

        public string Ebox(string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// réaliser l’addition modulo 2^32
        /// </summary>
        /// <param name="nb1"></param>
        /// <param name="nb2"></param>
        /// <returns>le resultat</returns>
        public string Add(string nb1,string nb2)
        {
            AlgorithmeBinaire algorithmeBinaire = new AlgorithmeBinaire();
            uint res = algorithmeBinaire.BinToInt(nb1) + algorithmeBinaire.BinToInt(nb2) % (uint)Math.Pow(2, 32);
            return algorithmeBinaire.IntToBin(res);
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
