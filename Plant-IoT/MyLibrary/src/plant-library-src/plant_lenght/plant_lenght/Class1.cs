/*「植物ライブラリ」＜最長点の値から伸長を求める＞*/
using System;
namespace plant_lenght
{
    public class lenght
    {
        public static double get_lenght(int pixel)
        {
            int i;
            int[] pixel_num = new int[11]{2668,2392,2132,1889,1657,1437,1228,1029,837,654,479};
            if (pixel == pixel_num[10]) return 13.0;
            else if (pixel < pixel_num[10]) return -2.0;
            if (pixel > pixel_num[0]) return -1.0;
            for (i = 9; i >= 0; i--)if (pixel <= pixel_num[i]) break;
            double result, cmp = i + (double)1 / (pixel_num[i] - pixel_num[i + 1]) * (pixel_num[i] - pixel);
            result = (double)Math.Truncate(cmp * 10.0) / 10.0 + 3;
            return result;
        }
    }
}
