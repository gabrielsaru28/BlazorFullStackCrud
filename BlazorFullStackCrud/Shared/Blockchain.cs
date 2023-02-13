using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class Blockchain
    {
        public Block[] Chain { get; set; }

        public Blockchain()
        {
            Chain = new Block[]
            {
                new Block(0, DateTime.Now, new Transaction[0], "0")
            };
        }

        public void AddBlock(Transaction[] transactions)
        {
            var latestBlock = Chain[Chain.Length - 1];
            var nextIndex = latestBlock.Index + 1;
            var nextTimestamp = DateTime.Now;
            var nextPrevHash = latestBlock.Hash;
            var nextBlock = new Block(nextIndex, nextTimestamp, transactions, nextPrevHash);
            var newChain = new Block[Chain.Length + 1];
            Array.Copy(Chain, newChain, Chain.Length);
            newChain[Chain.Length] = nextBlock;
            Chain = newChain;
        }


        public bool IsValid()
        {
            for (int i = 1; i < Chain.Length; i++)
            {
                var currentBlock = Chain[i];
                var prevBlock = Chain[i - 1];
                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }
                if (currentBlock.PrevHash != prevBlock.Hash)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
