using System;
using System.Collections.Generic;
using System.Text;

namespace framework.list.common
{
    public class RSA
    {
        static long N = 8989;    //* n = pq where p and q are distinct primes.
        //static long Phi = 8800;    //* phi, φ = (p-1)(q-1)
        static long E = 3;    //* e < n such that gcd(e, phi)=1
        static long D = 5867;

    //    Summary of RSA
        

    //* d = e^-1 mod phi.
    //* c = m^e mod n, 1<m<n.
    //* m = c^d mod n.


   //        1. Generate two large random primes, p and q, of approximately equal size such that their product n = pq is of the required bit length, e.g. 1024 bits. [See note 1].
   //2. Compute n = pq and (φ) phi = (p-1)(q-1).
   //3. Choose an integer e, 1 < e < phi, such that gcd(e, phi) = 1. [See note 2].
   //4. Compute the secret exponent d, 1 < d < phi, such that
   //   ed ≡ 1 (mod phi). [See note 3].
   //5. The public key is (n, e) and the private key is (n, d). The values of p, q, and phi should also be kept secret.

   // * n is known as the modulus.
   // * e is known as the public exponent or encryption exponent.
   // * d is known as the secret exponent or decryption exponent.

        public static long Encrypt(long numberToEncrypt)
        {
            //E = FindE(Phi);
            return GCD(numberToEncrypt, E, N);
        }

        public static long Decrypt(long NumberToDecrypt)
        {
            //E = FindE(Phi);
            //D = FindD(E, Phi);
            return GCD(NumberToDecrypt, D, N);
        }

        //private static long FindD(long E, long Phi)
        //{
        //    for (long d = 2; d < Phi; d++)
        //    {
        //        if (GCD(d * E, 1, Phi) == 1)
        //            return d;
        //    }
        //    return 0;
        //}

        //private static long FindE(long Phi)
        //{
        //    for (long e = 2; e < Phi; e++)
        //    {
        //        if (USCLL(e, Phi) == 1)
        //            return e;
        //    }
        //    return 0;
        //}

        public static long USCLL(long a, long b)
        {
            if (b == 0)
                return a;
            else return USCLL(b, a % b);
        }

        /// <summary>
        /// gcd=m^n mod phi
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static long GCD(long m, long n, long phi)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                long n1 = n % 2;
                if (n1 != 0)//n le=1
                {
                    return ((m % phi) * GCD(m, n - 1, phi)) % phi ;
                }
                else// n chan
                {
                    long t = GCD(m, n / 2, phi);
                    return (t * t) % phi ;
                }
            }
        }

        public static string EncryptString(string str)
        {
            string tmp = "";
            foreach (char char1 in str)
            {
                int i= char1;
                tmp   = tmp + Encrypt(i).ToString () + "_";
            }
            tmp = tmp.Substring(0, tmp.Length - 1);
            return tmp;
        }

        public static string DecryptString(string str)
        {
            string result = "";
            string[] tmp;
            tmp = str.Split('_');
            foreach (string stri in tmp)
            {
                long M = Convert.ToInt64(stri);
                M = Decrypt(M);
                result = result + (char)M;
            }
            return result;
        }
    }
}
