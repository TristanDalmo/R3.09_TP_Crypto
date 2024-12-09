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
            /*string[] sbox = new string[32];

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

            this.sbox = sbox;*/
            
        }


        public string Pbox(string message)
        {
            throw new NotImplementedException();
        }

        public string Sbox(string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode faisant le Ebox (double un caractère sur 3)
        /// </summary>
        /// <param name="message">de type string, c'est le message en binaire</param>
        /// <returns>de type string, c'est le message avec les bits doublés quand il le faut</returns>
        public string Ebox(string message)
        {
            string messageSortie = "";
            int taille = 0;
            int compteur = 2;
            while(taille<message.Length)
            {
                compteur++;
                messageSortie += message[taille];
                if (compteur >= 3) //double un bit sur 3s
                {
                    messageSortie += message[taille];
                    compteur = 0;
                }
                taille++;
            }
            return messageSortie;
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
