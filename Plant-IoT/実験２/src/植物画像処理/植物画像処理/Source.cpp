/*
OpenCVライブラリを使用しています。
コード自体は見ることができると思いますが、エラー非表示・ビルド等をする際には項目２の
「コートレビュについて」=>「①」を参考に設定してください。
＜１～５のプログラムをまとめて実行できる「植物画像処理.exe」作成＞
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
		if (argc < 2)printf("error:引数(テスト用画像のディレクトリ)を入力してください");
		else printf("error:正確なディレクトリを入力してください");
		return;
	}

	/*最長点をピクセル単位で特定する*/
	printf("\n「最長点をピクセル単位で特定する」ライブラリ化(dllファイル:C++)\n");
	imwrite("./出力画像//(1)グレースケール.JPG", gray); //※カラー画像をエッジ検出するにはグレースケールにする必要がある
	printf("(1)「./出力画像」にグレースケール画像を作成。\n");
	//エッジ検出
	Canny(gray, edge, 40, 200);
	imwrite("./出力画像//(2)エッジ検出.JPG", edge);
	printf("(2)「./出力画像」にエッジ画像を作成\n");
	//エッジ検出した画像から高さy軸を基準に最長点をピクセル単位で特定する
	for (y = 0; y < edge.rows; y++) {
		for (x = 0; x < edge.cols; x++) {
			int intensity = edge.at<unsigned char>(y, x);
			if (intensity)goto flg;
		}
	}
flg:printf("最長点をピクセル単位で表示\n");
	printf("高さ：%d\n(幅：%d)(色値：%d)\n\n\n", y, x, edge.at<unsigned char>(y, x));

	/*最長点の位置が正しいか確認*/
	printf("「最長点の位置が正しいか確認」\n");
	int pixel = y;
	Mat gridpicture = imread(argv[1]);
	if (pixel >= 479 && pixel <= 2668)
		for (int i = 0; i < 6; i++, pixel--)for (int j = 0; j < gridpicture.cols; j++)gridpicture.at<Vec3b>(pixel, j) = Vec3b(255, 0, 0);
	imwrite("./出力画像//(3)最長点位置確認.JPG", gridpicture);
	printf("(3)「./出力画像」に最長点の位置確認画像を作成。\n\n\n");

	pixel = y;
	int resizepixel = (int)floor((double)y / 4);//最長点を1/4
	Mat origin = imread(argv[1]), resizepicture;

	/*リサイズ*/
	printf("「リサイズ」ライブラリ化(dllファイル:C++)\n");
	resize(origin, resizepicture, cv::Size(), 0.25, 0.25, INTER_AREA);
	imwrite("./出力画像//(4)リサイズ.JPG", resizepicture);//ネットワークを経由して画像を送信するため1/4にリサイズする
	printf("(4)「./出力画像」にリサイズ画像を作成\n\n\n");

	/*リサイズ画像で罫線ある画像を作成*///リサイズした画像に実験１の結果(２ｃｍ,３ｃｍ…１３ｃｍの境界線の数値)を利用して罫線のある画像を出力"
	printf("「リサイズ画像で罫線ある画像を作成」ライブラリ化(dllファイル:C++)\n");
	int lkup_pic[12] = { 119, 163, 209, 257, 307, 359, 414, 472, 533, 598, 667, 740 };//実験１の各データを1/4にする
	int lkup_num[12] = { 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1 };
	Vec3b r = Vec3b(0, 0, 255);//赤
	Vec3b b = Vec3b(255, 0, 0);//青
	Vec3b gr = Vec3b(0, 255, 255);//黄色
	for (int i = 0; i < 12; i++) {
		for (int j = 1; j <= lkup_num[i]; j++, lkup_pic[i]--) {
			if (i == 2 || i == 5)for (int k = 0; k < resizepicture.cols; k++)resizepicture.at<Vec3b>(lkup_pic[i], k) = gr;
			else for (int k = 0; k < resizepicture.cols; k++)resizepicture.at<Vec3b>(lkup_pic[i], k) = r;
		}
	}
	if (resizepixel >= lkup_pic[0] && resizepixel <= lkup_pic[10])
		for (int i = 0; i < 2; i++, resizepixel--)for (int j = 0; j < resizepicture.cols; j++)resizepicture.at<Vec3b>(resizepixel, j) = b;
	imwrite("./出力画像//(5)罫線あり.JPG", resizepicture);
	printf("(5)「./出力画像」に罫線ありの画像を作成\n\n\n");

	/*伸長を求める*/
	double result;
	printf("「伸長を求める」ライブラリ化(dllファイル:C#)\n");
	int  i, pixel_num[] = { 2668, 2392, 2132, 1889, 1657, 1437, 1228, 1029, 837, 654, 479 };
	if (pixel == pixel_num[10]) { result = 13.0; printf("長さ：13.0cm\n\n"); goto A1; }
	else if (pixel < pixel_num[10]) { result = -2.0; printf("長さ：測定不可(-2.0)\n\n"); goto A2; }
	if (pixel > pixel_num[0]) { result = -1.0; printf("長さ：発芽期(-1.0)\n\n"); goto A3; }
	for (i = 9; i >= 0; i--)if (pixel <= pixel_num[i]) break;
	double cmp = (double)i + (double)1 / (double)(pixel_num[i] - pixel_num[i + 1]) * (double)(pixel_num[i] - pixel);
	result = (double)floor(cmp * 10.0) / 10.0 + 3;
	printf("長さ：%fcm\n\n", result);
A1:; A2:; A3:;
	printf("\n");

	/*カイワレダイコンの各期間*/
	printf("「カイワレダイコンの各期間」(直接記述)\n");
	double lenght = result;
	if (lenght == -2) printf("測定不可\n\n");
	else if (lenght == -1) printf("発芽期\n\n");
	else if (lenght < 8) printf("成長期\n\n");
	else if (lenght < 11) printf("収穫期\n\n");
	else printf("過剰成長期\n\n");
	printf("\n");

	/*成長促進ライトの入り切り*/
	printf("「植物育成LEDの入り切り」(直接記述)\n");
	if (pixel > 837 && pixel <= 2668) printf("植物育成LED：ON\n");
	else printf("植物育成LED：OFF\n");

}