using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptography
{
    public static class CryptoSettings
    {
        #region Private Variable

        private static string passPhrase = "MS";        // can be any string
        private static string saltValue = "EHRMS";        // can be any string
        private static string hashAlgorithm = "MD5";             // can be "MD5 | SHA1"
        private static int passwordIterations = 1;                  // can be any number
        private static string initVector = "MANAVSAMPADAHRMS"; // must be 16 bytes
        private static int keySize = 128;                // can be 192 or 128 or 256

        #endregion

        #region Public Properties

        /// <summary>
        /// Get PassPhrase value
        /// </summary>
        public static string PassPhrase
        {
            get { return passPhrase; }
        }

        public static string SaltValue
        {
            get { return saltValue; }
        }

        public static string HashAlgorithm
        {
            get { return hashAlgorithm; }
        }

        public static int PasswordIterations
        {
            get { return passwordIterations; }
        }

        public static string InitVector
        {
            get { return initVector; }
        }

        public static int KeySize
        {
            get { return keySize; }
        }

        #endregion
    }
}
