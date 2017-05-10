// plant_pixel.h
/*
「植物ライブラリ」
OpenCVライブラリを使用しています。
コード自体は見ることができると思いますが、エラー非表示・ビルド等をする際には項目２の
「コートレビュについて」=>「①」を参考に設定してください。
＜最長点をピクセル単位で求める＞
*/
#pragma once
#include<opencv2/opencv.hpp>
#pragma comment(lib,"opencv_world310.lib")

using namespace cv;
using namespace System;
using namespace System::Runtime::InteropServices;

using namespace System;

namespace plant_pixel {

	public ref class pixel
	{
		// TODO: このクラスの、ユーザーのメソッドをここに追加してください。
	public:
		static int get_pixel(System::String^ pass_s) {
			//C#でこのライブラリを使用するため型変換をする
			char* pass = (char*)Marshal::StringToHGlobalAnsi(pass_s).ToPointer();
			Mat edge, gray = imread(pass, IMREAD_GRAYSCALE);
			Canny(gray, edge, 40, 200);
			for (int y = 0; y < edge.rows; y++) {
				for (int x = 0; x < edge.cols; x++) {
					int intensity = edge.at<unsigned char>(y, x);
					if (intensity) { Marshal::FreeHGlobal(IntPtr(pass)); return y; }
				}
			}
			Marshal::FreeHGlobal(IntPtr(pass));
			return -1;
		}
	};
}
