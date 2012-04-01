using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RssNewsEngine.Models
{
    public class NewsComponents
    {
        public NewsComponents()
        {
            NewsID = Guid.NewGuid();

        }
        public Guid NewsID
        {
            get;
            set;
        }
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string SummaryContent { get; set; }
        public string Imagelabel { get; set; }
        public string BucketName
        {
            get;
            set;
        }
        public string Source
        {
            get;
            set;
        }
        public string Section
        {
            get;
            set;
        }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string NewsItem
        {
            get;
            set;
        }
        public string Publish
        {
            get;
            set;
        }
        public string NewsHeadline
        {
            get;
            set;
        }
        public DateTime NewsAdded
        {
            get;
            set;
        }
        private string _newsPhotoUrl = "";
        public string NewsPhotoUrl
        {
            get
            {
                return _newsPhotoUrl;
            }
            set
            {
                _newsPhotoUrl = value;
            }
        }
        public string Summary
        {
            get;
            set;
        }
        public string Category
        {
            get;
            set;
        }
        public String Country
        {
            get;
            set;
        }
        public DateTime TimeStamp
        {
            get;
            set;
        }
        private List<Images> images;
        public List<Images> Images
        {
            get
            {
                if (images == null)
                    images = new List<Images>();
                return images;
            }
            set
            {
                images = value;
            }
        }
        


    }
    public class Images
    {
        public Stream photostreams
        {
            get;
            set;
        }
        public string fileName
        {
            get;
            set;
        }
        public string Url
        {
            get;
            set;
        }
    }
    public class Multimedia
    {
        public Guid VideoId
        {
            get; 
            set;
        }

        public string Category { get; set; }
        public string YoutubeUrl
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }

        public Boolean Publish { get; set; }
        public DateTime YouTubeAdded { get; set; }
        public string Country { get; set; }
    }
}