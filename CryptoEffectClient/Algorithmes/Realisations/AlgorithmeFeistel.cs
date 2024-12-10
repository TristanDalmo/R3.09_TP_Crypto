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
            string retour = message;

            for (int i = 1; i<3;i++)
            {
                retour = TourDeChiffrement(retour, cle, i);
            }

            return retour;
        }

        public string Dechiffrer(string message, string cle)
        {
            string retour = message;

            for (int i = 2; i > 0; i--)
            {
                retour = TourDeDechiffrement(retour, cle, i);
            }

            return retour;
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
        /// Méthode de substitution du message (On cherchera dans le tableau de clefs l'équivalent d'un message binaire fourni en paramètre)
        /// </summary>
        /// <param name="message">Message à transformer</param>
        /// <returns>Retourne l'image du message par la SBox (représentation binaire sur 32 bits)</returns>
        public string Sbox(string message)
        {
            return this.sbox[(new AlgorithmeBinaire()).BinToInt(message)];
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

        /// <summary>
        /// réaliser l’addition modulo 2^32
        /// </summary>
        /// <param name="nb1"></param>
        /// <param name="nb2"></param>
        /// <returns>le resultat</returns>
        public string Add(string nb1,string nb2)
        {
            AlgorithmeBinaire algorithmeBinaire = new AlgorithmeBinaire();
            uint res = algorithmeBinaire.BinToInt(nb1) + algorithmeBinaire.BinToInt(nb2);
            return algorithmeBinaire.IntToBin(res);
        }

        /// <summary>
        /// Méthode de création d'une clef à partir du numéro de tour
        /// </summary>
        /// <param name="clef">Clef à transformer</param>
        /// <param name="numTour">Numéro du tour</param>
        /// <returns>Retourne une clef partielle</returns>
        public string CreationClef(string clef, int numTour)
        {
            string retour = "";

            AlgorithmeCesar algoCesar = new AlgorithmeCesar();
            AlgorithmeVigenere algoVig = new AlgorithmeVigenere();

            retour = algoCesar.Chiffrer(clef, Convert.ToString(numTour));
            retour = algoVig.Chiffrer(retour, clef);

            return retour;
        }
        /// <summary>
        /// Réalise un pbox puis un sBox sur les 8 premiers bits, un eBox sur les 24 derniers bits, on chiffre avec la transposition le ebox puis on additionne avec un module 2^32
        /// </summary>
        /// <param name="message"></param>
        /// <param name="clef"></param>
        /// <returns></returns>
        public string F(string message, string clef)
        {
            string messagePBox=Pbox(message);
            string messageSBox=Sbox(messagePBox.Substring(0, 8));
            string messageEBox=Ebox(messagePBox.Substring(8, 24));
            AlgorithmeTransposition algorithmeTransposition = new AlgorithmeTransposition();
            messageEBox = algorithmeTransposition.Chiffrer(messageEBox, clef);
            return Add(messageSBox, messageEBox);
        }

        /// <summary>
        /// Représente un tour de chiffrement de l'algorithme
        /// </summary>
        /// <param name="message">Message à l'étape i</param>
        /// <param name="clef">Clef de l'algorithme</param>
        /// <param name="numTour">Numéro du tour</param>
        /// <returns>Retourne le message à la fin du tour</returns>
        public string TourDeChiffrement(string message, string clef, int numTour)
        {
            string message1 = message.Substring(0, 32);
            string message2 = message.Substring(32);

            message2 = (new AlgorithmeBinaire()).Xor(F(message1,CreationClef(clef,numTour)), message2);

            return message2 + message1;

        }

        /// <summary>
        /// Représente un tour de déchiffrement de l'algorithme
        /// </summary>
        /// <param name="message">Message à l'étape i</param>
        /// <param name="clef">Clef de l'algorithme</param>
        /// <param name="numTour">Numéro du tour</param>
        /// <returns>Retourne le message déchiffré à l'étape i</returns>
        public string TourDeDechiffrement(string message, string clef, int numTour)
        {
            string message2 = message.Substring(0, 32);
            string message1 = message.Substring(32);

            message2 = (new AlgorithmeBinaire()).Xor(F(message1,CreationClef(clef,numTour)), message2);

            return message1 + message2;
        }


    }
}
