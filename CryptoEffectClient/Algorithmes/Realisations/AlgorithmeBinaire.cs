using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Algorithmes.Realisations
{
    /// <summary>
    /// Algorithme Binaire
    /// </summary>
    public class AlgorithmeBinaire : IAlgorithme
    {

        public string Chiffrer(string message, string cle)
        {
            string messageBinaire = HexToBin(message);
            string clefBinaire = HexToBin(cle);

            string messageChiffre = Xor(messageBinaire,clefBinaire);

            return Convert.ToString(BinToInt(messageChiffre));
        }

        public string Dechiffrer(string message, string cle)
        {
            string messageBinaire = IntToBin(Convert.ToUInt32(message));
            string clefBinaire = HexToBin(cle);

            string messageChiffre = Xor(messageBinaire, clefBinaire);

            return BinToHex(messageChiffre);
        }

        /// <summary>
        /// Effectue un XOR entre un message et sa clef
        /// </summary>
        /// <param name="message">Message à coder</param>
        /// <param name="clef">Clef</param>
        /// <returns>Retourne le message codé</returns>
        public string Xor(string message, string clef)
        {
            string retour = "";

            for (int i = 0; i < message.Length; i++)
            {
                if ((message[i] == '1' && clef[i] == '0') || (clef[i] == '1' && message[i] == '0'))
                    retour += "1";
                else
                    retour += "0";
            }

            return retour;
        }

        /// <summary>
        /// Conversion d'une chaîne binaire en une chaîne hexadécimale
        /// </summary>
        /// <param name="bin">Chaîne binaire à convertir</param>
        /// <returns>Chaîne hexadécimale renvoyée</returns>
        public string BinToHex(string bin)
        {
            return Convert.ToInt32(bin, 2).ToString("x8").TrimStart('0');
        }

        /// <summary>
        /// Conversion d'un entier non signé hexadécimal en binaire
        /// </summary>
        /// <param name="hex">Hexadécimal</param>
        /// <returns>Représentation en binaire sur 32 bits</returns>
        public string HexToBin(string hex)
        {
            return  Convert.ToString(Convert.ToUInt32(hex, 16), 2).PadLeft(32, '0');
        }

        /// <summary>
        /// Conversion d'une valeur décimale en binaire
        /// </summary>
        /// <param name="entier">Entier à convertir</param>
        /// <returns>Entier converti en binaire</returns>
        public string IntToBin(uint entier)
        {
            return Convert.ToString(entier, 2).PadLeft(32,'0');
        }

        /// <summary>
        /// Conversion d'un binaire en sa valeur décimale
        /// </summary>
        /// <param name="bin">Valeur binaire à convertir</param>
        /// <returns>Valeur décimale</returns>
        public uint BinToInt(string bin)
        {
            return Convert.ToUInt32(bin.ToString(),2);
        }


    }
}
