using System.Collections.Generic;
using bulabi.Domain.Entities;

namespace bulabi.WebUI.Models {
    public class ProductsListViewModel {

        public IEnumerable<Product> Products {  get; set;}
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentCountry { get; set; }
        public string CurrentPublishSection { get; set; }
        public string CurrentTimePeriod { get; set; }
        public string CurrentChannel { get; set; }

        public List<string> Link { get; set; }
        public List<string> Title { get; set; }
        public List<string> Image { get; set; }
        public List<string> View { get; set; }
        public List<string> OriginID { get; set; } 


        public string FrameUrl { get; set; }
        public string VideoTitle { get; set; }
        public string VideoImage { get; set; }
        public string VideoView { get; set; }
        public string VideoDescription { get; set; }
        public string VideoOriginID { get; set; }

        public List<string> RelatedLink { get; set; }
        public List<string> RelatedTitle { get; set; }
        public List<string> RelatedImage { get; set; }
        public List<string> RelatedView { get; set; }
        public List<string> RelatedOriginID { get; set; } 


        public LocationFinder LocationFinder { get; set; }
    }
}