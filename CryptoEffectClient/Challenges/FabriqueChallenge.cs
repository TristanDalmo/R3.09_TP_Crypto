using CryptoEffectClient.Challenges.Realisations;
using CryptoEffectClient.Challenges.Realisations._5_Transposition;
using CryptoEffectClient.Challenges.Realisations._6_Feistel;
using CryptoEffectClient.Challenges.Realisations.Binaire;
using CryptoEffectClient.Challenges.Realisations.Cesar;
using CryptoEffectClient.Challenges.Realisations.Communication;
using CryptoEffectClient.Challenges.Realisations.Vigenere;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoEffectClient.Challenges
{
    /// <summary>
    /// Fabrique pour les challenges
    /// </summary>
    public class FabriqueChallenge
    {
        /// <summary>
        /// Fabrique d'un challenge à partir d'un nom de code
        /// </summary>
        /// <param name="nomChallenge">Code du challenge</param>
        /// <returns>Retourne une instance du challenge à exécuter</returns>
        public IChallenge Creer(string nomChallenge)
        {
            IChallenge challenge = null;

            switch (nomChallenge)
            {
                #region 1- Communication
                case "COM1":
                    challenge = new ChallengeCOM1();
                    break;

                case "COM2":
                    challenge = new ChallengeCOM2();
                    break;

                #endregion

                #region 2- Algorithmes de César
                case "CES1":
                    challenge = new ChallengeCES1();
                    break;

                case "CES2":
                    challenge = new ChallengeCES2();
                    break;

                case "CES3":
                    challenge = new ChallengeCES3();
                    break;

                case "CES4":
                    challenge = new ChallengeCES4();
                    break;

                case "CES5":
                    challenge = new ChallengeCES5();
                    break;

                case "CES6":
                    challenge = new ChallengeCES6();
                    break;
                #endregion

                #region 3- Algorithme de Vigenère

                case "VIG1":
                    challenge = new ChallengeVIG1();
                    break;

                case "VIG2":
                    challenge = new ChallengeVIG2();
                    break;

                case "VIG3":
                    challenge = new ChallengeVIG3();
                    break;

                case "VIG4":
                    challenge = new ChallengeVIG4();
                    break;

                #endregion

                #region 4- Algorithme binaire

                case "BIN1":
                    challenge = new ChallengeBIN1();
                    break;

                case "BIN2":
                    challenge = new ChallengeBIN2();
                    break;

                case "BIN3":
                    challenge = new ChallengeBIN3();
                    break;

                case "BIN4":
                    challenge = new ChallengeBIN4();
                    break;

                case "BIN5":
                    challenge = new ChallengeBIN5();
                    break;


                #endregion

                #region 5- Algorithme de Transposition

                case "TRA1":
                    challenge = new ChallengeTRA1();
                    break;

                case "TRA2":
                    challenge = new ChallengeTRA2();
                    break;

                case "TRA3":
                    challenge = new ChallengeTRA3();
                    break;

                case "TRA4":
                    challenge = new ChallengeTRA4();
                    break;

                #endregion

                #region 6- Algorithme de Feistel

                case "FTL1":
                    challenge = new ChallengeFTL1();
                    break;

                case "FTL2":
                    challenge = new ChallengeFTL2();
                    break;

                case "FTL3":
                    challenge = new ChallengeFTL3();
                    break;

                case "FTL5":
                    challenge = new ChallengeFTL5();
                    break;


                #endregion


            }

            return challenge;
        }
    }
}
