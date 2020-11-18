using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokeka
{
    class CardInfo
    {
        private enum CATEGORY
        {
            POKEMON,
            GOODS,
            SUPPORT,
            STUDIUM,
            ENERGY,
        }

        public string Name { set; get; } //カード名
        public string Category { set; get; } //カテゴリー
        public string PictPass { set; get; } //画像パス
        public int Num { set; get; }  //枚数

        public void SetCardInfo(string fileName, string pass)
        {
            Name = fileName.Replace(".jpg", "");
            PictPass = pass;
            Num = 1;

            string[] cstegoArray = { "ポケモン", "グッズ", "サポート", "スタジアム", "エネルギー" };

            if (pass.Replace(fileName, "").Contains("ポケモン")) { Category = cstegoArray[(int)CATEGORY.POKEMON]; }
            if (pass.Replace(fileName, "").Contains("グッズ")) { Category = cstegoArray[(int)CATEGORY.GOODS]; }
            if (pass.Replace(fileName, "").Contains("サポート")) { Category = cstegoArray[(int)CATEGORY.SUPPORT]; }
            if (pass.Replace(fileName, "").Contains("スタジアム")) { Category = cstegoArray[(int)CATEGORY.STUDIUM]; }
            if (pass.Replace(fileName, "").Contains("エネルギー")) { Category = cstegoArray[(int)CATEGORY.ENERGY]; }
        }

        public void DeleteCardInfo()
        {
            Name = "";
            Category = "";
            PictPass = "";
            Num = 0;
        }
    }
}
