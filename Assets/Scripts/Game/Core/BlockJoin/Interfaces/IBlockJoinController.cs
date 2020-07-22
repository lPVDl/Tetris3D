namespace Game.Core.BlockJoin
{
    public interface IBlockJoinController
    {
        /// <summary>
        /// Joins falling block segments with level blocks. Removes falling block.
        /// </summary>
        void JoinBlock();
    }
}
