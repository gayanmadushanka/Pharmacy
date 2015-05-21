using System.Collections.Generic;
using System.Windows.Data;
using Ccom.Common.Utils;
using Ccom.Pharmacy.Managers;
using Ccom.Pharmacy.Views;
using PanoramaControl;

namespace Ccom.Pharmacy.ViewModels
{
    public class OperationSelectionViewModel : INPCBase
    {
        #region Properties
        private bool _progressIsActive;
        public bool ProgressIsActive
        {
            get { return _progressIsActive; }
            set
            {
                _progressIsActive = value;
                NotifyPropertyChanged("ProgressIsActive");
            }
        }

        private IEnumerable<PanoramaGroup> _panoramaItems;
        public IEnumerable<PanoramaGroup> PanoramaItems
        {
            get { return _panoramaItems; }

            set
            {
                if (value != _panoramaItems)
                {
                    _panoramaItems = value;
                    NotifyPropertyChanged("PanoramaItems");
                }
            }
        }
        #endregion

        public OperationSelectionViewModel()
        {
            List<PanoramaGroup> data = new List<PanoramaGroup>();
            List<IPanoramaTile> tiles = new List<IPanoramaTile>();

            tiles.Add(CreateTile(new PanaromaTileData("Add Item", "", "", ""), true));
            tiles.Add(CreateTile(new PanaromaTileData("Edit Item", "", "", ""), true));
            tiles.Add(CreateTile(new PanaromaTileData("Seles", "", "", ""), true));
            tiles.Add(CreateTile(new PanaromaTileData("Stock Report", "", "", ""), true));
            tiles.Add(CreateTile(new PanaromaTileData("Invoice", "", "", ""), true));
            tiles.Add(CreateTile(new PanaromaTileData("Suplleir Details", "", "", ""), true));

            data.Add(new PanoramaGroup("", CollectionViewSource.GetDefaultView(tiles)));
            PanoramaItems = data;
            ProgressIsActive = false;
        }

        private PanoramaTileViewModel CreateTile(PanaromaTileData panaromaTileData, bool isDoubleWidth)
        {
            PanoramaTileViewModel panoramaTileViewModel = new PanoramaTileViewModel(panaromaTileData, isDoubleWidth);
            panoramaTileViewModel.GetSelectedPanaromaTileEvent += panoramaTileViewModel_GetSelectedPanaromaTileEvent;
            return panoramaTileViewModel; ;
        }

        void panoramaTileViewModel_GetSelectedPanaromaTileEvent(PanaromaTileData panaromaTileData)
        {
            GeneralDataHome operation = new GeneralDataHome();
            NavigationManager.AddView(operation);
        }
    }
}
