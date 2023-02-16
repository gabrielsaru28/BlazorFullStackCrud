using BlazorFullStackCrud.Client.Pages;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace BlazorFullStackCrud.Server
{

    /*
     *
    The server part of the Blazor WebAssembly application is typically where the blockchain logic is implemented. 
     *
    In this part, I've create classes for the blocks and transactions, as well as for other data structures that I'll use in  Blockchain.
     *
     */


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


        /* 
         *   Nonce is a value that is used in the process of creating a new block in a blockchain. 
         *   The purpose of the nonce is to add an additional level of complexity to the block creation process, making it more difficult for someone to maliciously modify the contents of the blockchain.         
         */
        public int Nonce { get; set; }

        /*
         * Data typically refers to the payload or transaction data that is stored in a block. 
         * This can include information such as the date and time of the transaction, the identities of the participants involved, and any relevant details or conditions of the transaction.
         */
        public string Data { get; set; }



        public Block(int index, DateTime timestamp, List<Transaction> transactions, string previousBlockHash)
        {
            Index = index;
            Timestamp = timestamp;
            Transactions = transactions;
            PreviousBlockHash = previousBlockHash;
            Hash = CalculateHash();
        }


        /*
         * CalculateHash method takes the previous hash, timestamp, data, and nonce properties of the Block object, concatenates them into a single string, and then uses the SHA256 algorithm to generate a hash from that string. 
         * The resulting hash is then returned as a Base64 string.
         */

        public string CalculateHash()
        {
            // Here we calculate the hash for the block.
            // This is usually done by combining the data in the block
            // along with some additional data such as a nonce value
            // and then running that data through a hashing algorithm.
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
