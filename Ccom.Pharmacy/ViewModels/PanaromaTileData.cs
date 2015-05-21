
namespace Ccom.Pharmacy.ViewModels
{
    public class PanaromaTileData
    {
        public string Text { get; private set; }
        public string ImageUrl { get; private set; }
        public string TileColor { get; private set; }
        public string NameSpace { get; private set; }
        public PanaromaTileData(string text, string imageUrl, string tileColor, string nameSpace)
        {
            Text = text;
            ImageUrl = imageUrl;
            TileColor = tileColor;
            NameSpace = nameSpace;
        }
    }
}
