// plant_resizepicture.h
/*
�u�A�����C�u�����v
OpenCV���C�u�������g�p���Ă��܂��B
�R�[�h���̂͌��邱�Ƃ��ł���Ǝv���܂����A�G���[��\���E�r���h��������ۂɂ͍��ڂQ��
�u�R�[�g���r���ɂ��āv=>�u�@�v���Q�l�ɐݒ肵�Ă��������B
�����̉摜��1/4�Ƀ��T�C�Y���遄
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
		// TODO: ���̃N���X�́A���[�U�[�̃��\�b�h�������ɒǉ����Ă��������B
	public:
		static void make(System::String^ pass_s) {
			//C#�ł��̃��C�u�������g�p���邽�ߌ^�ϊ�������
			char* pass = (char*)Marshal::StringToHGlobalAnsi(pass_s).ToPointer();
			Mat dst, src = imread(pass);
			resize(src, dst, cv::Size(), 0.25, 0.25, INTER_AREA);
			imwrite("Resize.JPG", dst);
			Marshal::FreeHGlobal(IntPtr(pass));
		}
	};
}
