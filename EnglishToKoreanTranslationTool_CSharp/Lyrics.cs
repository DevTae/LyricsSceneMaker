using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishToKoreanTranslationTool_CSharp
{
    class Lyrics
    {
        Boolean isSuccess;
        string engLyrics;
        string korLyrics;

        public Lyrics(Boolean isSuccess, string engLyrics, string korLyrics)
        {
            this.isSuccess = isSuccess;
            this.engLyrics = engLyrics;
            this.korLyrics = korLyrics;
        }
    }
}
