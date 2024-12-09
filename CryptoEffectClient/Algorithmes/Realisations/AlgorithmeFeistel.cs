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

            for (int i = 0; i < sbox.Length; i++) 
            {
                sbox[i] = algoBin.HexToBin(sbox[i]);
            }

            this.sbox = sbox;
            
        }


        public string Pbox(string message)
        {
            string messageSortie = "";
            List<char> sortie = new List<char>();
            sortie.Add(message[15]);
            sortie.Add(message[6]);
            sortie.Add(message[19]);
            sortie.Add(message[20]);
            sortie.Add(message[28]);
            sortie.Add(message[11]);
            sortie.Add(message[27]);
            sortie.Add(message[16]);
            sortie.Add(message[0]);
            sortie.Add(message[14]);
            sortie.Add(message[22]);
            sortie.Add(message[25]);
            sortie.Add(message[4]);
            sortie.Add(message[17]);
            sortie.Add(message[30]);
            sortie.Add(message[9]);
            sortie.Add(message[1]);
            sortie.Add(message[7]);//l18
            sortie.Add(message[23]);
            sortie.Add(message[13]);
            sortie.Add(message[31]);
            sortie.Add(message[26]);//22
            sortie.Add(message[2]);
            sortie.Add(message[8]);
            sortie.Add(message[18]);
            sortie.Add(message[12]);//26
            sortie.Add(message[29]);
            sortie.Add(message[5]);
            sortie.Add(message[21]);//29
            sortie.Add(message[10]);
            sortie.Add(message[3]);
            sortie.Add(message[24]);
            foreach (char c  in sortie)
            {
                messageSortie += c;
            }
            return messageSortie;

        }

        public string Sbox(string message)
        {
            throw new NotImplementedException();
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
