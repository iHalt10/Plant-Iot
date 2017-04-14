// plant_pixel.h
/*
�u�A�����C�u�����v
OpenCV���C�u�������g�p���Ă��܂��B
�R�[�h���̂͌��邱�Ƃ��ł���Ǝv���܂����A�G���[��\���E�r���h��������ۂɂ͍��ڂQ��
�u�R�[�g���r���ɂ��āv=>�u�@�v���Q�l�ɐݒ肵�Ă��������B
���Œ��_���s�N�Z���P�ʂŋ��߂遄
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
		// TODO: ���̃N���X�́A���[�U�[�̃��\�b�h�������ɒǉ����Ă��������B
	public:
		static int get_pixel(System::String^ pass_s) {
			//C#�ł��̃��C�u�������g�p���邽�ߌ^�ϊ�������
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
