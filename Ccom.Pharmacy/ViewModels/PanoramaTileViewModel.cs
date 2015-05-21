using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.Pharmacy.Delegates;
using PanoramaControl;

namespace Ccom.Pharmacy.ViewModels
{
    public class PanoramaTileViewModel : INPCBase, IPanoramaTile
    {
        private readonly PanaromaTileData _panaromaTileData;
        public event GetSelectedPanaromaTile GetSelectedPanaromaTileEvent;
        public string Text { get; private set; }
        public string ImageUrl { get; private set; }
        public bool IsDoubleWidth { get; private set; }

        #region Properties
        private bool _isPressed;
        public bool IsPressed
        {
            get { return _isPressed; }
            set
            {
                if (_isPressed != value)
                {
                    _isPressed = value;
                    NotifyPropertyChanged("IsPressed");
                }
            }
        }
        #endregion

        public ICommand TileClickedCommand { get; private set; }

        public PanoramaTileViewModel(PanaromaTileData panaromaTileData, bool isDoubleWidth)
        {
            _panaromaTileData = panaromaTileData;
            Text = panaromaTileData.Text;
            ImageUrl = panaromaTileData.ImageUrl;
            IsDoubleWidth = isDoubleWidth;
            TileClickedCommand = new PanoramaControl.DelegateCommand<object, object>(ExecuteTileClickedCommand);
        }

        public void ExecuteTileClickedCommand(object parameter)
        {
            if (GetSelectedPanaromaTileEvent != null)
            {
                GetSelectedPanaromaTileEvent(_panaromaTileData);
            }
        }
    }
}

