namespace BlazorFullStackCrud.Server
{
    public class Blockchain
    {
        /*
         Chain stores a list of blocks
         */
        public List<Block> Chain { get; set; }

        public Blockchain()
        {
            Chain = new List<Block>();
            CreateGenesisBlock();
        }

        /*
         * CreateGenesisBlock method 
         *
         * Creates a new Block object with an index of 0, a timestamp of the current date and time, a null PreviousHash value, and a data value of "Genesis Block". 
         * 
         * This block is then added to the Chain property using the AddBlock method. 
         * 
         * In this way, the first block in the blockchain, also known as the "genesis block", is created when the Blockchain object is instantiated.
         *         
         */
        public void CreateGenesisBlock()
        {
            // Code to create the first block in the blockchain
            Block genesisBlock = new Block(0, DateTime.Now, null, "Genesis Block");
            AddBlock(genesisBlock);
        }


        /*
         * GetLatestBlock method 
         * 
         * Returns the latest block in the chain.
         */
        public Block GetLatestBlock()
        {
            // Code to return the latest block in the blockchain
            return Chain[Chain.Count - 1];

        }


        /*
         * AddBlock method 
         * 
         * Takes a Block object as an argument and adds it to the end of the chain, setting the PreviousHash of the new block to the Hash of the previous block.
         */
        public void AddBlock(Block block)
        {
            // Code to add a new block to the blockchain
            if (Chain.Count > 0)
            {
                block.PreviousBlockHash = Chain[Chain.Count - 1].Hash;
            }

            block.Hash = block.CalculateHash();
            Chain.Add(block);
        }


        /*
         * IsValid method 
         * 
         * Checks if the blockchain is valid by verifying the hash values and the PreviousHash values of each block in the chain.
         */
        public bool IsValid()
        {
            // Code to validate the blockchain
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if (currentBlock.PreviousBlockHash != previousBlock.Hash)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
