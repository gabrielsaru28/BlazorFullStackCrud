using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace BlazorFullStackCrud.Shared
{
    public class Block
    {
        /*
         *The Block class has properties for the block's index, timestamp, data, previous hash, hash, and nonce. 
         *
         *The CalculateHash method takes these properties and calculates a hash value based on their combined values. 
         *
         *The implementation of the Sha256 method uses the SHA-256 hash algorithm to calculate the hash value.
         */

        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public Transaction[] Transactions { get; set; }
        public string PrevHash { get; set; }
        public string Hash { get; set; }


        public Block(int index, DateTime timestamp, Transaction[] transactions, string prevHash)
        {
            Index = index;
            Timestamp = timestamp;
            Transactions = transactions;
            PrevHash = prevHash;
            Hash = CalculateHash();
        }


        public string CalculateHash()
        {
            var hash = SHA256.Create();
            var inputBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this));
            var hashBytes = hash.ComputeHash(inputBytes);

            var sb = new StringBuilder();

            foreach (var hashByte in hashBytes)
            {
                sb.Append(hashByte.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
