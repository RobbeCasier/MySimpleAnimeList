using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleAnimeList.Model
{
    public enum AnimeType
    {
        NORMAL,
        OVA,
        ONA,
        MOVIE
    }

    class AnimeItem
    {
        public string ENName { get; set; }
        public string JPCNName { get; set; }
        public int NrEpisodes { get; set; }
        public int Season { get; set; }
        public bool NewSerie { get; set; }
    }
}
