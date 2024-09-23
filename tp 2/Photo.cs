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

            public DateTime? DateTaken
            {
                get
                {
                    Object val = _metadata.DateTaken;
                    if (val != null)
                    {
                        return Convert.ToDateTime(_metadata.DateTaken.ToString());
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            public string? Titre
            {
                get
                {
                    Object val = _metadata.Title;
                    return (val != null ? (string)val : String.Empty);
                }
            }

            public string? Camera
            {
                get
                {
                    if (_metadata.CameraManufacturer != null && _metadata.CameraModel != null)
                    {
                        return _metadata.CameraManufacturer + " " + _metadata.CameraModel;
                    }
                    else
                    {
                        return String.Empty;
                    }
                }
            }

            public string? Application
            {
                get
                {
                    Object val = _metadata.ApplicationName;
                    return (val != null ? (string)val : String.Empty);
                }
            }

            public object? IsoSpeed
            {
                get
                {
                    Object val = QueryMetadata("/app1/ifd/exif/subifd:{uint=34855}");
                    return (val != null ? val : null);
                }
            }

            public object? IsoOpenValue
            {
                get
                {
                    Object val = QueryMetadata("app1/ifd/exif/subifd:{uint=33437}");
                    return (val != null ? ParseUnsignedRational((ulong)val) : null);
                }
            }

            public object? IsoFocalDist
            {
                get
                {
                    Object val = QueryMetadata("/app1/ifd/exif/subifd:{uint= 37386}");
                    return (val != null ? val + "mm" : null);
                }
            }


            private decimal ParseUnsignedRational(ulong exifValue)
            {
                return (decimal)(exifValue & 0xFFFFFFFFL) / (decimal)((exifValue & 0xFFFFFFFF00000000L) >> 32);
            }
            private decimal ParseSignedRational(long exifValue)
            {
                return (decimal)(exifValue & 0xFFFFFFFFL) / (decimal)((exifValue & 0x7FFFFFFF00000000L) >> 32);
            }
            private object QueryMetadata(string query)
            {
                if (_metadata.ContainsQuery(query))
                    return _metadata.GetQuery(query);
                else
                    return null;
            }

            
        }
    }
}
