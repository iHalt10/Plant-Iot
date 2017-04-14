/*
OpenCV���C�u�������g�p���Ă��܂��B
�R�[�h���̂͌��邱�Ƃ��ł���Ǝv���܂����A�G���[��\���E�r���h��������ۂɂ͍��ڂQ��
�u�R�[�g���r���ɂ��āv=>�u�@�v���Q�l�ɐݒ肵�Ă��������B
���P�`�T�̃v���O�������܂Ƃ߂Ď��s�ł���u�A���摜����.exe�v�쐬��
*/
#include<cstdio>
#include <math.h>
#include<opencv2/opencv.hpp>
#pragma comment(lib,"opencv_world310.lib")
using namespace cv;
void main(int argc, char *argv[]) {
	int x, y;
	Mat edge, gray = imread(argv[1], IMREAD_GRAYSCALE);
	if (!gray.data) {
		if (argc < 2)printf("error:����(�e�X�g�p�摜�̃f�B���N�g��)����͂��Ă�������");
		else printf("error:���m�ȃf�B���N�g������͂��Ă�������");
		return;
	}

	/*�Œ��_���s�N�Z���P�ʂœ��肷��*/
	printf("\n�u�Œ��_���s�N�Z���P�ʂœ��肷��v���C�u������(dll�t�@�C��:C++)\n");
	imwrite("./�o�͉摜//(1)�O���[�X�P�[��.JPG", gray); //���J���[�摜���G�b�W���o����ɂ̓O���[�X�P�[���ɂ���K�v������
	printf("(1)�u./�o�͉摜�v�ɃO���[�X�P�[���摜���쐬�B\n");
	//�G�b�W���o
	Canny(gray, edge, 40, 200);
	imwrite("./�o�͉摜//(2)�G�b�W���o.JPG", edge);
	printf("(2)�u./�o�͉摜�v�ɃG�b�W�摜���쐬\n");
	//�G�b�W���o�����摜���獂��y������ɍŒ��_���s�N�Z���P�ʂœ��肷��
	for (y = 0; y < edge.rows; y++) {
		for (x = 0; x < edge.cols; x++) {
			int intensity = edge.at<unsigned char>(y, x);
			if (intensity)goto flg;
		}
	}
flg:printf("�Œ��_���s�N�Z���P�ʂŕ\��\n");
	printf("�����F%d\n(���F%d)(�F�l�F%d)\n\n\n", y, x, edge.at<unsigned char>(y, x));

	/*�Œ��_�̈ʒu�����������m�F*/
	printf("�u�Œ��_�̈ʒu�����������m�F�v\n");
	int pixel = y;
	Mat gridpicture = imread(argv[1]);
	if (pixel >= 479 && pixel <= 2668)
		for (int i = 0; i < 6; i++, pixel--)for (int j = 0; j < gridpicture.cols; j++)gridpicture.at<Vec3b>(pixel, j) = Vec3b(255, 0, 0);
	imwrite("./�o�͉摜//(3)�Œ��_�ʒu�m�F.JPG", gridpicture);
	printf("(3)�u./�o�͉摜�v�ɍŒ��_�̈ʒu�m�F�摜���쐬�B\n\n\n");

	pixel = y;
	int resizepixel = (int)floor((double)y / 4);//�Œ��_��1/4
	Mat origin = imread(argv[1]), resizepicture;

	/*���T�C�Y*/
	printf("�u���T�C�Y�v���C�u������(dll�t�@�C��:C++)\n");
	resize(origin, resizepicture, cv::Size(), 0.25, 0.25, INTER_AREA);
	imwrite("./�o�͉摜//(4)���T�C�Y.JPG", resizepicture);//�l�b�g���[�N���o�R���ĉ摜�𑗐M���邽��1/4�Ƀ��T�C�Y����
	printf("(4)�u./�o�͉摜�v�Ƀ��T�C�Y�摜���쐬\n\n\n");

	/*���T�C�Y�摜�Ōr������摜���쐬*///���T�C�Y�����摜�Ɏ����P�̌���(�Q����,�R�����c�P�R�����̋��E���̐��l)�𗘗p���Čr���̂���摜���o��"
	printf("�u���T�C�Y�摜�Ōr������摜���쐬�v���C�u������(dll�t�@�C��:C++)\n");
	int lkup_pic[12] = { 119, 163, 209, 257, 307, 359, 414, 472, 533, 598, 667, 740 };//�����P�̊e�f�[�^��1/4�ɂ���
	int lkup_num[12] = { 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1 };
	Vec3b r = Vec3b(0, 0, 255);//��
	Vec3b b = Vec3b(255, 0, 0);//��
	Vec3b gr = Vec3b(0, 255, 255);//���F
	for (int i = 0; i < 12; i++) {
		for (int j = 1; j <= lkup_num[i]; j++, lkup_pic[i]--) {
			if (i == 2 || i == 5)for (int k = 0; k < resizepicture.cols; k++)resizepicture.at<Vec3b>(lkup_pic[i], k) = gr;
			else for (int k = 0; k < resizepicture.cols; k++)resizepicture.at<Vec3b>(lkup_pic[i], k) = r;
		}
	}
	if (resizepixel >= lkup_pic[0] && resizepixel <= lkup_pic[10])
		for (int i = 0; i < 2; i++, resizepixel--)for (int j = 0; j < resizepicture.cols; j++)resizepicture.at<Vec3b>(resizepixel, j) = b;
	imwrite("./�o�͉摜//(5)�r������.JPG", resizepicture);
	printf("(5)�u./�o�͉摜�v�Ɍr������̉摜���쐬\n\n\n");

	/*�L�������߂�*/
	double result;
	printf("�u�L�������߂�v���C�u������(dll�t�@�C��:C#)\n");
	int  i, pixel_num[] = { 2668, 2392, 2132, 1889, 1657, 1437, 1228, 1029, 837, 654, 479 };
	if (pixel == pixel_num[10]) { result = 13.0; printf("�����F13.0cm\n\n"); goto A1; }
	else if (pixel < pixel_num[10]) { result = -2.0; printf("�����F����s��(-2.0)\n\n"); goto A2; }
	if (pixel > pixel_num[0]) { result = -1.0; printf("�����F�����(-1.0)\n\n"); goto A3; }
	for (i = 9; i >= 0; i--)if (pixel <= pixel_num[i]) break;
	double cmp = (double)i + (double)1 / (double)(pixel_num[i] - pixel_num[i + 1]) * (double)(pixel_num[i] - pixel);
	result = (double)floor(cmp * 10.0) / 10.0 + 3;
	printf("�����F%fcm\n\n", result);
A1:; A2:; A3:;
	printf("\n");

	/*�J�C�����_�C�R���̊e����*/
	printf("�u�J�C�����_�C�R���̊e���ԁv(���ڋL�q)\n");
	double lenght = result;
	if (lenght == -2) printf("����s��\n\n");
	else if (lenght == -1) printf("�����\n\n");
	else if (lenght < 8) printf("������\n\n");
	else if (lenght < 11) printf("���n��\n\n");
	else printf("�ߏ萬����\n\n");
	printf("\n");

	/*�������i���C�g�̓���؂�*/
	printf("�u�A���琬LED�̓���؂�v(���ڋL�q)\n");
	if (pixel > 837 && pixel <= 2668) printf("�A���琬LED�FON\n");
	else printf("�A���琬LED�FOFF\n");

}