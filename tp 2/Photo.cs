using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace tp_2
{
    internal class Photo
    {
        #region variables
        private string 
            _path;
        
        private Uri 
            _source;

        PhotoMetadata _phmetadata;
        #endregion

        #region constructeur
        public Photo(string path)
        {
            _path = path;
            _source = null;
            if (_path != "")
            { 
                _source = new Uri(path); 
            }
            
            _phmetadata = new PhotoMetadata(_source);
        }
        #endregion

        #region getter and setter
        public string Source { get { return _path; } }
        public PhotoMetadata Metadata { get { return _phmetadata; } }
        #endregion

        #region methode
        public override string ToString()
        {
            return _source.ToString();
        }
        #endregion

        public class PhotoMetadata
        {
            BitmapMetadata _metadata;
            public PhotoMetadata(Uri imageUri)
            {
                BitmapFrame frame = BitmapFrame.Create(imageUri, BitmapCreateOptions.DelayCreation, BitmapCacheOption.None);
                _metadata = (BitmapMetadata)frame.Metadata;
            }
        }
    }
}
