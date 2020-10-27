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

        public string name = ""; //カード名
        public string category = ""; //カテゴリー
        public string pictPass = ""; //画像パス
        public int num = 0;  //枚数

        private string[] cstegoArray = { "ポケモン", "グッズ", "サポート", "スタジアム", "エネルギー" };

        public void SetCardInfo(string fileName, string pass)
        {
            name = fileName.Replace(".jpg", "");
            pictPass = pass;
            num = 1;

            if (pass.Replace(fileName, "").Contains("ポケモン")) { category = cstegoArray[(int)CATEGORY.POKEMON]; }
            if (pass.Replace(fileName, "").Contains("グッズ")) { category = cstegoArray[(int)CATEGORY.GOODS]; }
            if (pass.Replace(fileName, "").Contains("サポート")) { category = cstegoArray[(int)CATEGORY.SUPPORT]; }
            if (pass.Replace(fileName, "").Contains("スタジアム")) { category = cstegoArray[(int)CATEGORY.STUDIUM]; }
            if (pass.Replace(fileName, "").Contains("エネルギー")) { category = cstegoArray[(int)CATEGORY.ENERGY]; }
        }

        public void DeleteCardInfo()
        {
            name = "";
            category = "";
            pictPass = "";
            num = 0;
        }
    }
}
