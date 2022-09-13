#include<stdio.h>
#include<windows.h>
#include<conio.h>
int main()
{
	
		int chose;
		float x, y;
		printf("저희 이항 사칙연산 소프트웨어를 이용해 주셔서 감사합니다.\n하고자 하시는 연산을 선택해 주세요.\n");
		while (1)
		{
		printf("1. 덧셈   2. 뺄셈   3. 곱셈   4. 나눗셈\n");

		scanf_s("%d", &chose);

		system("cls");
		switch (chose)
		{
		case 1:
			printf("덧셈을 선택하셨습니다. 더하고자 하는 두 수를 차례로 입력해 주세요.\n");
			scanf_s("%f \n %f", &x, &y);
			printf("계산결과  :  %f  \n감사합니다. 다른 연산을 고르고 싶으시다면 아무 버튼이나 눌러주세요.\n", x + y);
			_getch();
			system("cls");
			break;
		case 2:
			printf("뺄셈을 선택하셨습니다. 빼고자 하는 두 수를 차례로 입력해 주세요.\n");
			scanf_s("%f \n %f", &x, &y);
			printf("계산결과  :  %f  \n감사합니다. 다른 연산을 고르고 싶으시다면 아무 버튼이나 눌러주세요.\n", x - y);
			_getch();
			system("cls");
			break;
		case 3:
			printf("곱셈을 선택하셨습니다. 곱하고자 하는 두 수를 차례로 입력해 주세요.\n");
			scanf_s("%f \n %f", &x, &y);
			printf("계산결과  :  %f  \n감사합니다. 다른 연산을 고르고 싶으시다면 아무 버튼이나 눌러주세요.\n", x * y);
			_getch();
			system("cls");
			break;
		case 4:
			printf("나눗셈을 선택하셨습니다. 나누고자 하는 두 수를 차례로 입력해 주세요.\n");
			scanf_s("%f \n %f", &x, &y);
			printf("계산결과  :  %f  \n감사합니다. 다른 연산을 고르고 싶으시다면 아무 버튼이나 눌러주세요.\n", x / y);
			_getch();
			system("cls");
			break;

		}

	}

	return 0;

}