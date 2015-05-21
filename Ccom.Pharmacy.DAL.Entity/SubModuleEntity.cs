using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{
    [DataContract]
    public class SubModuleEntity
    {
        private int _id = -1;
        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name = string.Empty;
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _color = string.Empty;
        [DataMember]
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private string _imagePath = string.Empty;
        [DataMember]
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }

        private string _toolTip = string.Empty;
        [DataMember]
        public string ToolTip
        {
            get { return _toolTip; }
            set { _toolTip = value; }
        }

        [DataMember]
        public int ModuleId { get; set; }

        private string _pathToLoad = string.Empty;
        [DataMember]
        public string PathToLoad
        {
            get { return _pathToLoad; }
            set { _pathToLoad = value; }
        }
    }
}

