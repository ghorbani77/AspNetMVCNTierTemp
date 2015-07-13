using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.DomainClasses.Settings
{
    class SocialSetting:ISettings
    {
        public SocialSetting()
		{
			ShowSocialLinksInFooter = true;
			FacebookLink = "#";
			GooglePlusLink = "#";
			TwitterLink = "#";
		}
		
		/// <summary>
        /// Gets or sets the value that determines whether social links should be show in the footer
        /// </summary>
        public bool ShowSocialLinksInFooter { get; set; }

        /// <summary>
        /// Gets or sets the facebook link
        /// </summary>
        public string FacebookLink { get; set; }

        /// <summary>
        /// Gets or sets the google plus link
        /// </summary>
        public string GooglePlusLink { get; set; }

        /// <summary>
        /// Gets or sets the twitter link
        /// </summary>
        public string TwitterLink { get; set; }

        /// <summary>
        /// Gets or sets the youtube link
        /// </summary>
        public string YoutubeLink { get; set; }
    }
}
