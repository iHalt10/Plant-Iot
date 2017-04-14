// plant_gridpicture.h
/*
「植物ライブラリ」
OpenCVライブラリを使用しています。
コード自体は見ることができると思いますが、エラー非表示・ビルド等をする際には項目２の
「コートレビュについて」=>「①」を参考に設定してください。
＜リサイズ画像で罫線ある画像を生成＞
*/
#pragma once
#include<opencv2/opencv.hpp>
#pragma comment(lib,"opencv_world310.lib")

using namespace cv;
using namespace System;
using namespace System::Runtime::InteropServices;

namespace plant_gridpicture {

	public ref class gridpicture
	{
		// TODO: このクラスの、ユーザーのメソッドをここに追加してください。
	public:
		static void make(int pixel, System::String^ pass_s, System::String^ make_pass_s) {
			//C#でこのライブラリを使用するため型変換をする
			char* pass = (char*)Marshal::StringToHGlobalAnsi(pass_s).ToPointer();
			char* make_pass = (char*)Marshal::StringToHGlobalAnsi(make_pass_s).ToPointer();
			int lkup_pic[12] = { 119, 163, 209, 257, 307, 359, 414, 472, 533, 598, 667, 740 };
			int lkup_num[12] = { 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1 };
			Mat src = imread(pass);
			Vec3b r = Vec3b(0, 0, 255);
			Vec3b b = Vec3b(255, 0, 0);
			Vec3b gr = Vec3b(0, 255, 255);
			for (int i = 0; i < 12; i++) {
				for (int j = 1; j <= lkup_num[i]; j++, lkup_pic[i]--) {
					if (i == 2 || i == 5)for (int k = 0; k < src.cols; k++)src.at<Vec3b>(lkup_pic[i], k) = gr;
					else for (int k = 0; k < src.cols; k++)src.at<Vec3b>(lkup_pic[i], k) = r;
				}
			}
			if (pixel >= lkup_pic[0] && pixel <= lkup_pic[10])
				for (int i = 0; i < 2; i++, pixel--)for (int j = 0; j < src.cols; j++)src.at<Vec3b>(pixel, j) = b;
			imwrite(make_pass, src);
			Marshal::FreeHGlobal(IntPtr(pass));
			Marshal::FreeHGlobal(IntPtr(make_pass));
		}
	};
}
