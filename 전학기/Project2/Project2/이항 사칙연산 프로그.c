#include<stdio.h>
#include<windows.h>
#include<conio.h>
int main()
{
	
		int chose;
		float x, y;
		printf("���� ���� ��Ģ���� ����Ʈ��� �̿��� �ּż� �����մϴ�.\n�ϰ��� �Ͻô� ������ ������ �ּ���.\n");
		while (1)
		{
		printf("1. ����   2. ����   3. ����   4. ������\n");

		scanf_s("%d", &chose);

		system("cls");
		switch (chose)
		{
		case 1:
			printf("������ �����ϼ̽��ϴ�. ���ϰ��� �ϴ� �� ���� ���ʷ� �Է��� �ּ���.\n");
			scanf_s("%f \n %f", &x, &y);
			printf("�����  :  %f  \n�����մϴ�. �ٸ� ������ ���� �����ôٸ� �ƹ� ��ư�̳� �����ּ���.\n", x + y);
			_getch();
			system("cls");
			break;
		case 2:
			printf("������ �����ϼ̽��ϴ�. ������ �ϴ� �� ���� ���ʷ� �Է��� �ּ���.\n");
			scanf_s("%f \n %f", &x, &y);
			printf("�����  :  %f  \n�����մϴ�. �ٸ� ������ ���� �����ôٸ� �ƹ� ��ư�̳� �����ּ���.\n", x - y);
			_getch();
			system("cls");
			break;
		case 3:
			printf("������ �����ϼ̽��ϴ�. ���ϰ��� �ϴ� �� ���� ���ʷ� �Է��� �ּ���.\n");
			scanf_s("%f \n %f", &x, &y);
			printf("�����  :  %f  \n�����մϴ�. �ٸ� ������ ���� �����ôٸ� �ƹ� ��ư�̳� �����ּ���.\n", x * y);
			_getch();
			system("cls");
			break;
		case 4:
			printf("�������� �����ϼ̽��ϴ�. �������� �ϴ� �� ���� ���ʷ� �Է��� �ּ���.\n");
			scanf_s("%f \n %f", &x, &y);
			printf("�����  :  %f  \n�����մϴ�. �ٸ� ������ ���� �����ôٸ� �ƹ� ��ư�̳� �����ּ���.\n", x / y);
			_getch();
			system("cls");
			break;

		}

	}

	return 0;

}