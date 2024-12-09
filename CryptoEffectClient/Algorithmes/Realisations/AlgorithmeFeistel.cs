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
            messageSortie += message[15];
            messageSortie += message[6];
            messageSortie += message[19];
            messageSortie += message[20];
            messageSortie += message[28];
            messageSortie += message[11];
            messageSortie += message[27];
            messageSortie += message[16];
            messageSortie += message[0];
            messageSortie += message[14];
            messageSortie += message[22];
            messageSortie += message[25];
            messageSortie += message[4];
            messageSortie += message[17];
            messageSortie += message[30];
            messageSortie += message[9];
            messageSortie += message[1];
            messageSortie += message[7];
            messageSortie += message[23];
            messageSortie += message[13];
            messageSortie += message[31];
            messageSortie += message[26];
            messageSortie += message[2];
            messageSortie += message[8];
            messageSortie += message[18];
            messageSortie += message[12];
            messageSortie += message[29];
            messageSortie += message[5];
            messageSortie += message[21];
            messageSortie += message[10];
            messageSortie += message[3];
            messageSortie += message[24];
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
