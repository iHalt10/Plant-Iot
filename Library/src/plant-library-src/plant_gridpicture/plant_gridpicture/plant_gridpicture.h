// plant_gridpicture.h
/*
�u�A�����C�u�����v
OpenCV���C�u�������g�p���Ă��܂��B
�R�[�h���̂͌��邱�Ƃ��ł���Ǝv���܂����A�G���[��\���E�r���h��������ۂɂ͍��ڂQ��
�u�R�[�g���r���ɂ��āv=>�u�@�v���Q�l�ɐݒ肵�Ă��������B
�����T�C�Y�摜�Ōr������摜�𐶐���
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
		// TODO: ���̃N���X�́A���[�U�[�̃��\�b�h�������ɒǉ����Ă��������B
	public:
		static void make(int pixel, System::String^ pass_s, System::String^ make_pass_s) {
			//C#�ł��̃��C�u�������g�p���邽�ߌ^�ϊ�������
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
