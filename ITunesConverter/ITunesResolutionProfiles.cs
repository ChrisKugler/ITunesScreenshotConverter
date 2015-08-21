using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITunesConverter
{
    public static class ITunesResolutionFactory
    {
        /*
         * 3.5 and 4 inch resolutions care about having the status bar or not
         * 4.7 and 5.5 have to be high resolution and have no other options
         * ipad has both HQ/LQ and status bar options. 
         * mac allows 3 resolutions, all 16:10
         */
       
        public static IDictionary<string, Size> Create(OutputOptions options)
        {
            IDictionary<string, Size> res = new Dictionary<string, Size>();         
            if (options.IncludeStatusBarArea)
            {
                if(options.Include35)
                    res.Add("3.5", options.Landscape ? new Size(960, 640) : new Size(640, 960));
                if(options.Include4)
                    res.Add("4", options.Landscape ? new Size(1136, 640) : new Size(640, 1136)); 
            }
            else
            {
                if(options.Include35)
                    res.Add("3.5", options.Landscape ? new Size(960, 600) : new Size(640, 920));
                if(options.Include4)
                    res.Add("4", options.Landscape ? new Size(1136, 600) : new Size(640, 1096)); 
            }

            if(options.Include47)
                res.Add("4.7", options.Landscape ? new Size(1334, 750) : new Size(750, 1334));
            if(options.Include55)
                res.Add("5.5", options.Landscape ? new Size(2208, 1242) : new Size(1242, 2208));

            if (options.HQ)
            {
                if (options.IncludeIPad)
                {
                    if (options.IncludeStatusBarArea)
                        res.Add("IPad", options.Landscape ? new Size(2048, 1536) : new Size(1536, 2048));
                    else
                        res.Add("IPad", options.Landscape ? new Size(2048, 1496) : new Size(1536, 2008));
                }

                if(options.IncludeMac)
                    res.Add("Mac", new Size(2880, 1800));
            }
            else
            {
                if (options.IncludeIPad)
                {
                    if (options.IncludeStatusBarArea)
                        res.Add("IPad", options.Landscape ? new Size(1024, 768) : new Size(768, 1024));
                    else
                        res.Add("IPad", options.Landscape ? new Size(1024, 748) : new Size(768, 1004));
                }
                if (options.IncludeMac) 
                    res.Add("Mac", new Size(1280, 800));
            }

            return res; 
        }        
    }
}
