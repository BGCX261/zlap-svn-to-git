using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace framework.list.common
{
    public class MD5
    {
        private Byte[] EncStringBytes; 
        private UTF8Encoding Encoder =new UTF8Encoding();   
        private MD5CryptoServiceProvider MD5Hasher =new MD5CryptoServiceProvider();   
        public  String Encrypt(String StringToEncrypt ){
            //Variable Declarations
            Random RandomGen =new Random();  
            String RandomString  = ""; 
            String MD5String ; 
            String RanSaltLoc;
          
            //Generates a Random number of under 4 digits
            while( RandomString.Length <= 3)
            {
                  RandomString = RandomString + RandomGen.Next(0, 9);
            }
            //Converts the String to bytes
            EncStringBytes = Encoder.GetBytes(StringToEncrypt + RandomString);

            //Generates the MD5 Byte Array
            EncStringBytes = MD5Hasher.ComputeHash(EncStringBytes);

            //Affixing Salt information into the MD5 Hash
            MD5String = BitConverter.ToString(EncStringBytes);
            MD5String = MD5String.Replace("-", null);

            //Finds a random location in the string to sit the salt
            RanSaltLoc = RandomGen.Next(4, MD5String.Length).ToString();

            //Shoves the salt in the location
            MD5String = MD5String.Insert (System.Convert.ToInt32(RanSaltLoc), RandomString);

            //Adds 0 for values under 10 so we always occupy 2 charater spaces
            if (System.Convert.ToInt32(RanSaltLoc) < 10)
            {
                RanSaltLoc = "0" + RanSaltLoc;
            }
            //Shoves the salt location in the string at position 3
            MD5String = MD5String.Insert(3, RanSaltLoc);

            //return s the MD5 encrypted string to the calling object
            return  MD5String;
        }
        public Boolean Verify(String _StringToVerify, String _Md5String  ) { 
           Double  SaltAddress ; 
           String  SaltID ; 
           String  NewHash ; 
            try{
                //Finds the Salt Address and Removes the Salt Address from the string
                SaltAddress =System.Convert.ToDouble( _Md5String.Substring(3, 2));
                _Md5String = _Md5String.Remove(3, 2);

                //Finds the SaltID and removes it from the string:
                SaltID = _Md5String.Substring(System.Convert.ToInt32(SaltAddress), 4);
                _Md5String = _Md5String.Remove(System.Convert.ToInt32(SaltAddress), 4);

                //Converts the string p;sed to us to Bytes
                EncStringBytes = Encoder.GetBytes(_StringToVerify + SaltID);

                //Encryptes the string p;sed to us with the salt
                EncStringBytes = MD5Hasher.ComputeHash(EncStringBytes);

                //Converts the Hash to a string
                NewHash = BitConverter.ToString(EncStringBytes);
                NewHash = NewHash.Replace("-", null);

                //Tests the NewHash against the one passed to us
                if( NewHash == _Md5String ){
                    return  true;
                }                
                else
                {
                    return false;
                }
            }
            catch 
            {
                return  false;
            }
        }
    }
}
