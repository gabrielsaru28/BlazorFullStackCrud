using BlazorFullStackCrud.Client.Pages;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace BlazorFullStackCrud.Server
{
    /*
     * Block class has properties for the block's index, timestamp, data, previous hash, hash, and nonce. 
     *
     * The CalculateHash method takes these properties and calculates a hash value based on their combined values. 
     *
     * The implementation of the Sha256 method uses the SHA-256 hash algorithm to calculate the hash value. 
     */

    public class Block
    {
        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public List<Transaction> Transactions { get; set; }
        public string PreviousBlockHash { get; set; }
        public string Hash { get; set; }

        // Properties added for CalculateHashmethod 
        public int Nonce { get; set; }
        public string Data { get; set; }



        public Block(int index, DateTime timestamp, List<Transaction> transactions, string previousBlockHash)
        {
            Index = index;
            Timestamp = timestamp;
            Transactions = transactions;
            PreviousBlockHash = previousBlockHash;
            Hash = CalculateHash();
        }

        public string CalculateHash()
        {
            string dataToHash = PreviousBlockHash + Timestamp + Data + Nonce;
            SHA256 sha256 = SHA256.Create();
            byte[] hashData = sha256.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));
            return Convert.ToBase64String(hashData);
        }

        private static string Sha256(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha256.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }

    }
}
