using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Challenges
{
    /// <summary>
    /// Interface généraique pour les challenges
    /// </summary>
    public interface IChallenge
    {
        /// <summary>
        /// Exécuter le challenge
        /// </summary>
        public void Executer();
    }
}
