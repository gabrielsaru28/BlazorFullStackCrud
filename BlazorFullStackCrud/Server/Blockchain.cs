namespace BlazorFullStackCrud.Server
{
    public class Blockchain
    {
        public List<Block> Chain { get; set; }

        public Blockchain()
        {
            Chain = new List<Block>();
            CreateGenesisBlock();

        }

        public void CreateGenesisBlock()
        {
            // Code to create the first block in the blockchain
            Block genesisBlock = new Block(0, DateTime.Now, null, "Genesis Block");
            AddBlock(genesisBlock);
        }

        public Block GetLatestBlock()
        {
            // Code to return the latest block in the blockchain
            return Chain[Chain.Count - 1];

        }

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
