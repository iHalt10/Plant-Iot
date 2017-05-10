/*******************************//*
説明しにくいプログラムですので詳細なコメントは致しません。
*//******************************/
#include<stdio.h>
void main(){
    FILE *fp,*fp1;
    fpos_t pos=23967195;
    unsigned char screen[3];
    int i,j,flg_before=-1,flg_now,cnt=-1,min_num=0;
    fp1=fopen("幅：中央・高さ：0～3263(pixel)のRGB色数値.txt","w");
    fp=fopen("(3)二値化画像-24ビット.bmp","rb");
    for(i=0;i<3264;i++){
        fsetpos(fp,&pos);
        fread(screen,1,3,fp);
        fprintf(fp1,"%4d ",i);
        for(j=0;j<3;j++)fprintf(fp1,"%x ",screen[j]);
        putc('\n',fp1);
        if(screen[0]+screen[1]+screen[2]==0)flg_now=0;
        else flg_now=1;
        if(flg_before==1&&flg_now==0){
            cnt++;
            if(cnt>0)printf("%2dcm : %4dpixel - %4dpixel [差:%d]\n",14-cnt,min_num,i-1,(i-1)-min_num);
            min_num=i;
        }
        flg_before=flg_now;
        pos-=(2448*3);
    }
    printf("%2dcm : %4dpixel - %4dpixel [差:%d]\n",14-(++cnt),min_num,i-1,(i-1)-min_num);
    fclose(fp);
    fclose(fp1);
}