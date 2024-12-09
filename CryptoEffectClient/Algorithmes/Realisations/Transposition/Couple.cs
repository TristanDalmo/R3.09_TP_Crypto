using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Algorithmes.Realisations.Transposition
{
    /// <summary>
    /// Classe correspondant à un couple caractère/entier <br/>
    /// correspondant à un caractère et sa position dans la clef fournie
    /// </summary>
    public class Couple : IComparable<Couple>
    {
        // Caractère du couple
        private char caractere;

        // Position du caractère dans la clef
        private readonly int position;

        /// <summary>
        /// Getter de la position du caractère dans la clef
        /// </summary>
        public int Position { get { return position; } }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="caractere">Caractère du couple</param>
        /// <param name="position">Position du caractère dans la clef</param>
        public Couple(char caractere, int position)
        {
            this.caractere = caractere;
            this.position = position;
        }

        public int CompareTo(Couple? other)
        {
            int retour = 0;

            // On ne compare que s'il s'agit bel et bien d'un couple
            if (other is Couple)
            {
                retour = Convert.ToByte(other.caractere) - Convert.ToByte(this.caractere);
            }

            return retour;
                
        }
    }
}
