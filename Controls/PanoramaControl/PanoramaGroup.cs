using System.ComponentModel;

namespace PanoramaControl
{
    /// <summary>
    /// Represents a groupig of tiles
    /// </summary>
    public class PanoramaGroup
    {
        public PanoramaGroup(string header, ICollectionView tiles)
        {
            Header = header;
            Tiles = tiles;
        }

        public string Header { get; private set; }
        public ICollectionView Tiles { get; private set; }
	}
}
