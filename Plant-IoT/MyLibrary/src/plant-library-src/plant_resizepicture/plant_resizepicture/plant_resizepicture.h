// plant_resizepicture.h
/*
「植物ライブラリ」
OpenCVライブラリを使用しています。
コード自体は見ることができると思いますが、エラー非表示・ビルド等をする際には項目２の
「コートレビュについて」=>「①」を参考に設定してください。
＜元の画像を1/4にリサイズする＞
*/
#pragma once
#include<opencv2/opencv.hpp>
#pragma comment(lib,"opencv_world310.lib")

using namespace cv;
using namespace System;
using namespace System::Runtime::InteropServices;

namespace plant_resizepicture {

	public ref class resizepicture
	{
		// TODO: このクラスの、ユーザーのメソッドをここに追加してください。
	public:
		static void make(System::String^ pass_s) {
			//C#でこのライブラリを使用するため型変換をする
			char* pass = (char*)Marshal::StringToHGlobalAnsi(pass_s).ToPointer();
			Mat dst, src = imread(pass);
			resize(src, dst, cv::Size(), 0.25, 0.25, INTER_AREA);
			imwrite("Resize.JPG", dst);
			Marshal::FreeHGlobal(IntPtr(pass));
		}
	};
}
